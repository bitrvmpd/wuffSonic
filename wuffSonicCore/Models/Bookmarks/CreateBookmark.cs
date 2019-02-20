using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class CreateBookmarkResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class CreateBookmark : Request<CreateBookmarkResponse>
    {
        /// <summary>
        /// Creates or updates a bookmark (a position within a media file). Bookmarks are personal and not visible to other users.
        /// </summary>
        /// <param name="id">ID of the media file to bookmark. If a bookmark already exists for this file it will be overwritten.</param>
        /// <param name="position">The position (in milliseconds) within the media file.</param>
        /// <param name="comment">A user-defined comment.</param>
        public CreateBookmark(string id,string position,string comment = null)
           : base(nameof(id), id,
                 nameof(position),position,
                 nameof(comment),comment)
        {

        }
        public CreateBookmarkResponse Response
        {
            get
            {
                return (CreateBookmarkResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "createBookmark";
            }
        }
    }
}

