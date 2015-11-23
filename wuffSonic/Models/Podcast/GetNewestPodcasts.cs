using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetNewestPodcastsResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "newestPodcasts")]
        public NewestPodcasts newestPodcasts { get; set; }
    }
    public class NewestPodcasts
    {
        [XmlElement(ElementName = "episode")]
        public Episode[] episode { get; set; }
    }
    public class GetNewestPodcasts : Request
    {
        /// <summary>
        /// Returns the most recently published Podcast episodes.
        /// </summary>
        /// <param name="count">The maximum number of episodes to return.</param>
        public GetNewestPodcasts(string count = "20")
           : base(nameof(count), count)
        {

        }
        public GetNewestPodcastsResponse Response
        {
            get
            {
                return (GetNewestPodcastsResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetNewestPodcasts.view";
            }
        }
    }
}

