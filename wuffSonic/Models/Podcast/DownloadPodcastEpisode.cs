using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class DownloadPodcastEpisodeResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class DownloadPodcastEpisode : Request<DownloadPodcastEpisodeResponse>
    {
        /// <summary>
        /// Request the server to start downloading a given Podcast episode. 
        /// Note: The user must be authorized for Podcast administration (see Settings > Users > User is allowed to administrate Podcasts).
        /// </summary>
        /// <param name="id">The ID of the Podcast episode to download.</param>
        public DownloadPodcastEpisode(string id)
           : base(nameof(id), id)
        {

        }
        public DownloadPodcastEpisodeResponse Response
        {
            get
            {
                return (DownloadPodcastEpisodeResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "DownloadPodcastEpisode.view";
            }
        }
    }
}

