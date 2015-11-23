using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetVideosResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }

        [XmlElement(ElementName = "videos")]
        public Videos videos { get; set; }
    }

    public class Videos
    {
        [XmlElement(ElementName = "video")]
        public Video[] video { get; set; }
    }
    public class Video
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set;}
        [XmlAttribute(AttributeName = "parent")]
        public string parent { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string title { get; set; }
        [XmlAttribute(AttributeName = "album")]
        public string album { get; set; }
        [XmlAttribute(AttributeName = "isDir")]
        public string isDir { get; set; }
        [XmlAttribute(AttributeName = "coverArt")]
        public string coverArt { get; set; }
        [XmlAttribute(AttributeName = "created")]
        public string created { get; set; }
        [XmlAttribute(AttributeName = "duration")]
        public string duration { get; set; }
        [XmlAttribute(AttributeName = "bitRate")]
        public string bitRate { get; set; }
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
        [XmlAttribute(AttributeName = "transcodedSuffix")]
        public string transcodedSuffix { get; set; }
        [XmlAttribute(AttributeName = "transcodedContentType")]
        public string transcodedContentType { get; set; }
    }
    public class GetVideos : Request
    {
        /// <summary>
        /// Returns all video files.
        /// </summary>
        /// <param name="id"></param>
        public GetVideos()
           : base(null)
        {

        }
        public GetVideosResponse Response
        {
            get
            {
                return (GetVideosResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetVideos.view";
            }
        }
    }
}

