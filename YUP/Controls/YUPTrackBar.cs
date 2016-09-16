using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using Ca.Magrathean.Yup.Forms;
using System.Drawing.Drawing2D;

namespace Ca.Magrathean.Yup.Controls
{
    [System.ComponentModel.DesignerCategory("code")]
    public partial class YUPTrackBar : Control, ISupportInitialize
    {
        #region Private Members
        // Drawing Variables
        bool m_redrawBackground = true;
        Color m_color = Color.LimeGreen;
        Color m_downloadBarColor = Color.LimeGreen;
        Bitmap m_trackbarBitmap;
        bool m_doNotRender;

        // State Variables
        int m_currentValue = 0;
        int m_maximumValue = 100;
        float m_downloadedPercentage;

        // Background Vars
        const float BackgroundDefaultRadius = 4.0f;
        Rectangle m_backgroundRectangle = new Rectangle();
        Rectangle m_backgroundFillerRectangle = new Rectangle();

        // Tracker Vars
        const float TrackerDefaultRadius = 2.5f;
        const int TrackerDefaultWidth = 12;
        const int TrackerDefaultHeight = 12;
        const int TrackerDefaultX = 6;
        const int TrackerDefaultY = 6;
        const int TrackerMinimumX = 6;

        Rectangle m_trackerRectangle = new Rectangle(new Point(TrackerDefaultX, TrackerDefaultY), new Size(TrackerDefaultWidth, TrackerDefaultHeight));
        
        int m_trackerMaximumX;
        bool m_trackerHover = false;

        // Mouse Vars
        Rectangle m_mouseRectangle;
        bool m_mouseTracking = false;
        #endregion

        public event EventHandler ValueChanged;

        #region Constructor
        public YUPTrackBar()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            RefreshAll();

            Value = 0;
        }
        #endregion

        #region ISupportInitialize Members
        public void BeginInit()
        {
            m_doNotRender = true;
        }

        public void EndInit()
        {
            m_doNotRender = false;
        }
        #endregion

        #region Control Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_doNotRender)
            {
                return;
            }

            if (m_redrawBackground)
            {
                m_redrawBackground = false;

                m_trackbarBitmap = new Bitmap(ClientSize.Width, ClientSize.Height, e.Graphics);

                using (Graphics gfx = Graphics.FromImage(m_trackbarBitmap))
                {
                    gfx.FillRectangle(new SolidBrush(Color.Black), ClientRectangle);

                    gfx.SmoothingMode = SmoothingMode.AntiAlias;
                    gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    m_backgroundFillerRectangle.Location = Point.Add(Location, new Size(4, 4));
                    m_backgroundFillerRectangle.Size = Size.Subtract(Size, new Size(8, 8));

                    float bgF_R = BackgroundDefaultRadius;
                    float bgF_X = (float)m_backgroundFillerRectangle.X;
                    float bgF_Y = (float)m_backgroundFillerRectangle.Y;
                    float bgF_W = (float)(m_backgroundFillerRectangle.Width * (m_downloadedPercentage / 100));
                    float bgF_H = (float)m_backgroundFillerRectangle.Height;

                    if (bgF_W > 0)
                    {
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            path.AddLine(bgF_X + bgF_R, bgF_Y, bgF_X + bgF_W - (bgF_R * 2), bgF_Y);
                            path.AddArc(bgF_X + bgF_W - (bgF_R * 2), bgF_Y, bgF_R * 2, bgF_R * 2, 270, 90);
                            path.AddLine(bgF_X + bgF_W, bgF_Y + bgF_R, bgF_X + bgF_W, bgF_Y + bgF_H - (bgF_R * 2));
                            path.AddArc(bgF_X + bgF_W - (bgF_R * 2), bgF_Y + bgF_H - (bgF_R * 2), bgF_R * 2, bgF_R * 2, 0, 90);
                            path.AddLine(bgF_X + bgF_W - (bgF_R * 2), bgF_Y + bgF_H, bgF_X + bgF_R, bgF_Y + bgF_H);
                            path.AddArc(bgF_X, bgF_Y + bgF_H - (bgF_R * 2), bgF_R * 2, bgF_R * 2, 90, 90);
                            path.AddLine(bgF_X, bgF_Y + bgF_H - (bgF_R * 2), bgF_X, bgF_Y + bgF_R);
                            path.AddArc(bgF_X, bgF_Y, bgF_R * 2, bgF_R * 2, 180, 90);
                            path.CloseFigure();

                            gfx.FillPath(new SolidBrush(m_downloadBarColor), path);
                        }
                    }

                    m_backgroundRectangle.Location = Point.Add(Location, new Size(4, 4));
                    m_backgroundRectangle.Size = Size.Subtract(Size, new Size(8, 8));

                    float bg_R = BackgroundDefaultRadius;
                    float bg_X = (float)m_backgroundRectangle.X;
                    float bg_Y = (float)m_backgroundRectangle.Y;
                    float bg_W = (float)m_backgroundRectangle.Width;
                    float bg_H = (float)m_backgroundRectangle.Height;

                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddLine(bg_X + bg_R, bg_Y, bg_X + bg_W - (bg_R * 2), bg_Y);
                        path.AddArc(bg_X + bg_W - (bg_R * 2), bg_Y, bg_R * 2, bg_R * 2, 270, 90);
                        path.AddLine(bg_X + bg_W, bg_Y + bg_R, bg_X + bg_W, bg_Y + bg_H - (bg_R * 2));
                        path.AddArc(bg_X + bg_W - (bg_R * 2), bg_Y + bg_H - (bg_R * 2), bg_R * 2, bg_R * 2, 0, 90);
                        path.AddLine(bg_X + bg_W - (bg_R * 2), bg_Y + bg_H, bg_X + bg_R, bg_Y + bg_H);
                        path.AddArc(bg_X, bg_Y + bg_H - (bg_R * 2), bg_R * 2, bg_R * 2, 90, 90);
                        path.AddLine(bg_X, bg_Y + bg_H - (bg_R * 2), bg_X, bg_Y + bg_R);
                        path.AddArc(bg_X, bg_Y, bg_R * 2, bg_R * 2, 180, 90);
                        path.CloseFigure();

                        gfx.DrawPath(new Pen(m_color, 4), path);
                        // gfx.FillPath(new SolidBrush(Color.Black), path);
                    }
                }
            }

            // Change Graphics rendering mode.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Render the background...
            e.Graphics.DrawImageUnscaled(m_trackbarBitmap, 0, 0);

            // Find the maximum we can move the tracker to...
            m_trackerMaximumX = Size.Width - (TrackerDefaultWidth + TrackerDefaultX);

            // Set the maximum Height.
            m_trackerRectangle.Height = Size.Height - TrackerDefaultHeight;

            float trk_R = BackgroundDefaultRadius;
            float trk_X = m_trackerRectangle.X;
            float trk_Y = m_trackerRectangle.Y;
            float trk_W = m_trackerRectangle.Width;
            float trk_H = m_trackerRectangle.Height;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(trk_X + trk_R, trk_Y, trk_X + trk_W - (trk_R * 2), trk_Y);
                path.AddArc(trk_X + trk_W - (trk_R * 2), trk_Y, trk_R * 2, trk_R * 2, 270, 90);
                path.AddLine(trk_X + trk_W, trk_Y + trk_R, trk_X + trk_W, trk_Y + trk_H - (trk_R * 2));
                path.AddArc(trk_X + trk_W - (trk_R * 2), trk_Y + trk_H - (trk_R * 2), trk_R * 2, trk_R * 2, 0, 90);
                path.AddLine(trk_X + trk_W - (trk_R * 2), trk_Y + trk_H, trk_X + trk_R, trk_Y + trk_H);
                path.AddArc(trk_X, trk_Y + trk_H - (trk_R * 2), trk_R * 2, trk_R * 2, 90, 90);
                path.AddLine(trk_X, trk_Y + trk_H - (trk_R * 2), trk_X, trk_Y + trk_R);
                path.AddArc(trk_X, trk_Y, trk_R * 2, trk_R * 2, 180, 90);
                path.CloseFigure();

                if (m_trackerHover)
                {
                    // e.Graphics.DrawPath(new Pen(Color.White, 2), path);
                    e.Graphics.FillPath(new SolidBrush(Color.White), path);
                }
                else
                {
                    e.Graphics.FillPath(new SolidBrush(Color.DarkGray), path);
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (m_mouseRectangle.IntersectsWith(m_trackerRectangle))
            {
                Capture = true;

                m_mouseTracking = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Capture = false;
            m_mouseTracking = false;

            Refresh();

            if (ValueChanged != null)
            {
                ValueChanged(this, new EventArgs());
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            m_mouseRectangle = new Rectangle(e.Location, new Size(1, 1));

            if (m_mouseTracking)
            {
                m_trackerHover = true;

                SetTrackerPosition(e.X - TrackerDefaultWidth / 2);
            }
            else
            {
                m_trackerHover = m_mouseRectangle.IntersectsWith(m_trackerRectangle);
                
                Refresh();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            // Find the maximum we can move the tracker to...
            m_trackerMaximumX = Size.Width - (TrackerDefaultWidth - TrackerDefaultX);

            RefreshAll();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
        #endregion

        #region Private Methods
        private void RefreshAll()
        {
            // We need to redraw the background of the trackbar.
            m_redrawBackground = true;

            // Refresh forces the control to redraw itself.
            Refresh();
        }

        private void SetTrackerPosition(int pos)
        {
            pos += TrackerMinimumX;

            if (pos > m_trackerMaximumX)
            {
                m_trackerRectangle.X = m_trackerMaximumX;
            }
            else if (pos < TrackerMinimumX)
            {
                m_trackerRectangle.X = TrackerMinimumX;
            }
            else
            {
                m_trackerRectangle.X = pos;
            }

            Refresh();
        }
        #endregion

        #region Public Properties
        [System.ComponentModel.Browsable(true), System.ComponentModel.Category("Track Bar"), System.ComponentModel.Description("The value of the slider in the trackbar.")]
        public int Value
        {
            get 
            {
                double percentage = (double)(m_trackerRectangle.X - TrackerMinimumX) / (m_trackerMaximumX - TrackerMinimumX);
                int v = (int)(percentage * m_maximumValue);

                if (v < 0)
                {
                    v = 0;
                }


                if (v > m_maximumValue)
                {
                    v = m_maximumValue;
                }

                return v;
            }
            set
            {
                if (!m_mouseTracking)
                {
                    float parts = (float)(m_trackerMaximumX - TrackerMinimumX) / (float)m_maximumValue;

                    SetTrackerPosition((int)(parts * value));

                    m_currentValue = value;

                    Refresh();
                }
            }
        }

        [System.ComponentModel.Browsable(true), System.ComponentModel.Category("Track Bar"), System.ComponentModel.Description("The MAXIMUM value of the slider in the trackbar.")]
        public int Maximum
        {
            get { return m_maximumValue; }
            set { m_maximumValue = value; }
        }

        [System.ComponentModel.Browsable(true), System.ComponentModel.Category("Track Bar"), System.ComponentModel.Description("The border COLOR of the trackbar.")]
        public Color Color
        {
            get { return m_color; }
            set
            {
                m_color = value;

                m_redrawBackground = true;

                Refresh();
            }
        }

        [System.ComponentModel.Browsable(true), System.ComponentModel.Category("Track Bar"), System.ComponentModel.Description("The download bar background COLOR of the trackbar.")]
        public Color DownloadBarColor
        {
            get { return m_downloadBarColor; }
            set
            {
                m_downloadBarColor = value;

                m_redrawBackground = true;

                Refresh();
            }
        }

        [System.ComponentModel.Browsable(true), System.ComponentModel.Category("Track Bar"), System.ComponentModel.Description("The percentile of downloading complete.")]
        public float DownloadedPercentage
        {
            get { return m_downloadedPercentage; }
            set
            {
                if (value > 100)
                {
                    m_downloadedPercentage = 100;
                }
                if (value < 0)
                {
                    m_downloadedPercentage = 0;
                }
                else
                {
                    m_downloadedPercentage = value;
                }
                
                RefreshAll();
            }
        }
        #endregion
    }
}
