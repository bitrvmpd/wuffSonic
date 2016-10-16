using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class UpdatePlaylistResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class UpdatePlaylist : Request<UpdatePlaylistResponse>
    {
        /// <summary>
        /// Updates a playlist. Only the owner of a playlist is allowed to update it.
        /// </summary>
        /// <param name="playlistId">The playlist ID.</param>
        /// <param name="name">	The human-readable name of the playlist.</param>
        /// <param name="comment">The playlist comment.</param>
        /// <param name="isPublic">true if the playlist should be visible to all users, false otherwise.</param>
        /// <param name="songIdToAdd">Add this song with this ID to the playlist. Multiple parameters allowed.</param>
        /// <param name="songIndexToRemove">Remove the song at this position in the playlist. Multiple parameters allowed.</param>
        public UpdatePlaylist(string playlistId,string name = null,string comment = null,string isPublic = null,string songIdToAdd = null, string songIndexToRemove = null)
           : base(nameof(playlistId), playlistId,
                 nameof(name),name,
                 nameof(comment),comment,
                 "public",isPublic,
                 nameof(songIdToAdd),songIdToAdd,
                 nameof(songIndexToRemove),songIndexToRemove)
        {

        }
        public UpdatePlaylistResponse Response
        {
            get
            {
                return (UpdatePlaylistResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "UpdatePlaylist.view";
            }
        }
    }
}

