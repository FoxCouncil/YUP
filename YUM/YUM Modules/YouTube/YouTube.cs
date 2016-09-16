using System;
using System.Collections.Generic;
using System.Text;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Ca.Magrathean.Yup.Yum;
using System.Web;

namespace YouTubeYUM
{
    public class YouTube : IModule
    {
        #region Private Fields
        // private static YouTube _instance;

        internal YouTubeService YT;

        private string module_name;
        private string module_author;
        private string module_version;
        private string module_company;
        private Uri module_link;

        private IModuleHost module_host;

        // Developer tags
        public const string ClientID    = "ytapi-MagratheanTechno-YUP-e7t8ih3h-0";
        public const string DeveloperID = "AI39si5nPQ1e9ptr-rOm_eKnr9_oSmcHW12_KBfaxb3AJf6CaCxxe9b3gFgl4MsKWYFRCW9hdmZOgb-UiwHbSJ7hR5A9bzop7g";

        // FLV Location
        public const string FLVURL = "http://youtube.com/get_video?";

        // Data feeds
        public const string VideoEntryFeed = "http://gdata.youtube.com/feeds/api/videos/";

        public const string VideoIDQueryString = "video_id=";
        public const string TVarQueryString = "&t=";
        public const string LVarQueryString = "&l=";
        #endregion

        #region Constructors
        public YouTube()
        {
            module_name     = "YouTube";
            module_author   = "Fox Diller";
            module_version  = "1.0";
            module_company  = "Magrathean Technologies";
            module_link     = new Uri("http://magrathean.ca");
        }
        #endregion

        #region IModule Members
        public string Name
        {
            get
            {
                return module_name;
            }
            set
            {
                module_name = value;
            }
        }

        public string Author
        {
            get
            {
                return module_author;
            }
            set
            {
                module_author = value;
            }
        }

        public string Company
        {
            get
            {
                return module_company;
            }
            set
            {
                module_company = value;
            }
        }

        public Uri Link
        {
            get
            {
                return module_link;
            }
            set
            {
                module_link = value;
            }
        }

        public string Version
        {
            get
            {
                return module_version;
            }
            set
            {
                module_version = value;
            }
        }

        public IModuleHost Host
        {
            get
            {
                return module_host;
            }
            set
            {
                module_host = value;
            }
        }

        public System.Drawing.Icon ModuleIcon
        {
            get
            {
                return Properties.Resources.YouTube;
            }
        }

        public void Initialize()
        {
            YT = new YouTubeService("YUP", ClientID, DeveloperID);
        }

        public IFLV[] Search(string pattern)
        {
            YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);

            foreach (string keyword in pattern.Split(' '))
            {
                AtomCategory cat = new AtomCategory(Helpers.URLEscapeString(keyword), YouTubeNameTable.KeywordSchema);

                query.Categories.Add(new QueryCategory(cat));
            }

            query.NumberToRetrieve = 10;

            YouTubeFeed videoFeed = YT.Query(query);

            if (videoFeed.TotalResults != 0)
            {
                int total = 0;

                if (videoFeed.TotalResults > query.NumberToRetrieve)
                {
                    total = 10;
                }
                else
                {
                    total = videoFeed.TotalResults;
                }

                IFLV[] results = new IFLV[total];

                for (int i = 0; i < total; i++)
                {
                    if (videoFeed.TotalResults == i)
                    {
                        break;
                    }

                    YouTubeEntry yte = videoFeed.Entries[i] as YouTubeEntry;

                    if (yte != null)
                    {
                    	results[i] = new YouTubeFLV(yte, this);
                    }
                    else
                    {
                        break;
                    }
                }

                return results;
            }
            else
            {
                return null;
            }
        }

        public IFLV FetchURL(Uri url)
        {
            if (CheckURLFormat(url))
            {
                string videoID = ParseVideoID(url);

                if (videoID != "ERROR")
                {
                    return new YouTubeFLV((YouTubeEntry)YT.Get(VideoEntryFeed + videoID), this);
                }
                else
                {
                    return new YouTubeFLV(true);
                }
            }
            else
            {
                return new YouTubeFLV(true);
            }
        }

        public IFLV FetchVideoByID(string videoID)
        {
            return new YouTubeFLV((YouTubeEntry)YT.Get(VideoEntryFeed + videoID), this);
        }

        public IFLV GetRandom()
        {
            throw new NotImplementedException();
        }

        public bool CheckURL(string URL)
        {
            try
            {
                Url youTubeURLCheck = new Url(URL);

                if (youTubeURLCheck.Host.Contains("youtube.com"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            YT = null;
        }
        #endregion

        #region Utility Methods
        public bool CheckURLFormat(Uri urlToCheck)
        {
            if ((urlToCheck.Host.ToLower()).Contains("youtube.com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ParseVideoID(Uri youtubeUri)
        {
            if (youtubeUri.Host.Contains("youtube.com"))
            {
                if (youtubeUri.PathAndQuery.Contains("/v/"))
                {
                    return youtubeUri.PathAndQuery.Substring(youtubeUri.PathAndQuery.IndexOf("/v/") + 3, 11);
                }
                else if (youtubeUri.PathAndQuery.Contains("video_id="))
                {
                    return youtubeUri.PathAndQuery.Substring(youtubeUri.PathAndQuery.IndexOf("video_id=") + 9, 11);
                }
                else if (youtubeUri.PathAndQuery.Contains("v="))
                {
                    return youtubeUri.PathAndQuery.Substring(youtubeUri.PathAndQuery.IndexOf("v=") + 2, 11);
                }
            }

            return "ERROR";
        }
        #endregion

        public override string ToString()
        {
            return this.Name;
        }
    }
}
