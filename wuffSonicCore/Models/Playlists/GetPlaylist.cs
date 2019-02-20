using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetPlaylistResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "playlist")]
        public Playlist playlist { get; set; }
    }
	public class GetPlaylist : Request<GetPlaylistResponse>
    {
        /// <summary>
        /// Returns a listing of files in a saved playlist.
        /// </summary>
        /// <param name="id">ID of the playlist to return, as obtained by getPlaylists.</param>
        public GetPlaylist(string id)
           : base(nameof(id), id)
        {

        }
        public GetPlaylistResponse Response
        {
            get
            {
                return (GetPlaylistResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getPlaylist";
            }
        }
    }
}

