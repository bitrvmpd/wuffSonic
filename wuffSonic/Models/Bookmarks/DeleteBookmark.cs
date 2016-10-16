using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class DeleteBookmarkResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class DeleteBookmark : Request<DeleteBookmarkResponse>
    {
        /// <summary>
        /// Deletes the bookmark for a given file.
        /// </summary>
        /// <param name="id">ID of the media file for which to delete the bookmark. Other users' bookmarks are not affected.</param>
        public DeleteBookmark(string id)
           : base(nameof(id), id)
        {

        }
        public DeleteBookmarkResponse Response
        {
            get
            {
                return (DeleteBookmarkResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "DeleteBookmark.view";
            }
        }
    }
}

