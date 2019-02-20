using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetRandomSongsResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "randomSongs")]
        public RandomSongs randomSongs { get; set; }
    }

    public class RandomSongs
    {
        [XmlElement(ElementName = "song")]
        public Song[] song { get; set; }
    }
    public class GetRandomSongs : Request<GetRandomSongsResponse>
    {
        /// <summary>
        /// Returns random songs matching the given criteria.
        /// </summary>
        /// <param name="size">The maximum number of songs to return. Max 500.</param>
        /// <param name="genre">Only returns songs belonging to this genre.</param>
        /// <param name="fromYear">Only return songs published after or in this year.</param>
        /// <param name="toYear">Only return songs published before or in this year.</param>
        /// <param name="musicFolderId">Only return songs in the music folder with the given ID. See getMusicFolders.</param>
        public GetRandomSongs(string size = "10",string genre = null,string fromYear = null,string toYear=null,string musicFolderId=null)
           : base(nameof(size),size,
                 nameof(genre),genre,
                 nameof(fromYear),fromYear,
                 nameof(toYear),toYear,
                 nameof(musicFolderId),musicFolderId)
        {

        }
        public GetRandomSongsResponse Response
        {
            get
            {
                return (GetRandomSongsResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getRandomSongs";
            }
        }
    }
}

