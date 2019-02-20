using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetPlaylistsResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "playlists")]
        public Playlists playlists { get; set; }
    }

    public class Playlists
    {
        [XmlElement(ElementName = "playlist")]
        public Playlist[] playlist { get; set; }
    }
    public class Playlist
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
        [XmlAttribute(AttributeName = "comment")]
        public string comment { get; set; }
        [XmlAttribute(AttributeName = "owner")]
        public string owner { get; set; }
        [XmlAttribute(AttributeName = "public")]
        public string isPublic { get; set; }
        [XmlAttribute(AttributeName = "songCount")]
        public string songCount { get; set; }
        [XmlAttribute(AttributeName = "duration")]
        public string duration { get; set; }
        [XmlAttribute(AttributeName = "created")]
        public string created { get; set; }
        [XmlAttribute(AttributeName = "coverArt")]
        public string coverArt { get; set; }
        [XmlElement(ElementName = "allowedUser")]
        public string[] allowedUser { get; set; }
        [XmlElement(ElementName = "entry")]
        public Entry[] entry { get; set; }
    }
    public class GetPlaylists : Request<GetPlaylistsResponse>
    {
        /// <summary>
        /// Returns all playlists a user is allowed to play.
        /// </summary>
        /// <param name="username">If specified, return playlists for this user rather than for the authenticated user. The authenticated user must have admin role if this parameter is used.</param>
        public GetPlaylists(string username = null)
           : base(nameof(username), username)
        {

        }
        public GetPlaylistsResponse Response
        {
            get
            {
                return (GetPlaylistsResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getPlaylists";
            }
        }
    }
}

