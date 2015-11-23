using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic
{

    public class SubsonicException : Exception
    {
        public override string Message
        {
            get
            {
                return "See Error.Details for more information.";
            }
        }
        public Error Error { get; set; }
        public SubsonicException(string errorResponse)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Error));
            StringReader rdr = new StringReader(errorResponse);
            Error = (Error)serializer.Deserialize(rdr);
        }
        public SubsonicException()
        {
        }
    }

    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")] 
    public class Error
    {
        [XmlAttribute(AttributeName = "type")]
        public string type { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }

        [XmlElement(ElementName = "error")]
        public ErrorDetails Details { get; set; }
    }
    public class ErrorDetails
    {
        [XmlAttribute(AttributeName = "code")]
        public string code { get; set; }
        [XmlAttribute(AttributeName = "message")]
        public string message { get; set; }
    }
}

