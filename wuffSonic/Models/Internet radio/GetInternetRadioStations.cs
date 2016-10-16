using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetInternetRadioStationsResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "internetRadioStations")]
        public InternetRadioStations internetRadioStations { get; set; }
    }
    public class InternetRadioStations
    {
        [XmlElement(ElementName = "internetRadioStation")]
        public InternetRadioStation[] internetRadioStation { get; set; }
    }
    public class InternetRadioStation
    {
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }
        [XmlAttribute(AttributeName = "streamUrl")]
        public string streamUrl { get; set; }
        [XmlAttribute(AttributeName = "homePageUrl")]
        public string homePageUrl { get; set; }
    }
    public class GetInternetRadioStations : Request<GetInternetRadioStationsResponse>
    {
        /// <summary>
        /// Returns all internet radio stations. Takes no extra parameters.
        /// </summary>
        public GetInternetRadioStations()
           : base()
        {

        }
        public GetInternetRadioStationsResponse Response
        {
            get
            {
                return (GetInternetRadioStationsResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "GetInternetRadioStations.view";
            }
        }
    }
}

