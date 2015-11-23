using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class CreatePlaylistResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class CreatePlaylist : Request
    {
        /// <summary>
        /// Creates a playlist.
        /// </summary>
        /// <param name="songId">ID of a song in the playlist. Use one songId parameter for each song in the playlist.</param>
        /// <param name="name">The human-readable name of the playlist.</param>
        public CreatePlaylist(string songId,string name)
           : base(nameof(songId), songId,
                 nameof(name), name)
        {

        }
        /// <summary>
        /// Updates a playlist.
        /// </summary>
        /// <param name="songId">ID of a song in the playlist. Use one songId parameter for each song in the playlist.</param>
        /// <param name="playlistId">The playlist ID.</param>
        public CreatePlaylist(string songId,string playlistId,object zero = null)
           : base(nameof(songId), songId,
                 nameof(playlistId),playlistId)
        {

        }
        public CreatePlaylistResponse Response
        {
            get
            {
                return (CreatePlaylistResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "CreatePlaylist.view";
            }
        }
    }
}

