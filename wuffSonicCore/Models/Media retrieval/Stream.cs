using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class StreamResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class Stream : StreamRequest
    {
        /// <summary>
        /// Streams a given media file.
        /// </summary>
        /// <param name="id">A string which uniquely identifies the file to stream. Obtained by calls to getMusicDirectory.</param>
        /// <param name="maxBitRate">If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. If set to zero, no limit is imposed.</param>
        /// <param name="format">Specifies the preferred target format (e.g., "mp3" or "flv") in case there are multiple applicable transcodings. Starting with 1.9.0 you can use the special value "raw" to disable transcoding.</param>
        /// <param name="timeOffset">Only applicable to video streaming. If specified, start streaming at the given offset (in seconds) into the video. Typically used to implement video skipping.</param>
        /// <param name="size">Only applicable to video streaming. Requested video size specified as WxH, for instance "640x480".</param>
        /// <param name="estimateContentLength">If set to "true", the Content-Length HTTP header will be set to an estimated value for transcoded or downsampled media.</param>
        public Stream(string id, Bitrate maxBitRate = Bitrate.Kbps_0, string format = null, string timeOffset = null, string size = null, string estimateContentLength = "false")
           : base(nameof(id), id,
                 nameof(maxBitRate), ((int)maxBitRate).ToString(),
                 nameof(format), format,
                 nameof(timeOffset), timeOffset,
                 nameof(size), size,
                 nameof(estimateContentLength), estimateContentLength)
        {

        }

        public StreamResponse Response
        {
            get
            {
                return (StreamResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "stream";
            }
        }
    }
}

