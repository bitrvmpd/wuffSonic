using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    public class CreatePlaylist : Request<GetPlaylistResponse>
    {
        // To avoid constructor with same signatures.
        private CreatePlaylist(string playlistId = null, string name = null, string songId = null)
            : base(nameof(playlistId), playlistId,
                  nameof(name), name,
                  nameof(songId), songId)
        {

        }

        private CreatePlaylist() { }

        /// <summary>
        /// Creates a playlist.
        /// </summary>
        /// <param name="name">The human-readable name of the playlist.</param>
        /// <param name="songId">ID of a song in the playlist. Use one songId parameter for each song in the playlist.</param>
        public static CreatePlaylist CreateNewPlaylist(string name, string songId = null)
        {
            return new CreatePlaylist(name: name, songId: songId);
        }
        /// <summary>
        /// Updates a playlist.
        /// </summary>
        /// <param name="playlistId">The playlist ID.</param>
        /// <param name="songId">ID of a song in the playlist. Use one songId parameter for each song in the playlist.</param>
        public static CreatePlaylist UpdatePlaylist(string playlistId, string songId = null)
        {
            return new CreatePlaylist(playlistId: playlistId, songId: songId);
        }

        // Updated for 1.14.0
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
                return "createPlaylist";
            }
        }
    }
}

