using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetStarredResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "starred")]
        public Starred starred { get; set; }
    }
    public class Starred
    {
        [XmlElement(ElementName = "artist")]
        public Artist[] artist { get; set; }
        [XmlElement(ElementName = "album")]
        public Album[] album { get; set; }
        [XmlElement(ElementName = "song")]
        public Song[] song { get; set; }
    }
    public class GetStarred : Request
    {
        /// <summary>
        /// Returns starred songs, albums and artists.
        /// </summary>
        /// <param name="musicFolderId">Only return results from the music folder with the given ID. See getMusicFolders.</param>
        public GetStarred(string musicFolderId = null)
           : base(nameof(musicFolderId), musicFolderId)
        {

        }
        public GetStarredResponse Response
        {
            get
            {
                return (GetStarredResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetStarred.view";
            }
        }
    }
}

