using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetLicenseResponse
    {
        [XmlAttribute(AttributeName = "type")]
        public string type { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "license")]
        public License license { get; set; }
    }

    public class License
    {
        [XmlAttribute(AttributeName = "valid")]
        public string valid { get; set; }
        [XmlAttribute(AttributeName = "email")]
        public string email { get; set; }
        [XmlAttribute(AttributeName = "key")]
        public string key { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string date { get; set; }
    }

	public class GetLicense : Request<GetLicenseResponse>
    {
        /// <summary>
        /// Get details about the software license. 
        /// </summary>
        public GetLicense()
            :base(null)
        {

        }
        public GetLicenseResponse Response
        {
            get
            {
                return (GetLicenseResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getLicense.view";
            }
        }
    }
}
