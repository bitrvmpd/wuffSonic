using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class AddChatMessageResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class AddChatMessage : Request
    {
        /// <summary>
        /// Adds a message to the chat log.
        /// </summary>
        /// <param name="message">The chat message.</param>
        public AddChatMessage(string message)
           : base(nameof(message), message)
        {

        }
        public AddChatMessageResponse Response
        {
            get
            {
                return (AddChatMessageResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "AddChatMessage.view";
            }
        }
    }
}

