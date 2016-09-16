using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ca.Magrathean.Yup.Controls
{
    /// <summary>
    /// A Mac-Like Spinner Control
    /// </summary>
    [System.ComponentModel.DesignerCategory("code")]
    public partial class Spinner : Control
    {
        // The timer object.
        Timer frameTimer;
        
        // Should we be going for another run?
        bool switchBack = false;

        // Keep each segments status.
        int segmentsSwitchedBack = 0;
        
        // Keep each segments status.
        int segmentsGreen = 0;

        // How many please?
        int segments;

        // Displaying Text?
        bool displaySegmentText;

        // Text in the center?
        string displayString = string.Empty;

        /// <summary>
        /// Create a new Spinner object with a default setting of 12 segments.
        /// </summary>
        public Spinner() : this(12) { }

        /// <summary>
        /// Create a new Spinner object.
        /// </summary>
        /// <param name="segments">The number of segments you wish to have.</param>
        public Spinner(int segments)
        {
            this.segments = segments;
            this.Text = segments.ToString();

            // Set the basic Control styles
            {
                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            }

            // Load the components...
            InitializeComponent();

            // Timer functions
            {
                this.frameTimer = new Timer();
                this.frameTimer.Interval = 100;
                this.frameTimer.Tick += new EventHandler(frameTimer_Tick);
                this.frameTimer.Start();
            }
        }

        public string DisplayString
        {
            get 
            { 
                return displayString;
            }
            set
            { 
                displayString = value;
            }
        }

        /// <summary>
        /// The total number of segments in the Spinner Control
        /// </summary>
        [Browsable(false)]
        public int Segments
        {
            get
            {
                return this.segments;
            }
            set
            {
                this.segments = value;
                this.Text = value.ToString();
                Invalidate();
            }
        }

        /// <summary>
        /// Display the segment text in the center
        /// </summary>
        public bool DisplaySegmentText
        {
            get
            { 
                return displaySegmentText; 
            }
            set
            { 
                displaySegmentText = value; 
            }
        }
        
        void frameTimer_Tick(object sender, EventArgs e)
        {
            if (switchBack)
                segmentsSwitchedBack++;
            else
                segmentsGreen++;

            if (segmentsGreen >= Segments)
                switchBack = true;

            if ((segmentsGreen >= Segments && segmentsSwitchedBack >= segmentsGreen) || (switchBack && segmentsSwitchedBack > Segments))
            {
                switchBack = false;
                segmentsGreen = 0;
                segmentsSwitchedBack = 0;
            }

            frameTimer.Interval = 1200 / Segments;

            Invalidate();
        }

        /// <summary>
        /// Delegate for Control.OnPaint event.
        /// </summary>
        /// <param name="pe">The paint event arguments object.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Show and Hide
            if (this.Visible)
            {
                this.frameTimer.Start();
                this.Show();
            }
            else
            {
                this.Hide();
                this.frameTimer.Stop();
            }

            try
            {
                // Level of Change Controls
                int first = 20;
                int second = 40;
                int third = 60;

                // Load the custom color value from the Settings
                Color userColorMain = Settings.DigitalDisplayColor;
                Color userColorMainShadow = Color.FromArgb(userColorMain.A, LevelInteger(userColorMain.R, first), LevelInteger(userColorMain.G, first), LevelInteger(userColorMain.B, first));
                Color userColorLight = Color.FromArgb(userColorMain.A, LevelInteger(userColorMain.R, second), LevelInteger(userColorMain.G, second), LevelInteger(userColorMain.B, second));
                Color userColorLightShadow = Color.FromArgb(userColorMain.A, LevelInteger(userColorMain.R, third), LevelInteger(userColorMain.G, third), LevelInteger(userColorMain.B, third));

                // Create the main brushes
                Brush userColorMainBrush = new SolidBrush(userColorMain);
                Brush userColorMainShadowBrush = new SolidBrush(userColorMainShadow);
                Brush userColorLightBrush = new SolidBrush(userColorLight);
                Brush userColorLightShadowBrush = new SolidBrush(userColorLightShadow);
                Brush greyBrush = new SolidBrush(this.BackColor);
                Brush greyShadowBrush = new SolidBrush(Color.FromArgb(this.BackColor.A, LevelInteger(this.BackColor.R, second), LevelInteger(this.BackColor.G, second), LevelInteger(this.BackColor.B, second)));
                Brush backBrush = new SolidBrush(this.BackColor);

                // Capture the Graphics object
                Graphics g = pe.Graphics;

                // Find the DrawRect
                int size = ClientRectangle.Width > ClientRectangle.Height ? ClientRectangle.Height - 10 : ClientRectangle.Width - 10;
                
                // Padding
                Rectangle progressArea = new Rectangle((ClientRectangle.Width - size) / 2, (ClientRectangle.Height - size) / 2, size, size);
                
                // Begin Graphics
                g.ResetClip();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(this.BackColor);

                // Create a Pen object
                Pen backPen = new Pen(backBrush, size / 30);

                // Calculate the segments and their angles
                float segs = Segments < 3 ? 3 : Segments > 90 ? 90 : Segments;
                float angle = 360 / segs;

                // Drawing Mathematics
                int innerCircleWidth = (int)(progressArea.Width * 0.65);
                int shadowCircleWidth = (int)(progressArea.Width * 0.68);
                int innerCircleOffset = ((progressArea.Width - innerCircleWidth) / 2);
                int shadowCircleOffset = ((progressArea.Width - shadowCircleWidth) / 2);

                // The fullon Color Rectangle
                Rectangle innerCircle = new Rectangle(progressArea.Left + innerCircleOffset,
                                                       progressArea.Top + innerCircleOffset,
                                                       innerCircleWidth, innerCircleWidth);

                // The lineoff Color Rectangle
                Rectangle shadowCircle = new Rectangle(progressArea.Left + shadowCircleOffset,
                                                       progressArea.Top + shadowCircleOffset,
                                                       shadowCircleWidth, shadowCircleWidth);

                // For each segment
                for (int i = 0; i < segs; i++)
                {
                    float startAngle = (angle * i) + 270;
                    Brush b;
                    Brush shadow;

                    if (i <= segmentsGreen && i >= segmentsSwitchedBack)
                        if (((i == segmentsGreen) && !switchBack) || ((i == segmentsSwitchedBack) && switchBack))
                        {
                            b = userColorLightBrush;
                            shadow = userColorLightShadowBrush;
                        }
                        else
                        {
                            b = userColorMainBrush;
                            shadow = userColorMainShadowBrush;
                        }
                    else
                    {
                        b = greyBrush;
                        shadow = greyShadowBrush;
                    }

                    g.FillPie(b, progressArea, startAngle, angle);
                    g.FillPie(shadow, shadowCircle, startAngle, angle);
                    g.DrawPie(backPen, progressArea, startAngle, angle);
                }

                g.FillEllipse(backBrush, innerCircle);

                if (displaySegmentText)
                {
                    TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

                    using (Font drawFont = new Font("Arial", 22, FontStyle.Bold, GraphicsUnit.Point))
                    {
                        Rectangle rect = ClientRectangle;

                        rect.X += 2;

                        TextRenderer.DrawText(g, this.Text, drawFont, rect, Color.Black, flags);
                    }
                }
                else if (DisplayString != string.Empty)
                {
                    TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

                    using (Font drawFont = new Font("Arial", 32, FontStyle.Bold, GraphicsUnit.Point))
                    {
                        Rectangle rect = ClientRectangle;

                        rect.X += 2;

                        TextRenderer.DrawText(g, DisplayString, drawFont, rect, userColorLightShadow, flags);
                    }
                }

                backPen.Dispose();
                backBrush.Dispose();
            }
            catch (Exception) { }
        }

        private int LevelInteger(int source, int application)
        {
            if ((source - application) < 0)
            {
                return 0;
            }
            else
            {
                return source - application;
            }
        }
    }
}