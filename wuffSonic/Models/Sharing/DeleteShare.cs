using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class DeleteShareResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class DeleteShare : Request<DeleteShareResponse>
    {
        /// <summary>
        /// Deletes an existing share.
        /// </summary>
        /// <param name="id">ID of the share to delete.</param>
        public DeleteShare(string id)
           : base(nameof(id), id)
        {

        }
        public DeleteShareResponse Response
        {
            get
            {
                return (DeleteShareResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "DeleteShare.view";
            }
        }
    }
}

