﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class Search2Response
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
        [XmlElement(ElementName = "searchResult2")]
        public SearchResult searchResult { get; set; }
    }
    public class SearchResult
    {
        [XmlElement(ElementName = "artist")]
        public Artist[] artist { get; set; }
        [XmlElement(ElementName = "album")]
        public Album[] album { get; set; }
        [XmlElement(ElementName = "song")]
        public Song[] song { get; set; }
    }
    public class Search2 : Request
    {
        /// <summary>
        /// Returns albums, artists and songs matching the given search criteria. Supports paging through the result.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="artistCount">Maximum number of artists to return.</param>
        /// <param name="artistOffset">Search result offset for artists. Used for paging.</param>
        /// <param name="albumCount">Maximum number of albums to return.</param>
        /// <param name="albumOffset">Search result offset for albums. Used for paging.</param>
        /// <param name="songCount">Maximum number of songs to return.</param>
        /// <param name="songOffset">Search result offset for songs. Used for paging.</param>
        /// <param name="musicFolderId">Only return results from the music folder with the given ID. See getMusicFolders.</param>
        public Search2(string query,string artistCount = "20",string artistOffset = "0",string albumCount = "20",string albumOffset = "0",string songCount = "20",string songOffset = "0",string musicFolderId = null)
           : base(nameof(query), query,
                 nameof(artistCount),artistCount,
                 nameof(artistOffset),artistOffset,
                 nameof(albumCount),albumCount,
                 nameof(albumOffset),albumOffset,
                 nameof(songCount),songCount,
                 nameof(songOffset),songOffset,
                 nameof(musicFolderId),musicFolderId)
        {

        }
        public Search2Response Response
        {
            get
            {
                return (Search2Response)_response;
            }
        }
        public override string method
        {
            get
            {
                return "Search2.view";
            }
        }
    }
}

