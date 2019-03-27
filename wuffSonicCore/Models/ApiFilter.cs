using System;
using System.Collections.Generic;
using System.Linq;

namespace wuffSonic.ApiInfo
{
    /// <summary>
    /// This class will create an exception if the method called doesn't exists
    /// on the defined api version. If the method exists it will
    /// filter each param. 
    /// For more info visit: http://www.subsonic.org/pages/api.jsp
    /// </summary>
    public static class ApiFilter
    {
        #region Api static definitions
        static ApiVersion[] ApiInfo = new ApiVersion[]{

            #region 1.0.0
            new ApiVersion {
                Version = "1.0.0",
                Methods = new ApiMethods[]{
                    new ApiMethods{
                        Name = "Ping"
                    },
                    new ApiMethods{
                        Name = "GetLicense"
                    },
                    new ApiMethods{
                        Name= "GetMusicFolders"
                    },
                    new ApiMethods{
                        Name = "GetIndexes",
                        Parameters = new string[]{
                            "musicFolderId", "ifModifiedSince"
                        }
                    },
                    new ApiMethods{
                        Name = "GetMusicDirectory",
                        Parameters = new string[]{
                            "id"
                        }
                    },
                    new ApiMethods{
                        Name = "GetNowPlaying"
                    },
                    new ApiMethods{
                        Name= "GetPlaylists",
                        Parameters = new string[] {
                            "username"
                        }
                    },
                    new ApiMethods{
                        Name= "GetPlaylist",
                        Parameters = new string[] {
                            "id"
                        }
                    },
                    new ApiMethods{
                        Name= "Stream",
                        Parameters = new string[] {
                            "id","maxBitRate","format","timeOffset",
                            "size","estimateContentLength","converted"
                        }
                    },
                    new ApiMethods{
                        Name= "Download",
                        Parameters = new string[] {
                            "id"
                        }
                    },
                    new ApiMethods{
                        Name= "GetCoverArt",
                        Parameters = new string[] {
                            "id", "size"
                        }
                    }
                }
            },
            #endregion
            #region 1.1.0
            new ApiVersion {
                Version = "1.1.0",
                Methods = new ApiMethods[]{
                    new ApiMethods{},
                    new ApiMethods{},
                    new ApiMethods{}
                }
            },
            #endregion
            #region 1.1.1
            new ApiVersion {
                Version = "1.1.1",
                Methods = new ApiMethods[]{
                    new ApiMethods{},
                    new ApiMethods{},
                    new ApiMethods{}
                }
            }
            #endregion
        };
        #endregion
        /// <summary>
        /// Validate the specified version and parameters.
        /// </summary>
        /// <returns>The filtered parameter list</returns>
        /// <param name="version">Version.</param>
        /// <param name="parameters">Parameters.</param>
        public static string[] Validate<T>(string version, string[] parameters)
        {
            // Step 0: I'm in the latest version?
            if (version == ApiInfo[ApiInfo.Length - 1].Version)
                return parameters;

            // Step 1: Nope, When this method was added?.
            string addedIn = (from a in ApiInfo
                             from m in a.Methods
                             where m.Name == typeof(T).Name
                              select a.Version).First() ?? null;

            // Step 2: Do I have this version?.
            bool hasVersion = HasVersion(version, addedIn);
            // Step 2.a: Nope, return null.            
            if (!hasVersion)
                return null;
            // Step 2.b: Yes, Check parameters!
            // Step 3: Get all params of this function up to the version I'm asking.
            // Step 4: Delete parameters which are an excess.

            return null;
        }

        private static bool HasVersion(string currentVer,string version){
            Version v1 = new Version(currentVer);
            Version v2 = new Version(version);
            // Lower or equal my currentVer = has this version.
            return v1.CompareTo(version) <= 0;
        }
    }

    public class ApiVersion
    {
        public string Version { get; set; }
        public ApiMethods[] Methods { get; set; }
    }

    public class ApiMethods
    {
        public string Name { get; set; }
        public string[] Parameters { get; set; }
    }
}
