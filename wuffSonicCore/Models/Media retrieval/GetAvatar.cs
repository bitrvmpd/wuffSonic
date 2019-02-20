using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetAvatarResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class GetAvatar : StreamRequest
    {
        /// <summary>
        /// Returns the avatar (personal image) for a user.
        /// </summary>
        /// <param name="username">The user in question.</param>
        public GetAvatar(string username)
           : base(nameof(username), username)
        {

        }
        public GetAvatarResponse Response
        {
            get
            {
                return (GetAvatarResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getAvatar";
            }
        }
    }
}

