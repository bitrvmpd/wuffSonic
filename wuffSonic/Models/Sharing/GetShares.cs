using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetSharesResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "shares")]
        public Shares shares { get; set; }

    }
    public class Shares
    {
        [XmlElement(ElementName = "share")]
        public Share[] share { get; set; }
    }
    public class Share
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "url")]
        public string url { get; set; }
        [XmlAttribute(AttributeName = "description")]
        public string description { get; set; }
        [XmlAttribute(AttributeName = "username")]
        public string username { get; set; }
        [XmlAttribute(AttributeName = "created")]
        public string created { get; set; }
        [XmlAttribute(AttributeName = "lastVisited")]
        public string lastVisited { get; set; }
        [XmlAttribute(AttributeName = "expires")]
        public string expires { get; set; }
        [XmlAttribute(AttributeName = "visitCount")]
        public string visitCount { get; set; }
        [XmlElement(ElementName = "entry")]
        public Entry[] entry { get; set; }
    }
    public class GetShares : Request<GetSharesResponse>
    {
        /// <summary>
        /// Returns information about shared media this user is allowed to manage. 
        /// Takes no extra parameters.
        /// </summary>
        public GetShares()
           : base()
        {

        }
        public GetSharesResponse Response
        {
            get
            {
                return (GetSharesResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetShares.view";
            }
        }
    }
}

