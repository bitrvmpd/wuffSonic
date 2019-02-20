using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetStarred2Response
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "starred2")]
        public Starred starred { get; set; }
    }
    public class GetStarred2 : Request<GetStarred2Response>
    {
        /// <summary>
        /// Similar to getStarred, but organizes music according to ID3 tags.
        /// </summary>
        /// <param name="musicFolderId">Only return results from the music folder with the given ID. See getMusicFolders.</param>
        public GetStarred2(string musicFolderId = null)
           : base(nameof(musicFolderId), musicFolderId)
        {

        }
        public GetStarred2Response Response
        {
            get
            {
                return (GetStarred2Response)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getStarred2";
            }
        }
    }
}

