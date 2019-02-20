using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetUserResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "user")]
        public User user { get; set; }
    }
    public class User
    {
        [XmlAttribute(AttributeName = "username")]
        public string username { get; set; }
        [XmlAttribute(AttributeName = "email")]
        public string email { get; set; }
        [XmlAttribute(AttributeName = "scrobblingEnabled")]
        public string scrobblingEnabled { get; set; }
        [XmlAttribute(AttributeName = "adminRole")]
        public string adminRole { get; set; }
        [XmlAttribute(AttributeName = "settingsRole")]
        public string settingsRole { get; set; }
        [XmlAttribute(AttributeName = "downloadRole")]
        public string downloadRole { get; set; }
        [XmlAttribute(AttributeName = "uploadRole")]
        public string uploadRole { get; set; }
        [XmlAttribute(AttributeName = "playlistRole")]
        public string playlistRole { get; set; }
        [XmlAttribute(AttributeName = "coverArtRole")]
        public string coverArtRole { get; set; }
        [XmlAttribute(AttributeName = "commentRole")]
        public string commentRole { get; set; }
        [XmlAttribute(AttributeName = "podcastRole")]
        public string podcastRole { get; set; }
        [XmlAttribute(AttributeName = "streamRole")]
        public string streamRole { get; set; }
        [XmlAttribute(AttributeName = "jukeboxRole")]
        public string jukeboxRole { get; set; }
        [XmlAttribute(AttributeName = "shareRole")]
        public string shareRole { get; set; }
        [XmlElement(ElementName = "folder")]
        public string[] folder { get; set; }
    }
    public class GetUser : Request<GetUserResponse>
    {
        /// <summary>
        /// Get details about a given user, including which authorization roles and folder access it has. 
        /// Can be used to enable/disable certain features in the client, such as jukebox control.
        /// </summary>
        /// <param name="username"></param>
        public GetUser(string username)
           : base(nameof(username), username)
        {

        }
        public GetUserResponse Response
        {
            get
            {
                return (GetUserResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getUser";
            }
        }
    }
}

