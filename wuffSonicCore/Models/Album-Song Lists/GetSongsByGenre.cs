using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetSongsByGenreResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "songsByGenre")]
        public SongsByGenre songsByGenre { get; set; }
    }
    public class SongsByGenre
    {
        [XmlElement(ElementName = "song")]
        public Song[] song { get; set; }
    }
    public class GetSongsByGenre : Request<GetSongsByGenreResponse>
    {
        /// <summary>
        /// Returns songs in a given genre.
        /// </summary>
        /// <param name="genre">The genre, as returned by getGenres.</param>
        /// <param name="count">The maximum number of songs to return. Max 500.</param>
        /// <param name="offset">The offset. Useful if you want to page through the songs in a genre.</param>
        /// <param name="musicFolderId">Only return albums in the music folder with the given ID. See getMusicFolders</param>
        public GetSongsByGenre(string genre,string count = "10",string offset = "0",string musicFolderId = null)
           : base(nameof(genre), genre,
                 nameof(count),count,
                 nameof(offset),offset,
                 nameof(musicFolderId),musicFolderId)
        {

        }
        public GetSongsByGenreResponse Response
        {
            get
            {
                return (GetSongsByGenreResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getSongsByGenre";
            }
        }
    }
}

