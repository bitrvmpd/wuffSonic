using System;
using System.Collections.Generic;
using System.Text;
using wuffSonic.Models;
using Xunit;

namespace wuffSonic.Tests.xUnit
{
    public class AlbumSongLists : APITests
    {
        public AlbumSongLists() : base() { }
        #region GetAlbumList
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
        #endregion
        #region GetAlbumList2
        [Fact]
        public void GetAlbumList2_alpabheticalByArtist()
        {
            GetAlbumList2 al = new GetAlbumList2(ListType2.alphabeticalByArtist)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList2_alphabeticalByName()
        {
            GetAlbumList2 al = new GetAlbumList2(ListType2.alphabeticalByName)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList2_frequent()
        {
            GetAlbumList2 al = new GetAlbumList2(ListType2.frequent)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }

        [Fact]
        public void GetAlbumList2_newest()
        {
            GetAlbumList2 al = new GetAlbumList2(ListType2.newest)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList2_random()
        {
            GetAlbumList2 al = new GetAlbumList2(ListType2.random)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList2_recent()
        {
            GetAlbumList2 al = new GetAlbumList2(ListType2.recent)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList2_starred()
        {
            GetAlbumList2 al = new GetAlbumList2(ListType2.starred)
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList2_genre()
        {
            GetAlbumList2 al = new GetAlbumList2(genre: "rock")
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetAlbumList2_year()
        {
            GetAlbumList2 al = new GetAlbumList2(fromYear: "1990", toYear: "2015")
            {
                Credentials = c
            };
            var response = al.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        #endregion
        #region GetNowPlaying
        [Fact]
        public void GetNowPlaying()
        {
            GetNowPlaying np = new GetNowPlaying()
            {
                Credentials = c
            };
            var response = np.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        #endregion
        #region GetRandomSongs
        [Fact]
        public void GetRandomSongs()
        {
            GetRandomSongs rs = new GetRandomSongs()
            {
                Credentials = c
            };
            var response = rs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetRandomSongs_MaxSize()
        {
            GetRandomSongs rs = new GetRandomSongs("11")
            {
                Credentials = c
            };

            var response = rs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetRandomSongs_genre()
        {
            GetRandomSongs rs = new GetRandomSongs(genre: "rock")
            {
                Credentials = c
            };
            var response = rs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetRandomSongs_year()
        {
            GetRandomSongs rs = new GetRandomSongs(fromYear: "1990", toYear: "2019")
            {
                Credentials = c
            };
            var response = rs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetRandomSongs_musicFolderId()
        {
            GetMusicFolders mf = new GetMusicFolders() { Credentials = c };
            var mfResponse = mf.DoRequest().GetAwaiter().GetResult();

            GetRandomSongs rs = new GetRandomSongs(musicFolderId: mfResponse.musicFolders.musicFolder[0].id)
            {
                Credentials = c
            };
            var response = rs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        #endregion
        #region GetSongsByGenre
        [Fact]
        public void GetSongsByGenre()
        {

            GetSongsByGenre rs = new GetSongsByGenre("rock")
            {
                Credentials = c
            };
            var response = rs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetSongsByGenre_count()
        {

            GetSongsByGenre rs = new GetSongsByGenre("rock", count: "11")
            {
                Credentials = c
            };
            var response = rs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetSongsByGenre_offset()
        {

            GetSongsByGenre rs = new GetSongsByGenre("rock", offset: "1")
            {
                Credentials = c
            };
            var response = rs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetSongsByGenre_musicFolderId()
        {
            GetMusicFolders mf = new GetMusicFolders() { Credentials = c };
            var mfResponse = mf.DoRequest().GetAwaiter().GetResult();

            GetSongsByGenre rs = new GetSongsByGenre("rock", mfResponse.musicFolders.musicFolder[0].id)
            {
                Credentials = c
            };
            var response = rs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        #endregion
        #region GetStarred
        [Fact]
        public void GetStarred()
        {
            GetStarred gs = new GetStarred()
            {
                Credentials = c
            };
            var response = gs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetStarred_musicFolderId()
        {
            GetMusicFolders mf = new GetMusicFolders() { Credentials = c };
            var mfResponse = mf.DoRequest().GetAwaiter().GetResult();

            GetStarred gs = new GetStarred(mfResponse.musicFolders.musicFolder[0].id)
            {
                Credentials = c
            };
            var response = gs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        #endregion
        #region GetStarred2
        [Fact]
        public void GetStarred2()
        {
            GetStarred2 gs = new GetStarred2()
            {
                Credentials = c
            };
            var response = gs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        [Fact]
        public void GetStarred2_musicFolderId()
        {
            GetMusicFolders mf = new GetMusicFolders() { Credentials = c };
            var mfResponse = mf.DoRequest().GetAwaiter().GetResult();

            GetStarred2 gs = new GetStarred2(mfResponse.musicFolders.musicFolder[0].id)
            {
                Credentials = c
            };
            var response = gs.DoRequest().GetAwaiter().GetResult();

            Assert.Equal<string>(expected, response.status);
        }
        #endregion
    }
}
