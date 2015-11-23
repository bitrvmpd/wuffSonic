using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class HLSResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class HLS : StreamRequest
    {
        /// <summary>
        /// Creates an HLS (HTTP Live Streaming) playlist used for streaming video or audio. 
        /// HLS is a streaming protocol implemented by Apple and works by breaking the overall stream into a sequence of small HTTP-based file downloads. 
        /// It's supported by iOS and newer versions of Android. This method also supports adaptive bitrate streaming, see the bitRate parameter.
        /// </summary>
        /// <param name="id">A string which uniquely identifies the media file to stream.</param>
        /// <param name="bitRate">If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. 
        /// If this parameter is specified more than once, the server will create a variant playlist, suitable for adaptive bitrate streaming.
        /// The playlist will support streaming at all the specified bitrates. 
        /// The server will automatically choose video dimensions that are suitable for the given bitrates. 
        /// Since 1.9.0 you may explicitly request a certain width (480) and height (360) like so: bitRate=1000@480x360</param>
        public HLS(string id, string bitRate = null)
           : base(nameof(id), id,
                 nameof(bitRate), bitRate)
        {

        }
        public HLSResponse Response
        {
            get
            {
                return (HLSResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "HLS.m3u8";
            }
        }
    }
}

