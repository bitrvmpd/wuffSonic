using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetBookmarksResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName ="bookmarks")]
        public Bookmarks bookmarks { get; set; }
    }
    public class Bookmarks
    {
        [XmlElement(ElementName = "bookmark")]
        public Bookmark[] bookmark { get; set; }
    }
    public class Bookmark
    {
        [XmlAttribute(AttributeName = "position")]
        public string position { get; set; }
        [XmlAttribute(AttributeName = "username")]
        public string username { get; set; }
        [XmlAttribute(AttributeName = "comment")]
        public string comment { get; set; }
        [XmlAttribute(AttributeName = "created")]
        public string created { get; set; }
        [XmlAttribute(AttributeName = "changed")]
        public string changed { get; set; }
        [XmlElement(ElementName = "entry")]
        public Entry[] entry { get; set; }
    }
    public class GetBookmarks : Request
    {
        /// <summary>
        /// Returns all bookmarks for this user. A bookmark is a position within a certain media file.
        /// </summary>
        public GetBookmarks()
           : base()
        {

        }
        public GetBookmarksResponse Response
        {
            get
            {
                return (GetBookmarksResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetBookmarks.view";
            }
        }
    }
}

