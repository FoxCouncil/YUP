using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ca.Magrathean.Yup
{
    struct FFMPEGSettings
    {
        const string m_tempFileExtension = ".temp";

        #region Private Member Variables
        private int? m_audioBitrate;
        private AudioCodec m_forceAudioCodec;
        private bool m_disableAudio;
        private AudioSampleRates m_audioSamplingRate;
        private string m_aspectRatio;
        private int? m_audioSyncMethod;

        private int? m_videoBitrate;
        private int? m_videoBitrateTolerance;
        private int? m_videoNumberOfBFrames;

        private bool? m_videoFrameChoiceStrategy;
        private int? m_rateControlBufferSize;

        private int? m_cropBottom;
        private int? m_cropLeft;
        private int? m_cropRight;
        private int? m_cropTop;

        private bool? m_deinterlace;

        private FileFormat m_forceFileFormat;
        private string m_inputFilename;

        private int? m_maximumBitrateTolerance;
        private int? m_minimumBitrateTolerance;

        private string m_outputFilename;

        private int? m_passes;

        private PixelFormat m_videoPixelFormat;

        private VideoCodec m_forceVideoCodec;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new FFMPEG Settings object.
        /// </summary>
        /// <param name="inputFilename">Input Filename</param>
        /// <param name="outputFilename">Output Filename</param>
        public FFMPEGSettings(string folder, string filename)
        {
            m_audioBitrate = null;
            m_forceAudioCodec = AudioCodec.Nothing;
            m_disableAudio = false;
            m_audioSamplingRate = AudioSampleRates.Nothing;
            m_aspectRatio = null;
            m_audioSyncMethod = null;

            m_videoBitrate = null;
            m_videoBitrateTolerance = null;
            m_videoNumberOfBFrames = null;

            m_videoFrameChoiceStrategy = null;
            m_rateControlBufferSize = null;

            m_cropBottom = null;
            m_cropLeft = null;
            m_cropRight = null;
            m_cropTop = null;

            m_deinterlace = null;

            m_forceFileFormat = FileFormat.Nothing;
            m_inputFilename = folder + filename + m_tempFileExtension;

            m_maximumBitrateTolerance = null;
            m_minimumBitrateTolerance = null;

            m_outputFilename = folder + filename;

            m_passes = null;

            m_videoPixelFormat = PixelFormat.Nothing;

            m_forceVideoCodec = VideoCodec.Nothing;
        }
        #endregion

        #region Public Override Methods
        public override string ToString()
        {
            string extension = ".avi";

            StringBuilder args = new StringBuilder();

            args.AppendFormat("-i \"{0}\"", m_inputFilename);

            if (m_audioBitrate != null)
            {
                args.AppendFormat(" -ab {0}", m_audioBitrate.Value);
            }

            if (m_forceAudioCodec != AudioCodec.Nothing)
            {
                args.AppendFormat(" -acodec {0}", m_forceAudioCodec.ToString());
            }

            if (m_disableAudio)
            {
                args.AppendFormat(" -an");
            }

            if (m_audioSamplingRate != AudioSampleRates.Nothing)
            {
                args.AppendFormat(" -ar {0}", m_audioSamplingRate);
            }

            if (m_forceFileFormat != FileFormat.Nothing)
            {
                args.AppendFormat(" -f {0}", m_forceFileFormat.ToString());

                switch (m_forceFileFormat)
                {
                    case FileFormat.ac3:
                        extension = ".ac3";
                    break;

                    case FileFormat.avi:
                        extension = ".avi";
                    break;

                    case FileFormat.dv:
                        extension = ".dv";
                    break;

                    case FileFormat.flv:
                        extension = ".flv";
                    break;

                    case FileFormat.mov:
                        extension = ".mov";
                    break;

                    case FileFormat.mp3:
                        extension = ".mp3";
                    break;

                    case FileFormat.mpeg:
                        extension = ".mpg";
                    break;
                }
            }

            if (m_forceVideoCodec != VideoCodec.Nothing)
            {
                args.AppendFormat(" -vcodec {0}", m_forceVideoCodec.ToString());
            }


            args.AppendFormat(" \"{0}{1}\"", m_outputFilename, extension);


            return args.ToString();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Set audio bitrate in bit/s ( default = 64k ).
        /// </summary>
        public int? AudioBitrate
        {
            get { return m_audioBitrate; }
            set { m_audioBitrate = value; }
        }

        /// <summary>
        /// Force audio codec.
        /// </summary>
        public AudioCodec ForceAudioCodec
        {
            get { return m_forceAudioCodec; }
            set { m_forceAudioCodec = value; }
        }

        /// <summary>
        /// Disable audio.
        /// </summary>
        public bool DisableAudio
        {
            get { return m_disableAudio; }
            set { m_disableAudio = value; }
        }

        /// <summary>
        /// Set audio sampling frequency in Hz ( default = 44100 ). 
        /// </summary>
        public AudioSampleRates AudioSamplingRate
        {
            get { return m_audioSamplingRate; }
            set { m_audioSamplingRate = value; }
        }

        /// <summary>
        /// Set aspect ratio ( 4:3, 16:9, 1.3333, 1.7777 ).
        /// </summary>
        public string AspectRatio
        {
            get { return m_aspectRatio; }
            set { m_aspectRatio = value; }
        }

        /// <summary>
        /// Audio sync method.
        /// Audio will be stretched or squeezed to match the timestamps. The parameter is the maximum samples per second by which the audio is changed.
        /// AudioSyncMethod = 1 is a special case where only the start of the audio stream is corrected without any later correction. 
        /// </summary>
        public int? AudioSyncMethod
        {
            get { return m_audioSyncMethod; }
            set { m_audioSyncMethod = value; }
        }

        /// <summary>
        /// Set video bitrate in bit/s ( default = 200000 ).
        /// </summary>
        public int? VideoBitrate
        {
            get { return m_videoBitrate; }
            set { m_videoBitrate = value; }
        }

        /// <summary>
        /// Set video bitrate tolerance in bits/s ( default 4000k ).
        /// Has a minimum value of target_bitrate / target_framerate.
        /// In 1-pass mode, bitrate tolerance specifies how far ratecontrol is willing to deviate from the target average bitrate value.
        /// Lowering tolerance too much has an adverse effect on quality. 
        /// </summary>
        public int? VideoBitrateTolerance
        {
            get { return m_videoBitrateTolerance; }
            set { m_videoBitrateTolerance = value; }
        }

        /// <summary>
        /// Set number of B-frames ( supported for MPEG-1, MPEG-2 and MPEG-4 ).
        /// </summary>
        public int? VideoNumberOfBFrames
        {
            get { return m_videoNumberOfBFrames; }
            set { m_videoNumberOfBFrames = value; }
        }

        /// <summary>
        /// Strategy to choose between I/P/B-frames.
        /// </summary>
        public bool? VideoFrameChoiceStrategy
        {
            get { return m_videoFrameChoiceStrategy; }
            set { m_videoFrameChoiceStrategy = value; }
        }

        /// <summary>
        /// Set rate control buffer size ( in bits ).
        /// </summary>
        public int? RateControlBufferSize
        {
            get { return m_rateControlBufferSize; }
            set { m_rateControlBufferSize = value; }
        }

        /// <summary>
        /// Set bottom crop band size ( in pixels ). 
        /// </summary>
        public int? CropBottom
        {
            get { return m_cropBottom; }
            set { m_cropBottom = value; }
        }

        /// <summary>
        /// Set left crop band size ( in pixels ).
        /// </summary>
        public int? CropLeft
        {
            get { return m_cropLeft; }
            set { m_cropLeft = value; }
        }

        /// <summary>
        /// Set right crop band size ( in pixels ). 
        /// </summary>
        public int? CropRight
        {
            get { return m_cropRight; }
            set { m_cropRight = value; }
        }

        /// <summary>
        ///  Set top crop band size ( in pixels ). 
        /// </summary>
        public int? CropTop
        {
            get { return m_cropTop; }
            set { m_cropTop = value; }
        }

        /// <summary>
        /// Deinterlace pictures. 
        /// </summary>
        public bool? Deinterlace
        {
            get { return m_deinterlace; }
            set { m_deinterlace = value; }
        }

        /// <summary>
        /// Force file format.
        /// </summary>
        public FileFormat ForceFileFormat
        {
            get { return m_forceFileFormat; }
            set { m_forceFileFormat = value; }
        }

        /// <summary>
        /// Input file name.
        /// </summary>
        public string InputFilename
        {
            get { return m_inputFilename; }
            set { m_inputFilename = value; }
        }

        /// <summary>Set maximum video bitrate tolerance ( in bit/s ).</summary>
        public int? MaximumBitrateTolerance
        {
            get { return m_maximumBitrateTolerance; }
            set { m_maximumBitrateTolerance = value; }
        }

        /// <summary>Set minimum video bitrate tolerance ( in bit/s ).</summary>
        public int? MinimumBitrateTolerance
        {
            get { return m_minimumBitrateTolerance; }
            set { m_minimumBitrateTolerance = value; }
        }

        /// <summary>Ouput file name.</summary>
        public string OutputFilename
        {
            get { return m_outputFilename; }
            set { m_outputFilename = value; }
        }

        /// <summary>Select the pass number ( 1 or 2 ). The statistics of the video are recorded in the first pass and the video is generated at the exact requested bitrate in the second pass.</summary>
        public int? Passes
        {
            get { return m_passes; }
            set { m_passes = value; }
        }

        /// <summary>Set pixel format.</summary>
        public PixelFormat VideoPixelFormat
        {
            get { return m_videoPixelFormat; }
            set { m_videoPixelFormat = value; }
        }

        /// <summary>Force video codec.</summary>
        public VideoCodec ForceVideoCodec
        {
            get { return m_forceVideoCodec; }
            set { m_forceVideoCodec = value; }
        }

        /// <summary>Get the parsed Arguments for the settings object.</summary>
        public string Arguments
        {
            get { return ToString(); }
        }
        #endregion

        #region Enums
        public enum AudioSampleRates
        {
            /// <summary>8,000Hz - Telephone Audio Quality</summary>
            Rate_8000_Hz = 8000,
            /// <summary>11,025Hz - Voice Audio Quality</summary>
            Rate_11025_Hz = 11025,
            /// <summary>16,000Hz - VOIP/Skype Audio Quality</summary>
            Rate_16000_Hz = 16000,
            /// <summary>22,050Hz - Half Audio CD Quality</summary>
            Rate_22050_Hz = 22050,
            /// <summary>44,100Hz - Audio CD Quality</summary>
            Rate_44100_Hz = 44100,
            /// <summary>48,000Hz - DVD Audio Quality</summary>
            Rate_48000_Hz = 48000,
            /// <summary>96,000Hz - Studio Audio Quality</summary>
            Rate_96000_Hz = 96000,
            /// <summary>No audio sampling change.</summary>
            Nothing
        }

        public enum VideoCodec
        {
            /// <summary>Copy raw codec data as is.</summary>
            copy,
            /// <summary>DV Video</summary>
            dvvideo,
            /// <summary>FFV1 lossless video codec</summary>
            ffv1,
            /// <summary>H.264</summary>
            libx264,
            /// <summary>MPEG-2 Video</summary>
            mpeg2video,
            /// <summary>RAW Video</summary>
            rawvideo,
            /// <summary>XviD ( MPEG-4 Part 2 )</summary>
            xvid,
            /// <summary>Do Nothing</summary>
            Nothing
        }

        public enum AudioCodec
        {
            /// <summary>AC-3 ( Dolby Digital )</summary>
            ac3,
            /// <summary>Copy raw codec data as is.</summary>
            copy,
            /// <summary>AAC-LC</summary>
            libfaac,
            /// <summary>MPEG Audio Layer II</summary>
            mp2,
            /// <summary>MPEG Audio Layer III</summary>
            libmp3lame,
            /// <summary>Uncompressed PCM Signed 16-bit Little-Endian Audio</summary>
            pcm_s16le,
            /// <summary>Do Nothing</summary>
            Nothing
        }

        public enum FileFormat
        {
            /// <summary>Raw AC3</summary>
            ac3,
            /// <summary>AVI</summary>
            avi,
            /// <summary>DV</summary>
            dv,
            /// <summary>Flash Video</summary>
            flv,
            /// <summary>GXF ( General eXchange Format )</summary>
            gxf,
            /// <summary>Raw H.264</summary>
            h264,
            /// <summary>MPEG-2 Video Elemetary Stream</summary>
            m2v,
            /// <summary>MPEG-4 Video Elemetary Stream</summary>
            m4v,
            /// <summary>QuickTime</summary>
            mov,
            /// <summary>MPEG Audio Layer II</summary>
            mp2,
            /// <summary>MPEG Audio Layer III</summary>
            mp3,
            /// <summary>MP4</summary>
            mp4,
            /// <summary>MPEG-1 System Stream</summary>
            mpeg,
            /// <summary>MPEG-2 Transport Stream</summary>
            mpegts,
            /// <summary>RAW Video</summary>
            rawvideo,
            /// <summary>MPEG-2 Program Stream</summary>
            vob,
            /// <summary>WAV</summary>
            wav,
            /// <summary>Do Nothing</summary>
            Nothing
        }

        public enum PixelFormat
        {
            yuv420p, 
            yuv422p, 
            yuv444p,
            yuv422, 
            yuv410p, 
            yuv411p, 
            yuvj420p, 
            yuvj422p, 
            yuvj444p, 
            rgb24, 
            bgr24, 
            rgba32, 
            rgb565, 
            rgb555, 
            gray, 
            monow,
            monob,
            pal8,
            /// <summary>Do Nothing</summary>
            Nothing
        }
        #endregion
    }
}
