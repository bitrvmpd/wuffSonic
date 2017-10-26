using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class SetRatingResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class SetRating : Request<SetRatingResponse>
    {
        /// <summary>
        /// Sets the rating for a music file.
        /// </summary>
        /// <param name="id">A string which uniquely identifies the file (song) or folder (album/artist) to rate.</param>
        /// <param name="rating">The rating between 1 and 5 (inclusive), or 0 to remove the rating.</param>
        public SetRating(string id,string rating)
           : base(nameof(id), id,
                 nameof(rating),rating)
        {

        }
        public SetRatingResponse Response
        {
            get
            {
                return (SetRatingResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "SetRating.view";
            }
        }
    }
}

