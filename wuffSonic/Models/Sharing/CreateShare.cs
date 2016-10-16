using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class CreateShareResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "shares")]
        public Shares shares { get; set; }
    }
    public class CreateShare : Request<CreateShareResponse>
    {
        /// <summary>
        /// Creates a public URL that can be used by anyone to stream music or video from the Subsonic server. 
        /// The URL is short and suitable for posting on Facebook, Twitter etc. 
        /// Note: The user must be authorized to share (see Settings > Users > User is allowed to share files with anyone).
        /// </summary>
        /// <param name="id">ID of a song, album or video to share. Use one id parameter for each entry to share.</param>
        /// <param name="description">A user-defined description that will be displayed to people visiting the shared media.</param>
        /// <param name="expires">The time at which the share expires. Given as milliseconds since 1970.</param>
        public CreateShare(string id,string description = null,string expires = null)
           : base(nameof(id), id,
                 nameof(description),description,
                 nameof(expires),expires)
        {

        }
        public CreateShareResponse Response
        {
            get
            {
                return (CreateShareResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "CreateShare.view";
            }
        }
    }
}

