using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class ScrobbleResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }

    public class Scrobble : Request<ScrobbleResponse>
    {
        /// <summary>
        /// "Scrobbles" a given music file on last.fm. Requires that the user has configured his/her last.fm credentials on the Subsonic server (Settings > Personal).
        /// 
        /// Since 1.8.0 you may specify multiple id (and optionally time) parameters to scrobble multiple files.
        /// Since 1.11.0 this method will also update the play count and last played timestamp for the song and album.
        /// It will also make the song appear in the "Now playing" page in the web app, and appear in the list of songs returned by getNowPlaying.
        /// </summary>
        /// <param name="id">A string which uniquely identifies the file to scrobble.</param>
        /// <param name="time">The time (in milliseconds since 1 Jan 1970) at which the song was listened to.</param>
        /// <param name="submission">Whether this is a "submission" or a "now playing" notification.</param>
        public Scrobble(string id,string time = null,string submission = "True")
           : base(nameof(id), id,
                 nameof(time),time,
                 nameof(submission),submission)
        {

        }
        public ScrobbleResponse Response
        {
            get
            {
                return (ScrobbleResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "scrobble";
            }
        }
    }
}

