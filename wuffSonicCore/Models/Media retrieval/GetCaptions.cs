using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetCaptionsResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class GetCaptions : StreamRequest
    {
        /// <summary>
        /// Returns captions (subtitles) for a video. Use getVideoInfo to get a list of available captions. 
        /// Returns the raw video captions.
        /// </summary>      
        /// <param name="id">The ID of the video.</param>
        /// <param name="format">Preferred captions format ("srt" or "vtt").</param>
        public GetCaptions(string id, CaptionsFormat format = CaptionsFormat.srt)
           : base(nameof(id), id,
                 nameof(format), format == CaptionsFormat.srt ? "srt" : "vtt")
        {

        }
        public GetCaptionsResponse Response
        {
            get
            {
                return (GetCaptionsResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return " getCaptions";
            }
        }
    }

    public enum CaptionsFormat
    {
        srt = 0,
        vtt = 1
    }
}
