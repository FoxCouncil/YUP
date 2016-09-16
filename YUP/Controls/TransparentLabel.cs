using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ca.Magrathean.Yup.Controls
{
    [System.ComponentModel.DesignerCategory("code")]
    public class TransparentLabel : Label
    {
        public TransparentLabel()
        {
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
                return parms;
            }
        }
    }
}
