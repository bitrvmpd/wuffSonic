using System;
using wuffSonic;
using wuffSonic.Models;
using Xunit;

namespace wuffSonic.Tests.xUnit
{
    public class APITests
    {
        static string version = "1.13.0";
        static string expected = "ok";
        static Credentials c = new Credentials(
                appName: "wuffSonic",
                user: "guest2",
                password: "guest",
                version: version,
                uri: "http://demo.subsonic.org"
                );

        [Fact]
        public void Ping_WithValidCredentials()
        {
            //Arrange
            Ping p = new Ping()
            {
                Credentials = c
            };
            string expectedStatus = "ok";
            //Act
            var response = p.DoRequest().Result;
            //Assert
            Assert.Equal<string>(expectedStatus, response.status);
        }

        [Fact]
        public void Ping_WithInvalidCredentials()
        {
            //Arrange
            Credentials c = new Credentials(
                appName: "wuffSonic",
                user: "edo",
                password: "00000ddddd",
                version: version,
                uri: "http://demo.subsonic.org"
                );
            Ping p = new Ping()
            {
                Credentials = c
            };

            //Assert
            Assert.Throws<SubsonicException>(() =>
            {
                //Act
                p.DoRequest().GetAwaiter().GetResult();
            });
        }

        [Fact]
        public void Ping_NoCredentials()
        {
            //Arrange            
            Ping p = new Ping();

            //Assert
            Assert.Throws<SubsonicException>(() =>
            {
                //Act
                p.DoRequest().GetAwaiter().GetResult();
            });
        }

        [Fact]
        public void GetLicense()
        {
            //Arrange
            GetLicense l = new GetLicense()
            {
                Credentials = c
            };

            //Act
            var response = l.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetMusicFolders()
        {
            //Arrange
            GetMusicFolders mf = new GetMusicFolders()
            {
                Credentials = c
            };

            //Act
            var response = mf.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetIndexes()
        {
            //Arrange
            GetIndexes i = new GetIndexes()
            {
                Credentials = c
            };

            //Act
            var response = i.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetMusicDirectory()
        {
            GetIndexes i = new GetIndexes()
            {
                Credentials = c
            };

            var response = i.DoRequest().GetAwaiter().GetResult();

            //Arrange
            GetMusicDirectory md = new GetMusicDirectory(response.indexes.index[0].artist[0].id)
            {
                Credentials = c
            };

            //Act
            var response2 = md.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response2.status);
        }
        [Fact]
        public void GetGenres()
        {
            //Arrange
            GetGenres g = new GetGenres()
            {
                Credentials = c
            };

            //Act
            var response = g.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetArtists()
        {
            //Arrange
            GetArtists a = new GetArtists()
            {
                Credentials = c
            };

            //Act
            var response = a.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetArtist()
        {
            GetArtists ar = new GetArtists()
            {
                Credentials = c
            };


            var response = ar.DoRequest().GetAwaiter().GetResult();
            //Arrange
            GetArtist a = new GetArtist(response.artists.index[0].artist[0].id)
            {
                Credentials = c
            };

            //Act
            var response2 = a.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response2.status);
        }
        [Fact]
        public void GetAlbum()
        {
            GetArtists ar = new GetArtists()
            {
                Credentials = c
            };

            var response = ar.DoRequest().GetAwaiter().GetResult();

            GetArtist a = new GetArtist(response.artists.index[0].artist[0].id)
            {
                Credentials = c
            };

            var response2 = a.DoRequest().GetAwaiter().GetResult();

            //Arrange
            GetAlbum al = new GetAlbum(response2.artist.album[0].id)
            {
                Credentials = c
            };

            //Act
            var response3 = al.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response3.status);
        }
        [Fact]
        public void GetSong()
        {
            GetArtists ar = new GetArtists()
            {
                Credentials = c
            };

            var response = ar.DoRequest().GetAwaiter().GetResult();

            GetArtist a = new GetArtist(response.artists.index[0].artist[0].id)
            {
                Credentials = c
            };

            var response2 = a.DoRequest().GetAwaiter().GetResult();

            //Arrange
            GetAlbum al = new GetAlbum(response2.artist.album[0].id)
            {
                Credentials = c
            };

            //Act
            var response3 = al.DoRequest().GetAwaiter().GetResult();

            //Arrange
            GetSong s = new GetSong(response3.album.song[0].id)
            {
                Credentials = c
            };
            //Act
            var response4 = s.DoRequest().GetAwaiter().GetResult();
            //Assert
            Assert.Equal<string>(expected, response3.status);
        }
        [Fact]
        public void GetVideos()
        {
            //Arrange
            GetVideos v = new GetVideos()
            {
                Credentials = c
            };

            //Act
            var response = v.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetArtistInfo()
        {
            GetArtists ar = new GetArtists()
            {
                Credentials = c
            };

            var response = ar.DoRequest().GetAwaiter().GetResult();
            //Arrange
            GetArtistInfo ai = new GetArtistInfo(response.artists.index[0].artist[0].id)
            {
                Credentials = c
            };
            //Act
            var response2 = ai.DoRequest().GetAwaiter().GetResult();
            //Assert
            Assert.Equal<string>(expected, response2.status);
        }
        [Fact]
        public void GetArtistInfo2()
        {
            GetArtists ar = new GetArtists()
            {
                Credentials = c
            };

            var response = ar.DoRequest().GetAwaiter().GetResult();
            //Arrange
            GetArtistInfo2 ai = new GetArtistInfo2(response.artists.index[0].artist[0].id)
            {
                Credentials = c
            };
            //Act
            var response2 = ai.DoRequest().GetAwaiter().GetResult();
            //Assert
            Assert.Equal<string>(expected, response2.status);
        }
        [Fact]
        //[ExpectedException(typeof(SubsonicException))]
        public void GetSimilarSongs()
        {
            GetArtists ar = new GetArtists()
            {
                Credentials = c
            };

            var response = ar.DoRequest().GetAwaiter().GetResult();
            //Arrange

            GetSimilarSongs ss = new GetSimilarSongs(response.artists.index[0].artist[0].id)
            {
                Credentials = c
            };

            //Act
            var response2 = ss.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response2.status);
        }
        [Fact]
        //[ExpectedException(typeof(SubsonicException))]
        public void GetSimilarSongs2()
        {
            GetArtists ar = new GetArtists()
            {
                Credentials = c
            };

            var response = ar.DoRequest().GetAwaiter().GetResult();
            //Arrange

            GetSimilarSongs2 ss = new GetSimilarSongs2(response.artists.index[0].artist[0].id)
            {
                Credentials = c
            };

            //Act
            var response2 = ss.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response2.status);
        }
        [Fact]
        //[ExpectedException(typeof(SubsonicException))]
        public void GetTopSongs()
        {
            GetArtists ar = new GetArtists()
            {
                Credentials = c
            };

            var response = ar.DoRequest().GetAwaiter().GetResult();
            //Arrange
            GetTopSongs ss = new GetTopSongs(response.artists.index[0].artist[0].name)
            {
                Credentials = c
            };
            //Act
            var response2 = ss.DoRequest().GetAwaiter().GetResult();
            //Assert
            Assert.Equal<string>(expected, response2.status);
        }
        [Fact]
        public void GetAlbumList_alpabheticalByArtist()
        {
            GetAlbumList al = new GetAlbumList(ListType.alphabeticalByArtist)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList_alphabeticalByName()
        {
            GetAlbumList al = new GetAlbumList(ListType.alphabeticalByName)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList_frequent()
        {
            GetAlbumList al = new GetAlbumList(ListType.frequent)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList_highest()
        {
            GetAlbumList al = new GetAlbumList(ListType.highest)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList_newest()
        {
            GetAlbumList al = new GetAlbumList(ListType.newest)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList_random()
        {
            GetAlbumList al = new GetAlbumList(ListType.random)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList_recent()
        {
            GetAlbumList al = new GetAlbumList(ListType.recent)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList_starred()
        {
            GetAlbumList al = new GetAlbumList(ListType.starred)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList_genre()
        {
            GetAlbumList al = new GetAlbumList(genre: "rock")
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList_year()
        {
            GetAlbumList al = new GetAlbumList(fromYear: "1990", toYear: "2015")
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetVideoInfo()
        {
            //Arrange
            GetVideos v = new GetVideos()
            {
                Credentials = c
            };

            var response1 = v.DoRequest().GetAwaiter().GetResult();
            GetVideoInfo vi = new GetVideoInfo(id: response1.videos.video[0].id.ToString())
            {
                Credentials = c
            };
            
            //Act
            var response = vi.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response.status);
        }
    }
}
