using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class ChangePasswordResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class ChangePassword : Request<ChangePasswordResponse>
    {
        /// <summary>
        /// Changes the password of an existing Subsonic user, using the following parameters. 
        /// You can only change your own password unless you have admin privileges.
        /// </summary>
        /// <param name="username">The name of the user which should change its password.</param>
        /// <param name="password">The new password of the new user, either in clear text of hex-encoded</param>
        public ChangePassword(string username,string password)
           : base(nameof(username), username,
                 nameof(password),password)
        {

        }
        public ChangePasswordResponse Response
        {
            get
            {
                return (ChangePasswordResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "changePassword";
            }
        }
    }
}

