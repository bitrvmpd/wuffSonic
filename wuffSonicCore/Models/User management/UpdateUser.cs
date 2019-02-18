using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{
    [XmlRoot(ElementName = "subsonic-response", Namespace = "http://subsonic.org/restapi")]
    public class UpdateUserResponse
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string status { get; set; }
    }
    public class UpdateUser : Request<UpdateUserResponse>
    {
        /// <summary>
        /// Modifies an existing Subsonic user, using the following parameters:
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
        /// <param name="maxBitRate">The maximum bit rate (in Kbps) for the user. Audio streams of higher bit rates are automatically downsampled to this bit rate. Legal values: 0 (no limit), 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320.</param>
        public UpdateUser(string username, string password = null, string email = null,
            string ldapAuthenticated = null, string adminRole = null,
            string settingsRole = null, string streamRole = null,
            string jukeboxRole = null, string downloadRole = null,
            string uploadRole = null, string playlistRole = null,
            string coverArtRole = null, string commentRole = null,
            string podcastRole = null, string shareRole = null,
            string musicFolderId = null, Bitrate maxBitRate = Bitrate.Kbps_0
            )
           : base(nameof(username), username, nameof(password),password ,
                  nameof(email),email,nameof(ldapAuthenticated),ldapAuthenticated,
                  nameof(adminRole),adminRole,nameof(settingsRole),settingsRole,
                  nameof(streamRole),streamRole,nameof(jukeboxRole),jukeboxRole,
                  nameof(downloadRole),downloadRole,nameof(uploadRole),uploadRole,
                  nameof(playlistRole),playlistRole,nameof(coverArtRole),coverArtRole,
                  nameof(commentRole),commentRole,nameof(podcastRole),podcastRole,
                  nameof(shareRole),shareRole,nameof(musicFolderId),musicFolderId,
                  nameof(maxBitRate),((int)maxBitRate).ToString())
        {

        }
        public UpdateUserResponse Response
        {
            get
            {
                return (UpdateUserResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "UpdateUser.view";
            }
        }              
    }

    /// <summary>
    /// The maximum bit rate (in Kbps) for the user. Audio streams of higher bit rates 
    /// are automatically downsampled to this bit rate. Legal values: 
    /// 0 (no limit), 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320.
    /// </summary>
    public enum Bitrate{
            Kbps_0 = 0,
            Kbps_32 = 32,
            Kbps_40 = 40,
            Kbps_48 = 48,
            Kbps_56 = 56,
            Kbps_64 = 64,
            Kbps_80 = 80,
            Kbps_96 = 96,
            Kbps_112 = 112,
            Kbps_128 = 128,
            Kbps_160 = 160,
            Kbps_192 = 192,
            Kbps_224 = 224,
            Kbps_256 = 256,            
            Kbps_320 = 320
        }   
}

