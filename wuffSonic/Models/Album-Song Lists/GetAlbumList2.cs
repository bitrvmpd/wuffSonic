using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetAlbumList2Response
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "albumList2")]
        public AlbumList albumList { get; set; }
    }
    public class GetAlbumList2 : Request
    {
        /// <summary>
        /// Returns a list of random, newest, highest rated etc. albums. Similar to the album lists on the home page of the Subsonic web interface.
        /// </summary>
        /// <param name="type">The list type. Must be one of the following: random, newest, highest, frequent, recent,alphabeticalByName,alphabeticalByArtist,starred</param>
        /// <param name="size">The number of albums to return. Max 500.</param>
        /// <param name="offset">The list offset. Useful if you for example want to page through the list of newest albums.</param>
        /// <param name="musicFolderId">Only return albums in the music folder with the given ID. See getMusicFolders.</param>
        public GetAlbumList2(ListType type, string size = "10", string offset = "0", string musicFolderId = null)
           : base(nameof(type), type.ToString(),
                 nameof(offset),offset,
                 nameof(musicFolderId),musicFolderId
                 )
        {

        }
        /// <summary>
        /// Returns a list of random, newest, highest rated etc. albums. Similar to the album lists on the home page of the Subsonic web interface.
        /// </summary>
        /// <param name="fromYear">The first year in the range. If fromYear > toYear a reverse chronological list is returned.</param>
        /// <param name="toYear">The last year in the range.</param>
        /// <param name="size">The number of albums to return. Max 500.</param>
        /// <param name="offset">The list offset. Useful if you for example want to page through the list of newest albums.</param>
        /// <param name="musicFolderId">Only return albums in the music folder with the given ID. See getMusicFolders.</param>
        public GetAlbumList2(string fromYear, string toYear, string size = "10", string offset = "0", string musicFolderId = null)
          : base("type", ListTypeByYear.byYear.ToString(),
                nameof(fromYear),fromYear,
                nameof(toYear),toYear,
                nameof(offset), offset,
                nameof(musicFolderId), musicFolderId
                )
        {

        }

        /// <summary>
        /// Returns a list of random, newest, highest rated etc. albums. Similar to the album lists on the home page of the Subsonic web interface.
        /// </summary>
        /// <param name="genre">The name of the genre, e.g., "Rock"</param>
        /// <param name="size">The number of albums to return. Max 500.</param>
        /// <param name="offset">The list offset. Useful if you for example want to page through the list of newest albums.</param>
        /// <param name="musicFolderId">Only return albums in the music folder with the given ID. See getMusicFolders.</param>
        public GetAlbumList2(string genre, string size = "10", string offset = "0", string musicFolderId = null)
          : base("type", ListTypeByGenre.byGenre.ToString(),
                nameof(genre),genre,
                nameof(offset), offset,
                nameof(musicFolderId), musicFolderId
                )
        {

        }
        public GetAlbumList2Response Response
        {
            get
            {
                return (GetAlbumList2Response)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetAlbumList2.view";
            }
        }
    }
}

