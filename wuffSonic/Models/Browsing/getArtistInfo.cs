using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetArtistInfoResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "artistInfo")]
        public ArtistInfo artistInfo { get; set; }
    }
    public class ArtistInfo
    {
        [XmlElement(ElementName = "biography")]
        public string biography { get; set; }
        [XmlElement(ElementName = "musicBrainzId")]
        public string musicBrainzId { get; set; }
        [XmlElement(ElementName = "smallImageUrl")]
        public string smallImageUrl { get; set; }
        [XmlElement(ElementName = "mediumImageUrl")]
        public string mediumImageUrl { get; set; }
        [XmlElement(ElementName = "largeImageUrl")]
        public string largeImageUrl { get; set; }
        [XmlElement(ElementName = "similarArtist")]
        public SimilarArtist similarArtist { get; set; }
    }
    public class SimilarArtist
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
        [XmlAttribute(AttributeName = "coverArt")]
        public string coverArt { get; set; }
        [XmlAttribute(AttributeName = "albumCount")]
        public string albumCount { get; set; }
    }
    public class GetArtistInfo : Request<GetArtistInfoResponse>
    {
        /// <summary>
        /// Returns artist info with biography, image URLs and similar artists, using data from last.fm.
        /// </summary>
        /// <param name="id">The artist, album or song ID.</param>
        /// <param name="count">Max number of similar artists to return, default 20</param>
        /// <param name="includeNotPresent">Whether to return artists that are not present in the media library.</param>
        public GetArtistInfo(string id, string count = "20", string includeNotPresent = "false")
           : base(nameof(id), id,
                 nameof(count), count,
                 nameof(includeNotPresent), includeNotPresent)
        {

        }
        public GetArtistInfoResponse Response
        {
            get
            {
                return (GetArtistInfoResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getArtistInfo.view";
            }
        }
    }
}

