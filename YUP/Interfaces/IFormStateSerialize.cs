using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Ca.Magrathean.Yup.Interfaces
{
    public interface IFormStateSerialize
    {
        void SaveFormState();
        void LoadFormState();

        bool FormVisible { get; set; }
        Point FormLocation { get; set; }
        Size FormSize { get; set; }
        FormWindowState FormWindowState { get; set; }
    }
}
