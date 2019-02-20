using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using wuffSonic;

namespace wuffSonic.Models 
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]

    public class PingResponse
    {
        [XmlAttribute(AttributeName = "type")]
        public string type { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }

    public class Ping : Request<PingResponse>
    {
        /// <summary>
        /// Used to test connectivity with the server.
        /// </summary>
        public Ping()
            :base(null)
        {
        }
        public PingResponse Response {
            get
            {
                return (PingResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "ping";
            }
        }
    }
}
