using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetArtistResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "artist")]
        public Artist artist { get; set; }
    }
    public class GetArtist : Request
    {
        /// <summary>
        /// Returns details for an artist, including a list of albums. This method organizes music according to ID3 tags.
        /// </summary>
        /// <param name="id">The artist ID.</param>
        public GetArtist(string id)
            :base(nameof(id),id)
        {            
            
        }
        public GetArtistResponse Response
        {
            get
            {
                return (GetArtistResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getArtist.view";
            }
        }
    }
}
