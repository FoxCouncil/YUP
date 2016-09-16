using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Ca.Magrathean.Yup.Flash;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Ca.Magrathean.Yup.Controls
{
    /// <summary>
    /// The main Shockwave Flash Player ActiveX control.
    /// </summary>
    [System.ComponentModel.DesignerCategory("code")]
    public class PlayerControl : AxShockwaveFlashObjects.AxShockwaveFlash
    {
        #region Constants
        const int           WM_RBUTTONDOWN              = 0x0204;
        const int           WM_LBUTTONDOWN              = 0x0201;
        const int           WM_LBUTTONDBLCLICK          = 0x0203;
        #endregion

        #region Private Member Variables
        // states
        private VideoState  m_currentFLVVideoState      = VideoState.NoVideo;
        private string      m_currentFLVURI             = string.Empty;
        private float       m_currentFLVTimeLength      = 0;
        private bool        m_currentFLVMuteState       = false;
        private int         m_currentFLVMuteVolume      = 0;
        private float       m_currentFLVVolume          = 0.6f;
        private bool        m_swfReady                  = false;
        private float       m_bytesLoaded               = 0.0f;
        private float       m_bytesTotal                = 0.0f;
            
        // proxy
        private ExternalInterfaceProxy m_flashProxy;
        #endregion

        #region Public Events
        // Events
        public event EventHandler MouseLeftClick;
        public event EventHandler MouseRightClick;
        public event EventHandler MouseLeftDoubleClick;
        public event PlayerControlVolumeChanged VolumeChanged;
        public event PlayerControlVideoStateChanged VideoStateChanged;
        public event PlayerControlVideoPlayheadUpdateDelegate PlayheadUpdate;
        public event PlayerControlVideoDownloadUpdateDelegate VideoProgress;
        #endregion

        #region Constructor
        public PlayerControl()
            : base()
        {
        }
        #endregion

        #region Public Methods
        public void Initialize(string SWFPath)
        {
            // This should keep things in check
            // The reason behind this call to 'ScaleMode', or it's string based bastard brother 'CtlScale'
            // Through missing hair, I have deduced that the great settings is 3, or 'NoScale'
            // Otherwise the video grows insanely big.
            this.ScaleMode = 3;

            m_flashProxy = new ExternalInterfaceProxy(this);
            m_flashProxy.ExternalInterfaceCall += new ExternalInterfaceCallEventHandler(flashProxy_ExternalInterfaceCall);

            this.Movie = SWFPath;
            this.Play();
        }
        #endregion

        #region Flash Event Handler
        private object flashProxy_ExternalInterfaceCall(object sender, ExternalInterfaceCallEventArgs e)
        {
            // Debug.WriteLine("Flash proxy called: " + e.FunctionCall.FunctionName);

            switch (e.FunctionCall.FunctionName)
            {
                /* Dispatched when the playhead is moved to the start of the video player because the autoRewind property is set to true. 
                 * When the autoRewound event is dispatched, the rewind event is also dispatched. */
                case "videoAutoRewoundEvent":
                {
                    if (VideoStateChanged != null)
                    {
                        // VideoStateChanged(VideoState.Rewinding);
                    }
                }
                break;

                /* Dispatched when the FLVPlayback instance enters the buffering state. 
                 * The FLVPlayback instance typically enters this state immediately after a call to the play() method or when the Play control is clicked, 
                 * before entering the playing state.
                 * 
                 * The stateChange event is also dispatched. */
                case "videoBufferingStateEvent":
                {
                    m_currentFLVVideoState = VideoState.Buffering;

                    if (VideoStateChanged != null)
                    {
                        VideoStateChanged(VideoState.Buffering);
                    }
                }
                break;

                /* Dispatched when playing completes because the player reached the end of the FLV file. 
                 * The component does not dispatch the event if you call the stop() or pause() methods or click the corresponding controls.
                 * 
                 * When the application uses progressive download, it does not set the totalTime property explicitly, 
                 * and it downloads an FLV file that does not specify the duration in the metadata. 
                 * The video player sets the totalTime property to an approximate total value before it dispatches this event.
                 * 
                 * The video player also dispatches the stateChange and stoppedStateEntered events. */
                case "videoCompleteEvent":
                {
                    m_currentFLVVideoState = VideoState.Complete;

                    if (VideoStateChanged != null)
                    {
                        VideoStateChanged(VideoState.Complete);
                    }
                }
                break;

                /* Dispatched when the location of the playhead moves forward by a call to the seek() method or by clicking the ForwardButton control. 
                 * 
                 * The FLVPlayback instance also dispatches playheadUpdate event. */
                case "videoFastForwardEvent":
                {
                }
                break;

                /* Dispatched when the player enters the paused state. 
                 * This happens when you call the pause() method or click the corresponding control and it also happens in some cases when the FLV file is loaded 
                 * and the autoPlay property is false (the state may be stopped instead). 
                 * 
                 * The stateChange event is also dispatched. */
                case "videoPauseStateEvent":
                {
                    m_currentFLVVideoState = VideoState.Paused;

                    if (VideoStateChanged != null)
                    {
                        VideoStateChanged(VideoState.Paused);
                    }
                }
                break;

                /* Dispatched while the FLV file is playing at the frequency specified by the playheadUpdateInterval property or when rewinding starts. 
                 * The component does not dispatch this event when the video player is paused or stopped unless a seek occurs. */
                case "videoPlayheadUpdateEvent":
                {
                    string playheadValueString = (string)e.FunctionCall.Arguments[0].ToString();

                    float playheadValue = float.Parse(playheadValueString);

                    if (PlayheadUpdate != null)
                    {
                        PlayheadUpdate((int)(playheadValue * 1000), (int)m_currentFLVTimeLength);
                    }
                }
                break;

                /* Dispatched when the playing state is entered. This may not occur immediately after the play() method is called or the corresponding control is clicked; 
                 * often the buffering state is entered first, and then the playing state.
                 * 
                 * The FLVPlayback instance also dispatches the stateChange event. */
                case "videoPlayingStateEvent":
                {
                    m_currentFLVVideoState = VideoState.Playing;

                    if (VideoStateChanged != null)
                    {
                        VideoStateChanged(VideoState.Playing);
                    }
                }
                break;

                /* Dispatched when an FLV file is loaded and ready to display. 
                 * It starts the first time you enter a responsive state after you load a new FLV file with the play() or load() method. 
                 * It starts only once for each FLV file that is loaded. */
                case "videoReadyEvent":
                {
                    m_currentFLVVideoState = VideoState.Loaded;

                    if (VideoStateChanged != null)
                    {
                        VideoStateChanged(VideoState.Loaded);
                    }
                }
                break;

                /* Dispatched when the location of the playhead moves backward by a call to seek() or when an autoRewind call is completed. 
                 * When an autoRewind call is completed, an autoRewound event is triggered first. */
                case "videoRewindEvent":
                {
                }
                break;

                /* Dispatched when the location of the playhead is changed by a call to seek() or by setting the playheadTime property or by using the SeekBar control. 
                 * The playheadTime property is the destination time.
                 * 
                 * The seeked event is of type VideoEvent and has the constant VideoEvent.SEEKED.
                 * 
                 * The FLVPlayback instance dispatches the rewind event when the seek is backward and the fastForward event when the seek is forward. 
                 * It also dispatches the playheadUpdate event.
                 * 
                 * For several reasons, the playheadTime property might not have the expected value immediately after you call one of the seek methods or set playheadTime to cause seeking. 
                 * First, for a progressive download, you can seek only to a keyframe, so a seek takes you to the time of the first keyframe after the specified time. 
                 * (When streaming, a seek always goes to the precise specified time even if the source FLV file doesn't have a keyframe there.) 
                 * Second, seeking is asynchronous, so if you call a seek method or set the playheadTime property, playheadTime does not update immediately. 
                 * To obtain the time after the seek is complete, listen for the seek event, which does not start until the playheadTime property has updated. */
                case "videoSeekedEvent":
                {
                }
                break;

                /* Dispatched when the playback state changes. When an autoRewind call is completed the stateChange event is dispatched with the rewinding state. 
                 * The stateChange event does not start until rewinding has completed.
                 * 
                 * This event can be used to track when playback enters or leaves unresponsive states such as in the middle of connecting, resizing, or rewinding. 
                 * The play(), pause(), stop() and seek() methods queue the requests to be executed when the player enters a responsive state. */
                case "videoStateChangeEvent":
                {
                    string videoState = e.FunctionCall.Arguments[0].ToString();
                    Debug.WriteLine(videoState);
                }
                break;

                /* Dispatched when entering the stopped state. 
                 * This happens when you call the stop() method or click the stopButton control. 
                 * It also happens, in some cases, if the autoPlay property is false (the state might become paused instead) when the FLV file is loaded. 
                 * The FLVPlayback instance also dispatches this event when the playhead stops at the end of the FLV file because it has reached the end of the timeline.
                 * 
                 * The FLVPlayback instance also dispatches the stateChange event. */
                case "videoStopStateEvent":
                {
                    m_currentFLVVideoState = VideoState.Stopped;

                    if (VideoStateChanged != null)
                    {
                        VideoStateChanged(VideoState.Stopped);
                    }
                }
                break;

                case "soundUpdateEvent":
                {
                    if (VolumeChanged != null)
                    {
                        VolumeChanged(Volume);
                    }
                }
                break;

                case "videoProgressEvent":
                {
                    m_bytesLoaded = float.Parse(e.FunctionCall.Arguments[0].ToString());
                    m_bytesTotal = float.Parse(e.FunctionCall.Arguments[1].ToString());

                    if (VideoProgress != null)
                    {
                        VideoProgress(m_bytesLoaded, m_bytesTotal);
                    }
                }
                break;

                case "videoMetaDataReceivedEvent":
                {
                    m_currentFLVTimeLength = float.Parse(e.FunctionCall.Arguments[0].ToString()) * 1000;
                }
                break;

                case "videoPlayerLoaded":
                {
                    m_swfReady = true;
                }
                break;
            }

            return null;
        }
        #endregion

        #region Player Methods
        public void ToggleMute()
        {
            m_currentFLVMuteState = !m_currentFLVMuteState;

            if (!m_currentFLVMuteState)
            {
                Volume = m_currentFLVMuteVolume;
                m_currentFLVMuteVolume = 0;
            }
            else
            {
                m_currentFLVMuteVolume = Volume;
                Volume = 0;
            }
        }

        public void LoadVideo(string uri)
        {
            if (uri != m_currentFLVURI)
            {
                m_currentFLVURI = uri;
                
                object returnCheck = m_flashProxy.Call("loadVideo", uri);

                if (returnCheck is AccessViolationException)
                {
                    YUP.Error(returnCheck as AccessViolationException);
                }
            }
        }

        public void PlayVideo()
        {
            m_flashProxy.Call("playVideo");
        }

        public void SeekVideo(float time)
        {
            m_flashProxy.Call("seekVideo", time);
        }

        public void TogglePause()
        {
            if (m_currentFLVVideoState == VideoState.Paused)
            {
                PlayVideo();
            }
            else if (m_currentFLVVideoState == VideoState.Playing)
            {
                PauseVideo();
            }
        }

        public void PauseVideo()
        {
            m_flashProxy.Call("pauseVideo");
        }

        public void StopVideo()
        {
            m_flashProxy.Call("stopVideo");
        }

        public void MaintainAspectRatio(bool maintaning)
        {
            m_flashProxy.Call("maintainVideoSizeRatio", maintaning);
        }

        internal void ResetSize(int controlPanelSize)
        {
            object returnCheck = m_flashProxy.Call("resetSize", controlPanelSize);

            if (returnCheck is AccessViolationException)
            {
                YUP.Error(returnCheck as AccessViolationException);
            }
        }

        internal void RewindVideo(bool value)
        {
            m_flashProxy.Call("rewindVideo", value);
        }

        #endregion

        #region Public Properties
        [Browsable(false)]
        public VideoState VideoState
        {
            get
            {
                return m_currentFLVVideoState;
            }
            set
            {
                m_currentFLVVideoState = value;

                if (VideoStateChanged != null)
                {
                    VideoStateChanged(VideoState.Loading);
                }
            }
        }

        /// <summary>
        /// Get's or set's the volume for the control.
        /// </summary>
        [Browsable(false)]
        public int Volume
        {
            get
            {
                return (int)(m_currentFLVVolume * 10);
            }
            set 
            {
                if (value > 0)
                {
                    float tempVol = value / 10.0f;
                    m_currentFLVVolume = tempVol;
                }
                else
                {
                    m_currentFLVVolume = 0.0f;
                }

                if (m_swfReady)
                {
                    float tempVol = 0;

                    if (value > 0)
                    {
                        tempVol = value / 10.0f;
                    }

                    m_flashProxy.Call("setVolume", tempVol);
                }
            }
        }

        [Browsable(false)]
        public bool MuteState
        {
            get 
            { 
                return m_currentFLVMuteState; 
            }
        }

        [Browsable(false)]
        public float BytesTotal
        {
            get 
            { 
                return m_bytesTotal; 
            }
        }

        [Browsable(false)]
        public float BytesLoaded
        {
            get 
            { 
                return m_bytesLoaded; 
            }
        }
        #endregion

        #region Override Public AX Control Properties
        [Browsable(false)]
        public override int AlignMode
        {
            get { return base.AlignMode; }
            set { base.AlignMode = value; }
        }

        [Browsable(false)]
        public override string AllowFullScreen
        {
            get { return base.AllowFullScreen; }
            set { base.AllowFullScreen = value; }
        }

        [Browsable(false)]
        public override string AllowNetworking
        {
            get { return base.AllowNetworking; }
            set { base.AllowNetworking = value; }
        }

        [Browsable(false)]
        public override string AllowScriptAccess
        {
            get { return base.AllowScriptAccess; }
            set { base.AllowScriptAccess = value; }
        }

        [Browsable(false)]
        public override int BackgroundColor
        {
            get { return base.BackgroundColor; }
            set { base.BackgroundColor = value; }
        }

        [Browsable(false)]
        public override string Base
        {
            get { return base.Base; }
            set { base.Base = value; }
        }

        [Browsable(false)]
        public override string BGColor
        {
            get { return base.BGColor; }
            set { base.BGColor = value; }
        }

        [Browsable(false)]
        public override string CtlScale
        {
            get { return base.CtlScale; }
            set { base.CtlScale = value; }
        }

        [Browsable(false)]
        public override bool DeviceFont
        {
            get { return base.DeviceFont; }
            set { base.DeviceFont = value; }
        }

        [Browsable(false)]
        public override bool EmbedMovie
        {
            get { return base.EmbedMovie; }
            set { base.EmbedMovie = value; }
        }

        [Browsable(false)]
        public override string FlashVars
        {
            get { return base.FlashVars; }
            set { base.FlashVars = value; }
        }

        [Browsable(false)]
        public override int FrameNum
        {
            get { return base.FrameNum; }
            set { base.FrameNum = value; }
        }

        [Browsable(false)]
        public override object InlineData
        {
            get { return base.InlineData; }
            set { base.InlineData = value; }
        }

        [Browsable(false)]
        public override bool Loop
        {
            get { return base.Loop; }
            set { base.Loop = value; }
        }

        [Browsable(false)]
        public override bool Menu
        {
            get { return base.Menu; }
            set { base.Menu = value; }
        }

        [Browsable(false)]
        public override string Movie
        {
            get { return base.Movie; }
            set { base.Movie = value; }
        }

        [Browsable(false)]
        public override string MovieData
        {
            get { return base.MovieData; }
            set { base.MovieData = value; }
        }

        [Browsable(false)]
        public override bool Playing
        {
            get { return base.Playing; }
            set { base.Playing = value; }
        }

        [Browsable(false)]
        public override bool Profile
        {
            get { return base.Profile; }
            set { base.Profile = value; }
        }

        [Browsable(false)]
        public override string ProfileAddress
        {
            get { return base.ProfileAddress; }
            set { base.ProfileAddress = value; }
        }

        [Browsable(false)]
        public override int ProfilePort
        {
            get { return base.ProfilePort; }
            set { base.ProfilePort = value; }
        }

        [Browsable(false)]
        public override int Quality
        {
            get { return base.Quality; }
            set { base.Quality = value; }
        }

        [Browsable(false)]
        public override string Quality2
        {
            get { return base.Quality2; }
            set { base.Quality2 = value; }
        }

        [Browsable(false)]
        public override int ReadyState
        {
            get { return base.ReadyState; }
        }

        [Browsable(false)]
        public override string SAlign
        {
            get { return base.SAlign; }
            set { base.SAlign = value; }
        }

        [Browsable(false)]
        public override int ScaleMode
        {
            get { return base.ScaleMode; }
            set { base.ScaleMode = value; }
        }

        [Browsable(false)]
        public override bool SeamlessTabbing
        {
            get { return base.SeamlessTabbing; }
            set { base.SeamlessTabbing = value; }
        }

        [Browsable(false)]
        public override string SWRemote
        {
            get { return base.SWRemote; }
            set { base.SWRemote = value; }
        }

        [Browsable(false)]
        public override int TotalFrames
        {
            get { return base.TotalFrames; }
        }

        [Browsable(false)]
        public override string WMode
        {
            get { return base.WMode; }
            set { base.WMode = value; }
        }
        #endregion

        #region Overrides
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLICK)
            {
                m.Result = IntPtr.Zero;

                if (MouseLeftDoubleClick != null)
                {
                    MouseLeftDoubleClick(this, new EventArgs());
                }

                return;
            }
            else if (m.Msg == WM_LBUTTONDOWN)
            {
                m.Result = IntPtr.Zero;

                if (MouseLeftClick != null)
                {
                    MouseLeftClick(this, new EventArgs());
                }

                return;
            }
            else if (m.Msg == WM_RBUTTONDOWN)
            {
                m.Result = IntPtr.Zero;

                if (MouseRightClick != null)
                {
                    MouseRightClick(this, new EventArgs());
                }

                return;
            }

            base.WndProc(ref m);
        }
        #endregion
    }
}
