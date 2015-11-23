using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class RefreshPodcastsResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class RefreshPodcasts : Request
    {
        /// <summary>
        /// Requests the server to check for new Podcast episodes. 
        /// Note: The user must be authorized for Podcast administration (see Settings > Users > User is allowed to administrate Podcasts).
        /// </summary>
        public RefreshPodcasts()
           : base()
        {

        }
        public RefreshPodcastsResponse Response
        {
            get
            {
                return (RefreshPodcastsResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "RefreshPodcasts.view";
            }
        }
    }
}

