using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class DeletePodcastChannelResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class DeletePodcastChannel : Request
    {
        /// <summary>
        /// Deletes a Podcast channel. 
        /// Note: The user must be authorized for Podcast administration (see Settings > Users > User is allowed to administrate Podcasts).
        /// </summary>
        /// <param name="id">The ID of the Podcast channel to delete.</param>
        public DeletePodcastChannel(string id)
           : base(nameof(id), id)
        {

        }
        public DeletePodcastChannelResponse Response
        {
            get
            {
                return (DeletePodcastChannelResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "DeletePodcastChannel.view";
            }
        }
    }
}

