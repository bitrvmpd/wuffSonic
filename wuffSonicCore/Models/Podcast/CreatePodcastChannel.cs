using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class CreatePodcastChannelResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class CreatePodcastChannel : Request<CreatePodcastChannelResponse>
    {
        /// <summary>
        /// Adds a new Podcast channel. 
        /// Note: The user must be authorized for Podcast administration (see Settings > Users > User is allowed to administrate Podcasts).
        /// </summary>
        /// <param name="url">The URL of the Podcast to add.</param>
        public CreatePodcastChannel(string url)
           : base(nameof(url), url)
        {

        }
        public CreatePodcastChannelResponse Response
        {
            get
            {
                return (CreatePodcastChannelResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "createPodcastChannel";
            }
        }
    }
}

