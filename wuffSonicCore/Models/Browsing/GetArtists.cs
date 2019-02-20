
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetArtistsResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName ="artists")]
        public Artists artists {get;set;}
    }
    public class Artists
    {
        [XmlAttribute(AttributeName = "ignoredArticles")]
        public string ignoredArticles { get; set; }
        [XmlElement(ElementName ="index")]
        public Index[] index { get; set; }
    }
    public class GetArtists : Request<GetArtistsResponse>
    {
        /// <summary>
        /// Similar to getIndexes, but organizes music according to ID3 tags.
        /// </summary>
        public GetArtists()
            :base(null)
        {

        }
        public GetArtistsResponse Response
        {
            get
            {
                return (GetArtistsResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getArtists";
            }
        }
    }
}
