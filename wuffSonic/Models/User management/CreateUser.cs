﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class CreateUserResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class CreateUser : Request
    {
        /// <summary>
        /// Creates a new Subsonic user
        /// </summary>
        /// <param name="username">The name of the new user.</param>
        /// <param name="password">The password of the new user, either in clear text of hex-encoded </param>
        /// <param name="email">The email address of the new user.</param>
        /// <param name="ldapAuthenticated">Whether the user is authenicated in LDAP.</param>
        /// <param name="adminRole">Whether the user is administrator.</param>
        /// <param name="settingsRole">Whether the user is allowed to change personal settings and password.</param>
        /// <param name="streamRole">Whether the user is allowed to play files.</param>
        /// <param name="jukeboxRole">Whether the user is allowed to play files in jukebox mode.</param>
        /// <param name="downloadRole">Whether the user is allowed to download files.</param>
        /// <param name="uploadRole">Whether the user is allowed to upload files.</param>
        /// <param name="playlistRole">Whether the user is allowed to upload files.</param>
        /// <param name="coverArtRole">Whether the user is allowed to change cover art and tags.</param>
        /// <param name="commentRole">Whether the user is allowed to create and edit comments and ratings.</param>
        /// <param name="podcastRole">Whether the user is allowed to administrate Podcasts.</param>
        /// <param name="shareRole">Whether the user is allowed to share files with anyone.</param>
        /// <param name="musicFolderId">IDs of the music folders the user is allowed access to. Include the parameter once for each folder.</param>
        public CreateUser(string username,string password,string email,
            string ldapAuthenticated = "false",string adminRole="false",
            string settingsRole = "true",string streamRole = "true",
            string jukeboxRole = "false",string downloadRole = "false",
            string uploadRole = "false",string playlistRole = "false",
            string coverArtRole = "false",string commentRole = "false",
            string podcastRole = "false",string shareRole = "false",
            string musicFolderId = null
            )
           : base(nameof(username), username, nameof(password),password ,
                  nameof(email),email,nameof(ldapAuthenticated),ldapAuthenticated,
                  nameof(adminRole),adminRole,nameof(settingsRole),settingsRole,
                  nameof(streamRole),streamRole,nameof(jukeboxRole),jukeboxRole,
                  nameof(downloadRole),downloadRole,nameof(uploadRole),uploadRole,
                  nameof(playlistRole),playlistRole,nameof(coverArtRole),coverArtRole,
                  nameof(commentRole),commentRole,nameof(podcastRole),podcastRole,
                  nameof(shareRole),shareRole,nameof(musicFolderId),musicFolderId)
        {

        }
        public CreateUserResponse Response
        {
            get
            {
                return (CreateUserResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "CreateUser.view";
            }
        }
    }
}

