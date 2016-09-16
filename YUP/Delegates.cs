using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ca.Magrathean.Yup
{
    public delegate void PlayerControlVolumeChanged(int volume);
    public delegate void PlayerControlVideoStateChanged(VideoState vs);
    public delegate void PlayerControlVideoPlayheadUpdateDelegate(int currentTime, int totalTime);
    public delegate void PlayerControlVideoDownloadUpdateDelegate(float bytesLoaded, float bytesTotal);
    public delegate void YUPFormMinimized(Form formMinimized);
    public delegate void YUPFormMaximized(Form formMaximized);
    public delegate void YUPFormRestored(Form formRestored);
}
