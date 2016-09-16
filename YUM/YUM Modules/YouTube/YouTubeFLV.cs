using System;
using System.Collections.Generic;
using System.Text;
using Ca.Magrathean.Yup.Yum;
using Google.GData.YouTube;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace YouTubeYUM
{
    public enum YouTubeFLVType
    {
        SD,
        HD,
        RHD
    }

    public class YouTubeFLV : IFLV
    {
        #region Public Constants
        public const string FLVURL = "http://youtube.com/get_video?";
        public const string VideoIDQueryString = "video_id=";
        public const string TVarQueryString = "&t=";
        public const string LVarQueryString = "&l=";
        public const string HDQueryString = "&fmt=";
        // public const string RHDQueryString = "&fmt=22";
        #endregion

        #region Private Fields
        private bool? flv_hd = null;
        private bool flv_failed;
        private string flv_failed_reason;
        private YouTubeEntry yte;
        private IModule youTubeModule;
        private bool m_trueHD = false;
        private int m_currentQuality;
        Dictionary<string, int> m_formats = new Dictionary<string, int>(); 
        #endregion

        #region Constructors
        /// <summary>
        /// Create a YouTube IFLV object
        /// </summary>
        /// <param name="title">The title of the FLV</param>
        /// <param name="author">The author of the FLV</param>
        /// <param name="url">The URL of the FLV file</param>
        /// <param name="thumbnail">The URL of the thumbnail</param>
        public YouTubeFLV(YouTubeEntry yte, YouTube module)
        {
            this.yte = yte;
            this.youTubeModule = module;

            m_formats.Add("Quality1080p", 37);
            m_formats.Add("Quality720p", 22);
            m_formats.Add("Quality480p", 35);
            m_formats.Add("Quality360p", 34);
            m_formats.Add("Quality270p", 18);
        }

        /// <summary>
        /// Create a basic IFLV object, where the resulting creation failed.
        /// </summary>
        /// <param name="failed">True if failed, false if successful.</param>
        public YouTubeFLV(bool failed)
        {
            this.flv_failed = failed;
            this.flv_failed_reason = "Unknown Failure";
        }

        /// <summary>
        /// Create a basic IFLV object, where the resulting creation failed and the
        /// reason for that failure.
        /// </summary>
        /// <param name="failed">True if failed, false if successful.</param>
        /// <param name="reason">The reason for the failure.</param>
        public YouTubeFLV(bool failed, string reason)
        {
            this.flv_failed = failed;
            this.flv_failed_reason = reason;
        }
        #endregion

        #region IFLV Members
        public string Title
        {
            get
            {
                return yte.Title.Text;
            }
        }

        public string Author
        {
            get
            {
                return yte.Authors[0].Name;
            }
        }

        public string VideoID
        {
            get
            {
                return ExtractVideoID(yte.AlternateUri.ToString());
            }
        }

        public string[] Tags
        {
            get
            {
                return yte.Media.Keywords.Value.Split(new string[] { ", " }, StringSplitOptions.None);
            }
        }

        public Uri URL
        {
            get
            {
                return FetchFLVURL(yte.AlternateUri.ToString(), YouTubeFLVType.SD);
            }
        }

        public bool HDEnabled
        {
            get
            {
                if (flv_hd == null)
                {
                    string vid;
                    string l;
                    string t;
                    string error;

                    GetMainURL(yte.AlternateUri.ToString(), out vid, out l, out t, out error);

                    if (error != string.Empty)
                    {
                        MessageBox.Show(error);

                        return false;
                    }
                    else
                    {
                    }

                    this.flv_hd = CheckForHD(FLVURL + VideoIDQueryString + vid + LVarQueryString + l + TVarQueryString + t);
                }

                return flv_hd.Value;
            }
        }

        public Uri HDURL
        {
            get
            {
                return FetchFLVURL(yte.AlternateUri.ToString(), YouTubeFLVType.HD);
            }
        }

        public Uri ThumbnailImage
        {
            get
            {
                return new Uri(yte.Media.Thumbnails[0].Attributes["url"].ToString());
            }
        }

        public bool Failed
        {
            get
            {
                return flv_failed;
            }
        }

        public string FailedReason
        {
            get
            {
                return flv_failed_reason;
            }
        }


        public TimeSpan Length
        {
            get
            {
                return new TimeSpan(0, 0, 0, int.Parse(yte.Duration.Seconds));
            }
        }

        public int ViewCount
        {
            get
            {
                if (yte.Statistics == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(yte.Statistics.ViewCount);
                }
            }
        }

        public IModule Module
        {
            get
            {
                return youTubeModule;
            }
        }
        #endregion

        #region Helper Methods
        private string ExtractVideoID(string url)
        {
            // http://www.youtube.com/watch?v=the0KZLEacs
            return url.Substring(url.IndexOf('=') + 1, 11);
        }

        private Uri FetchFLVURL(string p, YouTubeFLVType flvType)
        {
            string vid;
            string l;
            string t;
            string error;

            GetMainURL(p, out vid, out l, out t, out error);

            if (error != string.Empty)
            {
                flv_failed_reason = error;
                return null;
            }
            else
            {
                Uri returnURL = null;

                switch (flvType)
                {
                    case YouTubeFLVType.SD:
                        returnURL = new Uri(FLVURL + VideoIDQueryString + vid + LVarQueryString + l + TVarQueryString + t);
                    break;

                    case YouTubeFLVType.HD:
                        returnURL = new Uri(FLVURL + VideoIDQueryString + vid + LVarQueryString + l + TVarQueryString + t + HDQueryString + m_currentQuality.ToString());
                    break;
                }

                return returnURL;
            }
        }

        private static void GetMainURL(string p, out string vid, out string l, out string t, out string error)
        {
            string url = p;

            string buffer;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US) AppleWebKit/530.5 (KHTML, like Gecko) Chrome/2.0.172.8 Safari/530.5";

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());

            try
            {
                buffer = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception exp)
            {
                sr.Close();
                buffer = "Error: " + exp.Message;
            }

            vid = l = t = error = string.Empty;

            if (buffer.IndexOf("Error:") < 0)
            {
                int start = 0, end = 0;
                string startTag = "'SWF_ARGS': {";
                string endTag = "},";

                start = buffer.IndexOf(startTag, StringComparison.CurrentCultureIgnoreCase);

                if (start == -1)
                {
                    string errorTagStart = "<div id=\"error-box\" class=\"errorBox\">";
                    string errorTagEnd = "</div>";

                    int errorStart = buffer.IndexOf(errorTagStart, StringComparison.CurrentCultureIgnoreCase);

                    if (errorStart == -1)
                    {
                        MessageBox.Show("Something wierd has happened!");
                        error = "Something wierd has happened!";
                        return;
                    }
                    else
                    {
                        int errorEnd = buffer.IndexOf(errorTagEnd, errorStart, StringComparison.CurrentCultureIgnoreCase);
                        error = buffer.Substring(errorStart + errorTagStart.Length, errorEnd - (errorStart + errorTagStart.Length));

                        error = error.Replace("\t", string.Empty).Replace("\n", string.Empty);

                        return;
                    }
                }
                else
                {
                    end = buffer.IndexOf(endTag, start, StringComparison.CurrentCultureIgnoreCase);
                    string str = buffer.Substring(start + startTag.Length, end - (start + startTag.Length));

                    Dictionary<string, string> ytVideoData = new Dictionary<string, string>();

                    string[] videoData = Regex.Split(str, ", ");

                    foreach (string data in videoData)
                    {
                        string[] keyValueSplit = data.Split(':');

                        if (keyValueSplit.Length > 1)
                        {
                            ytVideoData.Add(keyValueSplit[0].Replace("\"", "").Trim(), keyValueSplit[1].Replace("\"", "").Trim());
                        }
                    }

                    vid = ytVideoData["video_id"];
                    l = ytVideoData["length_seconds"];
                    t = ytVideoData["t"];

                    //vid = str.Substring(str.IndexOf("video_id"), str.IndexOf("&", str.IndexOf("video_id")) - str.IndexOf("video_id"));
                    //l = str.Substring(str.IndexOf("&l"), str.IndexOf("&", str.IndexOf("&l") + 1) - str.IndexOf("&l"));
                    //t = str.Substring(str.IndexOf("&t"), str.IndexOf("&", str.IndexOf("&t") + 1) - str.IndexOf("&t"));
                    //string title = str.Substring(str.IndexOf("&title=") + 7);
                    //title = title.Substring(0, title.Length - 1);
                    //vid = vid.Remove(0, 9);
                    //l = l.Remove(0, 3);
                    //t = t.Remove(0, 3);
                }
            }
            else
            {
                error = buffer;
            }
        }

        

        private bool CheckForHD(string url)
        {
            foreach (string format in m_formats.Keys)
            {
                //Create a request for the URL. 
                WebRequest request = WebRequest.Create(url + HDQueryString + m_formats[format].ToString());
                request.Proxy = null;

                try
                {
                    //Get the response. 
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        m_currentQuality = m_formats[format];

                        return true;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return false;
        }
        #endregion
    }
}
