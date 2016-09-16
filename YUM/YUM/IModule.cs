using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Ca.Magrathean.Yup.Yum
{
    /// <summary>
    /// YUP Plugin Interface
    /// Codename: YUM (Your Ultimate Modules)
    /// </summary>
    public interface IModule
    {
        #region Details
        string Name
        {
            get;
            set;
        }

        string Author
        {
            get;
            set;
        }

        string Company
        {
            get;
            set;
        }

        Uri Link
        {
            get;
            set;
        }

        string Version
        {
            get;
            set;
        }

        Icon ModuleIcon
        {
            get;
        }
        #endregion

        #region System
        IModuleHost Host
        {
            get;
            set;
        }
        #endregion

        void Initialize();
        void Dispose();

        #region Playback Methods
        IFLV[] Search(string pattern);
        IFLV FetchURL(Uri url);
        IFLV FetchVideoByID(string videoID);
        IFLV GetRandom();
        bool CheckURL(string URL);
        string ToString();
        #endregion
    }
}
