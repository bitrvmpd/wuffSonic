using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetSimilarSongs2Response
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "similarSongs2")]
        public SimilarSongs similarSongs { get; set; }
    }
    public class GetSimilarSongs2 : Request<GetSimilarSongs2>
    {
        /// <summary>
        /// Similar to getSimilarSongs, but organizes music according to ID3 tags.
        /// </summary>
        /// <param name="id">The artist ID.</param>
        /// <param name="count">Max number of songs to return.</param>
        public GetSimilarSongs2(string id,string count = "50")
           : base(nameof(id), id,
                 nameof(count), count)
        {

        }
        public GetSimilarSongs2Response Response
        {
            get
            {
                return (GetSimilarSongs2Response)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetSimilarSongs2.view";
            }
        }
    }
}

