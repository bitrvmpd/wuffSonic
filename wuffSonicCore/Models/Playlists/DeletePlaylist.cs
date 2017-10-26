using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class DeletePlaylistResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class DeletePlaylist : Request<DeletePlaylistResponse>
    {
        /// <summary>
        /// Deletes a saved playlist.
        /// </summary>
        /// <param name="id">ID of the playlist to delete, as obtained by getPlaylists.</param>
        public DeletePlaylist(string id)
           : base(nameof(id), id)
        {

        }
        public DeletePlaylistResponse Response
        {
            get
            {
                return (DeletePlaylistResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "DeletePlaylist.view";
            }
        }
    }
}

