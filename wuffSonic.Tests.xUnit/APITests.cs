using System;
using wuffSonic;
using wuffSonic.Models;
using Xunit;

namespace wuffSonic.Tests.xUnit
{
    public abstract class APITests
    {
        protected readonly string version = "1.14.0";
        protected readonly string expected = "ok";
        protected readonly Credentials c;

        public APITests() => c = new Credentials(
            appName: "wuffSonic",
            user: "guest2",
            password: "guest",
            version: version,
            uri: "http://demo.subsonic.org"
        );
    }
}
