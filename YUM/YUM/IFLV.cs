using System;
using System.Collections.Generic;
using System.Text;

namespace Ca.Magrathean.Yup.Yum
{
    /// <summary>
    /// This is the interface to implement to store details
    /// about a video that can play in YUP.
    /// </summary>
    public interface IFLV
    {
        /// <summary>
        /// The title of the video
        /// </summary>
        string Title
        {
            get;
        }

        /// <summary>
        /// The Author of the video
        /// </summary>
        string Author
        {
            get;
        }

        /// <summary>
        /// The Video ID
        /// </summary>
        string VideoID
        {
            get;
        }

        /// <summary>
        /// Tags related to the video.
        /// </summary>
        string[] Tags
        {
            get;
        }

        /// <summary>
        /// The URL for the FLV file
        /// </summary>
        Uri URL
        {
            get;
        }

        /// <summary>
        /// The URL for a high quality flash compatible file
        /// </summary>
        Uri HDURL
        {
            get;
        }

        /// <summary>
        /// A thumbnail image url
        /// </summary>
        Uri ThumbnailImage
        {
            get;
        }

        /// <summary>
        /// The Video's Length
        /// </summary>
        TimeSpan Length
        {
            get;
        }

        /// <summary>
        /// Is there a high quality version available.
        /// </summary>
        bool HDEnabled
        {
            get;
        }

        /// <summary>
        /// The request for this video failed.
        /// </summary>
        bool Failed
        {
            get;
        }

        /// <summary>
        /// The reason the request for this video failed.
        /// </summary>
        string FailedReason
        {
            get;
        }

        /// <summary>
        /// View count for this video
        /// </summary>
        int ViewCount
        {
            get;
        }

        IModule Module
        {
            get;
        }
    }
}
