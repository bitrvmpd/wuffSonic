using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetPlayQueueResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "playQueue")]
        public PlayQueue playQueue { get; set; }
    }
    public class PlayQueue
    {
        [XmlAttribute(AttributeName = "current")]
        public string current { get; set; }
        [XmlAttribute(AttributeName = "position")]
        public string position { get; set; }
        [XmlAttribute(AttributeName = "username")]
        public string username { get; set; }
        [XmlAttribute(AttributeName = "changed")]
        public string changed { get; set; }
        [XmlAttribute(AttributeName = "changedBy")]
        public string changedBy { get; set; }
        [XmlElement(ElementName ="entry")]
        public Entry[] entry { get; set; }

    }
    public class GetPlayQueue : Request<GetPlayQueueResponse>
    {
        /// <summary>
        /// Returns the state of the play queue for this user (as set by savePlayQueue). 
        /// This includes the tracks in the play queue, the currently playing track, 
        /// and the position within this track. 
        /// Typically used to allow a user to move between different clients/apps 
        /// while retaining the same play queue (for instance when listening to an audio book).
        /// </summary>
        public GetPlayQueue()
           : base()
        {

        }
        public GetPlayQueueResponse Response
        {
            get
            {
                return (GetPlayQueueResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetPlayQueue.view";
            }
        }
    }
}

