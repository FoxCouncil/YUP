using System;

namespace Ca.Magrathean.Yup
{
    /// <summary>
    /// The current video state of YUP.
    /// </summary>
    public enum VideoState
    {
        NoVideo,
        ConnectionError,
        Loaded,
        Buffering,
        Playing,
        Stopped,
        Paused,
        Rewinding,
        Seeking,
        Complete,
        Loading
    }

    /// <summary>
    /// How YUP is displayed on the users window manager.
    /// </summary>
    public enum YUPDisplay
    {
        Taskbar,
        SystemTray,
        Both
    }
}