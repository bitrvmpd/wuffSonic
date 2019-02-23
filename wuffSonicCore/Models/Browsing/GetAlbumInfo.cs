using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class GetAlbumInfoResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName ="albumInfo")]
        public AlbumInfo albumInfo { get; set; }
    }

    public class AlbumInfo{
        [XmlElement(ElementName ="notes")]
        public string notes{get;set;}
        [XmlElement(ElementName ="musicBrainzId")]
        public string musicBrainzId{get;set;}
        [XmlElement(ElementName ="lastFmUrl")]
        public string lastFmUrl{get;set;}
        [XmlElement(ElementName ="smallImageUrl")]
        public string smallImageUrl{get;set;}
        [XmlElement(ElementName ="mediumImageUrl")]
        public string mediumImageUrl{get;set;}
        [XmlElement(ElementName ="largeImageUrl")]
        public string largeImageUrl{get;set;}        
    }
    public class GetAlbumInfo : Request<GetAlbumInfoResponse>
    {
        /// <summary>
        /// Returns album notes, image URLs etc, using data from last.fm
        /// </summary>
        /// <param name="id">The album or song ID.</param>
        public GetAlbumInfo(string id)
           : base(nameof(id), id)
        {

        }
        public GetAlbumInfoResponse Response
        {
            get
            {
                return (GetAlbumInfoResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getAlbumInfo";
            }
        }
    }
}

