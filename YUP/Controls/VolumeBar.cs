using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Text;

namespace Ca.Magrathean.Yup.Controls
{
    /// <summary>
    /// The Toolstrip Volume Control Bar for YUP
    /// </summary>
    [System.ComponentModel.DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public partial class ToolStripVolumeBar : ToolStripControlHost
    {
        private TrackBar volumeBar;
        public event EventHandler VolumeChanged;

        /// <summary>
        /// ToolStrip Volume Control Bar Constructor
        /// </summary>
        public ToolStripVolumeBar() : base(CreateControlInstance())
        {
            volumeBar = Control as TrackBar;
            volumeBar.TickStyle = TickStyle.None;
            volumeBar.Maximum = 10;
            volumeBar.Minimum = 0;
            volumeBar.LargeChange = 0;
            volumeBar.AutoSize = false;
            volumeBar.MouseUp += new MouseEventHandler(volumeBar_MouseUp);
            volumeBar.KeyUp += new KeyEventHandler(volumeBar_KeyUp);
            volumeBar.MouseWheel += new MouseEventHandler(volumeBar_MouseWheel);
        }

        void volumeBar_MouseWheel(object sender, MouseEventArgs e)
        {
            TriggerVolumeChangedEvent();
        }

        void volumeBar_KeyUp(object sender, KeyEventArgs e)
        {
            TriggerVolumeChangedEvent();
        }

        void volumeBar_MouseUp(object sender, MouseEventArgs e)
        {
            TriggerVolumeChangedEvent();
        }

        private void TriggerVolumeChangedEvent()
        {
            if (VolumeChanged != null)
            {
                VolumeChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Create the actual control, note this is static so it can be called from the
        /// constructor.
        /// 
        /// </summary>
        /// <returns></returns>
        private static Control CreateControlInstance()
        {
            TrackBar volumeBar = new TrackBar();

            return volumeBar;
        }

        /// <summary>
        /// Create a strongly typed property called Progress - handy to prevent casting everywhere.
        /// </summary>
        [Browsable(true)]
        public TrackBar VolumeBar
        {
            get
            {
                return Control as TrackBar;
            }
        }
    }
}
