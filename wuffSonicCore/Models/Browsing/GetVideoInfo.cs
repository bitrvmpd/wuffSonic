using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetVideoInfoResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }

        [XmlElement(ElementName = "videoInfo")]
        public VideoInfo videoInfo { get; set; }
    }

    public class VideoInfo
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlElement(ElementName = "captions")]
        public Caption[] captions { get; set; }
        [XmlElement(ElementName = "audioTrack")]
        public AudioTrack[] audioTracks { get; set; }
        [XmlElement(ElementName = "conversion")]
        public Conversion[] conversions { get; set; }
    }

    public class Caption
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
    }

    public class AudioTrack
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
        [XmlAttribute(AttributeName = "languageCode")]
        public string languageCode { get; set; }
    }

    public class Conversion
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "bitRate")]
        public string bitRate { get; set; }
        [XmlAttribute(AttributeName = "audioTrackId")]
        public string audioTrackId{get;set;}
    }

    public class GetVideoInfo : Request<GetVideoInfoResponse>
    {
        /// <summary>
        /// Returns details for a video, including information about available audio tracks, subtitles (captions) and conversions.
        /// <param name="id">The video ID.</param>
        /// </summary>       
        public GetVideoInfo(string id)
           : base(nameof(id), id)
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
                return "getVideoInfo";
            }
        }
    }
}

