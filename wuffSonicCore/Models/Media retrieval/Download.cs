using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class DownloadResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class Download : StreamRequest
    {
        /// <summary>
        /// Downloads a given media file. Similar to stream, but this method returns the original media data without transcoding or downsampling.
        /// </summary>
        /// <param name="id">A string which uniquely identifies the file to download. Obtained by calls to getMusicDirectory.</param>
        public Download(string id)
           : base(nameof(id), id)
        {

        }
        public DownloadResponse Response
        {
            get
            {
                return (DownloadResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "download";
            }
        }
    }
}

