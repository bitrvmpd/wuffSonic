using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetIndexesResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "indexes")]
        public Indexes indexes { get; set; }

    }
    public class Indexes
    {
        [XmlAttribute(AttributeName = "lastModified")]
        public string lastModified { get; set; }

        [XmlAttribute(AttributeName = "ignoredArticles")]
        public string ignoredArticles { get; set; }
        [XmlElement(ElementName = "index")]
        public Index[] index { get; set; }
        [XmlElement(ElementName = "shortcut")]
        public Shortcut[] shortcut { get; set; }
        [XmlElement(ElementName = "child")]
        public Child[] child { get; set; }
    }
    public class Child
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "parent")]
        public string parent { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string title { get; set; }
        [XmlAttribute(AttributeName = "isDir")]
        public string isDir { get; set; }
        [XmlAttribute(AttributeName = "album")]
        public string album { get; set; }
        [XmlAttribute(AttributeName = "artist")]
        public string artist { get; set; }
        [XmlAttribute(AttributeName = "track")]
        public string track { get; set; }
        [XmlAttribute(AttributeName = "year")]
        public string year { get; set; }
        [XmlAttribute(AttributeName = "genre")]
        public string genre { get; set; }
        [XmlAttribute(AttributeName = "coverArt")]
        public string coverArt { get; set; }
        [XmlAttribute(AttributeName = "size")]
        public string size { get; set; }
        [XmlAttribute(AttributeName = "contentType")]
        public string contentType { get; set; }
        [XmlAttribute(AttributeName = "transcodedContentType")]
        public string transcodedContentType { get; set; }
        [XmlAttribute(AttributeName = "suffix")]
        public string suffix { get; set; }
        [XmlAttribute(AttributeName = "transcodedSuffix")]
        public string transcodedSuffix { get; set; }
        [XmlAttribute(AttributeName = "duration")]
        public string duration { get; set; }
        [XmlAttribute(AttributeName = "bitRate")]
        public string bitRate { get; set; }
        [XmlAttribute(AttributeName = "path")]
        public string path { get; set; }

    }
    public class Shortcut
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
    }
    public class Index
    {
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
        [XmlElement(ElementName = "artist")]
        public Artist[] artist { get; set; }
    }
    public class Album
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "userRating")]
        public string userRating { get; set; }
        [XmlAttribute(AttributeName = "averageRating")]
        public string averageRating { get; set; }
        [XmlAttribute(AttributeName = "parent")]
        public string parent { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string title { get; set; }
        [XmlAttribute(AttributeName = "isDir")]
        public string isDir { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
        [XmlAttribute(AttributeName = "coverArt")]
        public string coverArt { get; set; }
        [XmlAttribute(AttributeName = "songCount")]
        public string songCount { get; set; }
        [XmlAttribute(AttributeName = "created")]
        public string created { get; set; }
        [XmlAttribute(AttributeName = "starred")]
        public string starred { get; set; }
        [XmlAttribute(AttributeName = "duration")]
        public string duration { get; set; }
        [XmlAttribute(AttributeName = "artist")]
        public string artist { get; set; }
        [XmlAttribute(AttributeName = "artistId")]
        public string artistId { get; set; }
        [XmlElement(ElementName ="song")]
        public Song[] song { get; set; }
    }
    public class Artist
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
        [XmlAttribute(AttributeName = "starred")]
        public string starred { get; set; }
        [XmlAttribute(AttributeName = "coverArt")]
        public string coverArt { get; set; }
        [XmlAttribute(AttributeName = "albumCount")]
        public string albumCount { get; set; }
        [XmlElement(ElementName = "album")]
        public Album[] album { get; set; }
    }
    public class Song
    {
        [XmlAttribute(AttributeName ="id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "parent")]
        public string parent { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string title { get; set; }
        [XmlAttribute(AttributeName = "album")]
        public string album { get; set; }
        [XmlAttribute(AttributeName = "artist")]
        public string artist { get; set; }
        [XmlAttribute(AttributeName = "isDir")]
        public string isDi { get; set; }
        [XmlAttribute(AttributeName = "coverArt")]
        public string coverArt { get; set; }
        [XmlAttribute(AttributeName = "created")]
        public string created { get; set; }
        [XmlAttribute(AttributeName = "starred")]
        public string starred { get; set; }
        [XmlAttribute(AttributeName = "duration")]
        public string duration { get; set; }
        [XmlAttribute(AttributeName = "bitRate")]
        public string bitRate { get; set; }
        [XmlAttribute(AttributeName = "track")]
        public string track { get; set; }
        [XmlAttribute(AttributeName ="year")]
        public string year { get; set; }
        [XmlAttribute(AttributeName ="genre")]
        public string genre { get; set;}
        [XmlAttribute(AttributeName = "size")]
        public string size { get; set; }
        [XmlAttribute(AttributeName = "suffix")]
        public string suffix { get; set; }
        [XmlAttribute(AttributeName = "contentType")]
        public string contentType { get; set; }
        [XmlAttribute(AttributeName = "isVideo")]
        public string isVideo { get; set; }
        [XmlAttribute(AttributeName = "path")]
        public string path { get; set; }
        [XmlAttribute(AttributeName = "albumId")]
        public string albumId { get; set; }
        [XmlAttribute(AttributeName = "artistId")]
        public string artistId { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string type { get; set; }
    }

    public class GetIndexes : Request<GetIndexesResponse>
    {
        /// <summary>
        /// Returns an indexed structure of all artists.
        /// </summary>
        /// <param name="musicFolderId">If specified, only return artists in the music folder with the given ID</param>
        /// <param name="ifModifiedSince">If specified, only return a result if the artist collection has changed since the given time (in milliseconds since 1 Jan 1970)</param>
        public GetIndexes(string musicFolderId = null, string ifModifiedSince = null)
            : base(nameof(musicFolderId), musicFolderId,
                nameof(ifModifiedSince), ifModifiedSince)
        {
        }
        public GetIndexesResponse Response
        {
            get
            {
                return (GetIndexesResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getIndexes";
            }
        }
    }
}
