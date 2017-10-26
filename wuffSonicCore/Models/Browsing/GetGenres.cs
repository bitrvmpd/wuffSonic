using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetGenresResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "genres")]
        public Genres genres { get; set; }
    }
    public class Genres
    {
        [XmlElement(ElementName ="genre")]
        public Genre[] genre { get; set; }
    }
    public class Genre
    {
        [XmlAttribute(AttributeName = "songCount")]
        public string songCount { get; set; }
        [XmlAttribute(AttributeName = "albumCount")]
        public string albumCount { get; set; }
    }
    public class GetGenres : Request<GetGenresResponse>
    {
        /// <summary>
        /// Returns all genres.
        /// </summary>
        public GetGenres()
        {

        }
        public GetGenresResponse Response
        {
            get
            {
                return (GetGenresResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getGenres.view";
            }
        }
    }
}
