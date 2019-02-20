using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetAlbumResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName ="album")]
        public Album album { get; set; }
    }
    public class GetAlbum : Request<GetAlbumResponse>
    {
        /// <summary>
        /// Returns details for an album, including a list of songs. This method organizes music according to ID3 tags.
        /// </summary>
        /// <param name="id">The album ID.</param>
        public GetAlbum(string id)
           : base(nameof(id), id)
        {

        }
        public GetAlbumResponse Response
        {
            get
            {
                return (GetAlbumResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getAlbum";
            }
        }
    }
}

