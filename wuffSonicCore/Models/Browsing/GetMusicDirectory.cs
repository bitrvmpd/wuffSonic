using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetMusicDirectoryResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "directory")]
        public Directory directory { get; set; }

    }

    public class Directory
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "parent")]
        public string parent { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
        [XmlAttribute(AttributeName = "starred")]
        public string starred { get; set; }
        [XmlElement(ElementName = "child")]
        public Child[] child { get; set; }
    }
    public class GetMusicDirectory : Request<GetMusicDirectoryResponse>
    {
        /// <summary>
        /// Returns a listing of all files in a music directory. Typically used to get list of albums for an artist, or list of songs for an album.
        /// </summary>
        /// <param name="id">A string which uniquely identifies the music folder. Obtained by calls to getIndexes or getMusicDirectory.</param>
        public GetMusicDirectory(string id) :
            base(nameof(id), id)
        {
        }

        public GetMusicDirectoryResponse Response
        {
            get
            {
                return (GetMusicDirectoryResponse)_response;
            }
        }

        public override string method
        {
            get
            {
                return "getMusicDirectory";
            }
        }
    }
}
