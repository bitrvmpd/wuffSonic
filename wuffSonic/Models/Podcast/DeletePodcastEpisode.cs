﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class DeletePodcastEpisodeResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class DeletePodcastEpisode : Request
    {
        /// <summary>
        /// Deletes a Podcast episode. 
        /// Note: The user must be authorized for Podcast administration (see Settings > Users > User is allowed to administrate Podcasts).
        /// </summary>
        /// <param name="id">he ID of the Podcast episode to delete.</param>
        public DeletePodcastEpisode(string id)
           : base(nameof(id), id)
        {

        }
        public DeletePodcastEpisodeResponse Response
        {
            get
            {
                return (DeletePodcastEpisodeResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "DeletePodcastEpisode.view";
            }
        }
    }
}

