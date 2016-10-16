using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetLyricsResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "lyrics")]
        public Lyrics lyrics { get; set; }
    }

    public class Lyrics
    {
        [XmlAttribute(AttributeName = "artist")]
        public string artist { get; set; }
        [XmlAttribute(AttributeName ="title")]
        public string title { get; set; }
        [XmlText]
        public string value { get; set; }
    }
    public class GetLyrics : Request<GetLyricsResponse>
    {
        /// <summary>
        /// Searches for and returns lyrics for a given song.
        /// </summary>
        /// <param name="artist">The artist name.</param>
        /// <param name="title">The song title.</param>
        public GetLyrics(string artist,string title)
           : base(nameof(artist), artist,
                 nameof(title), title)
        {

        }
        /// <summary>
        /// Searches for and returns lyrics for a given song.
        /// </summary>
        /// <param name="artist">The artist name.</param>
        public GetLyrics(string artist)
           : base(nameof(artist), artist)
                 
        {

        }
        /// <summary>
        /// Searches for and returns lyrics for a given song.
        /// </summary>
        /// <param name="title">The song title.</param>
        public GetLyrics(string title,int? r = null)
           : base(nameof(title), title)
        {

        }
        public GetLyricsResponse Response
        {
            get
            {
                return (GetLyricsResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetLyrics.view";
            }
        }
    }
}
