using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace Ca.Magrathean.Yup.Controls
{
    [System.ComponentModel.DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public partial class ToolStripYUPTrackBar : ToolStripControlHost
    {
        public ToolStripYUPTrackBar()
            : base(CreateControlInstance())
        {
            AutoSize = false;
        }

        /// <summary>
        /// Create a strongly typed property called YUPTrackBar - handy to prevent casting everywhere.
        /// </summary>
        public YUPTrackBar TrackBarControl
        {
            get
            {
                return Control as YUPTrackBar;
            }
        }

        /// <summary>
        /// Create the actual control, note this is static so it can be called from the
        /// constructor.
        /// </summary>
        /// <returns>Control of YUPTrackBar</returns>
        private static Control CreateControlInstance()
        {
            YUPTrackBar trackbar = new YUPTrackBar();
            trackbar.AutoSize = false;

            return trackbar;
        }
    }
}
