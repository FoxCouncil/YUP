/* Copyright (c) 2006 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/
#define USE_TRACING

using System;
using System.Xml;
using System.IO; 
using System.Collections;
using Google.GData.Client;
using Google.GData.Extensions;

namespace Google.GData.YouTube {


    //////////////////////////////////////////////////////////////////////
    /// <summary>
    /// The gd:feedLink tag in the entry identifies the URL that allows 
    /// you to retrieve videos for the subscription.
    /// For one of the category tags in the entry, the scheme attribute
    /// value will be http://gdata.youtube.com/schemas/2007/subscriptiontypes.cat. 
    /// That tag's term attribute indicates whether the entry describes a 
    /// subscription to a channel (term="channel"), another user's 
    /// favorite videos list (term="favorites"), or to videos that match
    ///  specific keywords (term="query").
    /// If the subscription is to another user's channel or list of favorite videos, 
    /// the yt:username tag will identify the user who owns the channel or favorite video list.
    /// If the subscription is to a keyword query, the yt:queryString element will
    /// contain the subscribed-to query term.
    /// </summary>
    //////////////////////////////////////////////////////////////////////
    public class SubscriptionEntry : YouTubeBaseEntry
    {
        /// <summary>
        /// describes the subscription types for a subscription feed
        /// </summary>
        public enum SubscriptionType 
        {
            /// <summary>
            /// indicates a channel subscription
            /// </summary>
            channel,
            /// <summary>
            /// indicates a user favorites subscription
            /// </summary>
            favorites, 
            /// <summary>
            /// indicates a query based subscription
            /// </summary>
            query,
            /// <summary>
            /// indicates an unknown state
            /// </summary>
            unknown
        }

        /// <summary>
        /// Category used to label entries that are subscriptions
        /// </summary>
        public static AtomCategory SUBSCRIPTION_CATEGORY =
        new AtomCategory(YouTubeNameTable.KIND_SUBSCRIPTION, new AtomUri(BaseNameTable.gKind));

        /// <summary>
        /// Constructs a new YouTubeEntry instance
        /// </summary>
        public SubscriptionEntry()
        : base()
        {
            Tracing.TraceMsg("Created SubscriptionEntry");
            this.AddExtension(new UserName());
            this.AddExtension(new FeedLink());
            this.AddExtension(new QueryString());

            Categories.Add(SUBSCRIPTION_CATEGORY);
        }


        /// <summary>
        /// get's and set's the associated atom:category
        /// </summary>
        /// <returns></returns>
        public SubscriptionType Type
        {
            get
            {
                SubscriptionType t = SubscriptionType.unknown;

                foreach (AtomCategory category in this.Categories)
                {
                    if (category.Scheme == YouTubeNameTable.SubscriptionCategorySchema)
                    {
                        try
                        {
                            t = (SubscriptionType) Enum.Parse(typeof(SubscriptionType), category.Term, true);
                        } catch (ArgumentException)
                        {
                            t = SubscriptionType.unknown;
                        }
                    }
                }
                return t; 
            }
            set 
            {
                AtomCategory cat = null; 
                foreach (AtomCategory category in this.Categories)
                {
                    if (category.Scheme == YouTubeNameTable.SubscriptionCategorySchema)
                    {
                        cat = category;
                        break;
                    }
                }
                if (cat == null)
                {
                    cat = new AtomCategory();
                    this.Categories.Add(cat);
                }
                cat.Term = value.ToString();
                cat.Scheme = new AtomUri(YouTubeNameTable.SubscriptionCategorySchema);
            }
        }

          /// <summary>
        /// getter/setter for the feedlink subelement
        /// </summary>
        public FeedLink FeedLink 
        {
            get
            {
                return FindExtension(GDataParserNameTable.XmlFeedLinkElement, 
                                      BaseNameTable.gNamespace) as FeedLink;

            }
            set
            {
                ReplaceExtension(GDataParserNameTable.XmlFeedLinkElement,
                                BaseNameTable.gNamespace,
                                value);
            }
        }

        /// <summary>
        /// getter/setter for UserName subelement
        /// </summary>
        public string UserName 
        {
            get
            {
                return getYouTubeExtensionValue(YouTubeNameTable.UserName);
            }
            set
            {
                setYouTubeExtension(YouTubeNameTable.UserName,value);
            }
        }

        /// <summary>
        /// getter/setter for QueryString subelement
        /// </summary>
        public string QueryString 
        {
            get
            {
                return getYouTubeExtensionValue(YouTubeNameTable.QueryString);
            }
            set
            {
                setYouTubeExtension(YouTubeNameTable.QueryString,value);
            }
        }


    }
}



