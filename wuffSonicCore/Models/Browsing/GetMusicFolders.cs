using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetMusicFoldersResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName ="musicFolders")]
        public MusicFolders musicFolders { get; set; }
    }

    public class MusicFolders
    {
        [XmlElement(ElementName = "musicFolder")]
        public MusicFolder[] musicFolder { get; set; }
    }

    public class MusicFolder
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
    }
    public class GetMusicFolders : Request<GetMusicFoldersResponse>
    {
        /// <summary>
        /// Returns all configured top-level music folders. Takes no extra parameters.
        /// </summary>
        public GetMusicFolders()
            :base(null)
        {

        }
        public GetMusicFoldersResponse Response
        {
            get
            {
                return (GetMusicFoldersResponse)_response;
            }
        }

        public override string method
        {
            get
            {
                return "getMusicFolders";
            }
        }
    }
}
