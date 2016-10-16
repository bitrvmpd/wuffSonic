using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class UpdateShareResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class UpdateShare : Request<UpdateShareResponse>
    {
        /// <summary>
        /// Updates the description and/or expiration date for an existing share.
        /// </summary>
        /// <param name="id">ID of a song, album or video to share. Use one id parameter for each entry to share.</param>
        /// <param name="description">A user-defined description that will be displayed to people visiting the shared media.</param>
        /// <param name="expires">The time at which the share expires. Given as milliseconds since 1970.</param>
        public UpdateShare(string id, string description = null, string expires = null)
           : base(nameof(id), id,
                 nameof(description),description,
                 nameof(expires),expires)
        {

        }
        public UpdateShareResponse Response
        {
            get
            {
                return (UpdateShareResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "UpdateShare.view";
            }
        }
    }
}

