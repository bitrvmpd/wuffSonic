using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class StarResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class Star : Request<StarResponse>
    {
        /// <summary>
        /// Attaches a star to a song, album or artist.
        /// </summary>
        /// <param name="id">The ID of the file (song) or folder (album/artist) to star. Multiple parameters allowed.</param>
        /// <param name="albumId">The ID of an album to star. Use this rather than id if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed.</param>
        /// <param name="artistId">The ID of an artist to star. Use this rather than id if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed.</param>
        public Star(string id = null,string albumId= null,string artistId=null)
           : base(nameof(id), id,
                 nameof(albumId),albumId,
                 nameof(artistId),artistId)
        {

        }
        public StarResponse Response
        {
            get
            {
                return (StarResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "star";
            }
        }
    }
}

