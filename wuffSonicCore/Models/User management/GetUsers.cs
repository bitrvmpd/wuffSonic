using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetUsersResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName ="users")]
        public Users users { get; set; }
    }
    public class Users
    {
        [XmlElement(ElementName = "user")]
        public User[] user { get; set; }
    }
    public class GetUsers : Request
    {
        /// <summary>
        /// Get details about all users, including which authorization roles and folder access they have. 
        /// Only users with admin privileges are allowed to call this method.
        /// </summary>
        public GetUsers()
           : base()
        {

        }
        public GetUsersResponse Response
        {
            get
            {
                return (GetUsersResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetUsers.view";
            }
        }
    }
}

