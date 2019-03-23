using System;
using System.Collections.Generic;
using System.Text;
using wuffSonic.Models;
using Xunit;

namespace wuffSonic.Tests.xUnit
{
    public partial class APITests
    {
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
            Assert.Equal(expectedStatus, response.status);
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
            Assert.Equal(expected, response.status);
        }
    }
}
