using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetChatMessagesResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "chatMessages")]
        public ChatMessages chatMessages { get; set; }
    }
    public class ChatMessages
    {
        [XmlElement(ElementName = "chatMessage")]
        public ChatMessage[] chatMessage { get; set; }
    }
    public class ChatMessage
    {
        [XmlAttribute(AttributeName = "username")]
        public string username { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string time { get; set; }
        [XmlAttribute(AttributeName = "message")]
        public string message { get; set; }
    }
    public class GetChatMessages : Request<GetChatMessagesResponse>
    {
        /// <summary>
        /// Returns the current visible (non-expired) chat messages.
        /// </summary>
        /// <param name="since">Only return messages newer than this time (in millis since Jan 1 1970).</param>
        public GetChatMessages(string since = null)
           : base(nameof(since), since)
        {

        }
        public GetChatMessagesResponse Response
        {
            get
            {
                return (GetChatMessagesResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetChatMessages.view";
            }
        }
    }
}

