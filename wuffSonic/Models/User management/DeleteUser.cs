using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class DeleteUserResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class DeleteUser : Request
    {
        /// <summary>
        /// Deletes an existing Subsonic user, using the following parameters:
        /// </summary>
        /// <param name="username"The name of the user to delete.></param>
        public DeleteUser(string username)
           : base(nameof(username), username)
        {

        }
        public DeleteUserResponse Response
        {
            get
            {
                return (DeleteUserResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "DeleteUser.view";
            }
        }
    }
}

