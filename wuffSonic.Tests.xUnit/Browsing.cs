using System;
using System.Collections.Generic;
using System.Text;
using wuffSonic.Models;
using Xunit;

namespace wuffSonic.Tests.xUnit
{
    public class Browsing : APITests
    {
        public Browsing() : base() { }

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
        public void GetAlbumInfo()
        {
            //Arrange
            GetAlbumList al = new GetAlbumList(ListType.random)
            {
                Credentials = c
            };

            var response1 = al.DoRequest().GetAwaiter().GetResult();
            GetAlbumInfo ai = new GetAlbumInfo(id: response1.albumList.album[0].id)
            {
                Credentials = c
            };

            //Act
            var response = ai.DoRequest().GetAwaiter().GetResult();

            //Assert
            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumInfo2()
        {
            //Arrange
            GetAlbumList al = new GetAlbumList(ListType.random)
            {
                Credentials = c
            };

            var response1 = al.DoRequest().GetAwaiter().GetResult();
            GetAlbumInfo2 ai2 = new GetAlbumInfo2(id: "4") //Hard coded for now.
            {
                Credentials = c
            };

            //Act
            var response = ai2.DoRequest().GetAwaiter().GetResult();

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
    }
}
