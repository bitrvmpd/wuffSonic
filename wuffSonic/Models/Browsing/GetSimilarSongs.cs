using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetSimilarSongsResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "similarSongs")]
        public SimilarSongs similarSongs { get; set; }
    }
    public class SimilarSongs
    {
        [XmlElement(ElementName = "song")]
        public Song[] song { get; set; }
    }
    public class GetSimilarSongs : Request<GetSimilarSongsResponse>
    {
        /// <summary>
        /// Returns a random collection of songs from the given artist and similar artists, using data from last.fm. Typically used for artist radio features.
        /// </summary>
        /// <param name="id">The artist, album or song ID.</param>
        /// <param name="count">Max number of songs to return.</param>
        public GetSimilarSongs(string id,string count = "50")
           : base(nameof(id), id,
                 nameof(count),count)
        {

        }
        public GetSimilarSongsResponse Response
        {
            get
            {
                return (GetSimilarSongsResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetSimilarSongs.view";
            }
        }
    }
}

