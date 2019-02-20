using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetArtistInfo2Response
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "artistInfo2")]
        public ArtistInfo artistInfo { get; set; }
    }
    public class GetArtistInfo2 : Request<GetArtistInfo2Response>
    {
        /// <summary>
        /// Similar to getArtistInfo, but organizes music according to ID3 tags.
        /// </summary>
        /// <param name="id">The artist ID.</param>
        /// <param name="count">Max number of similar artists to return, default 20</param>
        /// <param name="includeNotPresent">Whether to return artists that are not present in the media library.</param>
        public GetArtistInfo2(string id, string count = "20", string includeNotPresent = "false")
           : base(nameof(id), id,
                 nameof(count), count,
                 nameof(includeNotPresent), includeNotPresent)
        {

        }
        public GetArtistInfo2Response Response
        {
            get
            {
                return (GetArtistInfo2Response)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getArtistInfo2";
            }
        }
    }
}

