using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class SavePlayQueueResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class SavePlayQueue : Request<SavePlayQueueResponse>
    {
        /// <summary>
        /// Saves the state of the play queue for this user. 
        /// This includes the tracks in the play queue, the currently playing track, 
        /// and the position within this track. 
        /// Typically used to allow a user to move between different clients/apps 
        /// while retaining the same play queue (for instance when listening to an audio book).
        /// </summary>
        /// <param name="id">ID of a song in the play queue. Use one id parameter for each song in the play queue.</param>
        /// <param name="current">The ID of the current playing song.</param>
        /// <param name="position">The position in milliseconds within the currently playing song.</param>
        public SavePlayQueue(string id,string current = null,string position = null)
           : base(nameof(id), id,
                 nameof(current),current,
                 nameof(position),position)
        {

        }
        public SavePlayQueueResponse Response
        {
            get
            {
                return (SavePlayQueueResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "savePlayQueue";
            }
        }
    }
}

