using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetTopSongsResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "topSongs")]
        public TopSongs topSongs { get; set; }
    }
    public class TopSongs
    {
        [XmlElement(ElementName = "song")]
        public Song[] song { get; set; }
    }
    public class GetTopSongs : Request<GetTopSongsResponse>
    {
        /// <summary>
        /// Returns top songs for the given artist, using data from last.fm.
        /// </summary>
        /// <param name="artist">The artist name.</param>
        /// <param name="count">Max number of songs to return.</param>
        public GetTopSongs(string artist, string count = "50")
           : base(nameof(artist), artist)
        {

        }
        public GetTopSongsResponse Response
        {
            get
            {
                return (GetTopSongsResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetTopSongs.view";
            }
        }
    }
}

