using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetNowPlayingResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "nowPlaying")]
        public NowPlaying nowPlaying { get; set; }
    }

    public class NowPlaying
    {
        [XmlElement(ElementName = "entry")]
        public Entry[] entry { get; set; }
    }
    public class Entry
    {
        [XmlAttribute(AttributeName = "username")]
        public string username { get; set; }

        [XmlAttribute(AttributeName = "minutesAgo")]
        public string minutesAgo { get; set; }

        [XmlAttribute(AttributeName = "playerId")]
        public string playerId { get; set; }
        [XmlAttribute(AttributeName = "playerName")]
        public string playerName { get; set; }

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
        [XmlAttribute(AttributeName = "suffix")]
        public string suffix { get; set; }
        [XmlAttribute(AttributeName = "path")]
        public string path { get; set; }
        [XmlAttribute(AttributeName = "transcodedContentType")]
        public string transcodedContentType { get; set; }
        [XmlAttribute(AttributeName = "transcodedSuffix")]
        public string transcodedSuffix { get; set; }
    }
    public class GetNowPlaying : Request<GetNowPlayingResponse>
    {
        /// <summary>
        /// Returns what is currently being played by all users. Takes no extra parameters.
        /// </summary>
        public GetNowPlaying()
           : base(null)
        {

        }
        public GetNowPlayingResponse Response
        {
            get
            {
                return (GetNowPlayingResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getNowPlaying";
            }
        }
    }
}

