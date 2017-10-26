using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetCoverArtResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class GetCoverArt : StreamRequest
    {
        /// <summary>
        /// Returns a cover art image.
        /// </summary>
        /// <param name="id">The ID of a song, album or artist.</param>
        /// <param name="size">If specified, scale image to this size.</param>
        public GetCoverArt(string id,string size = null)
           : base(nameof(id), id,
                 nameof(size),size)
        {

        }
        public GetCoverArtResponse Response
        {
            get
            {
                return (GetCoverArtResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetCoverArt.view";
            }
        }
    }
}

