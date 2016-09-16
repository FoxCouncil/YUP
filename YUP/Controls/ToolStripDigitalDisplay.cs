using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing;

namespace Ca.Magrathean.Yup.Controls
{
    [System.ComponentModel.DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public partial class ToolStripDigitalDisplay : ToolStripControlHost
    {
        private DigitalDisplayControl ddc;

        public ToolStripDigitalDisplay() : base(CreateControlInstance())
        {
            ddc = Control as DigitalDisplayControl;

            ddc.SizeChanged += new EventHandler(ddc_SizeChanged);
        }

        void ddc_SizeChanged(object sender, EventArgs e)
        {
            if (AutoSize)
            {
                Size = ddc.Size;
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
            DigitalDisplayControl dd = new DigitalDisplayControl();

            dd.AutoSize = false;

            // Add other initialization code here.
            return dd;
        }

        /// <summary>
        /// Create a strongly typed property called DigitalDisplayControl - handy to prevent casting everywhere.
        /// </summary>
        [Browsable(false)]
        public DigitalDisplayControl DigitalDisplay
        {
            get
            {
                return Control as DigitalDisplayControl;
            }
        }

        public Color DigitColor
        {
            get
            {
                return ddc.DigitColor;
            }
            set
            {
                ddc.DigitColor = value;
            }
        }

        public string DigitText
        {
            get
            {
                return ddc.DigitText;
            }
            set
            {
                ddc.DigitText = value;
            }
        }
    }
}
