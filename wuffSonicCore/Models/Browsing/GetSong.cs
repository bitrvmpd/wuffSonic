using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetSongResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "song")]
        public Song song { get; set; }
    }
    public class GetSong : Request<GetSongResponse>
    {
        /// <summary>
        /// Returns details for a song.
        /// </summary>
        /// <param name="id">The song ID.</param>
        public GetSong(string id)
           : base(nameof(id), id)
        {

        }
        public GetSongResponse Response
        {
            get
            {
                return (GetSongResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetSong.view";
            }
        }
    }
}

