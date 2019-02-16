using System;
using System.Text;

public class Credentials
    {
        private string _password;
        public string uri { get; set; }
        public string version { get; set; }
        public string appName { get; set; }
        public string user { get; set; }
        public string password
        {
            get { return _password; }
            set { _password = BitConverter.ToString(Encoding.UTF8.GetBytes(value)).Replace("-", ""); }
        }

        public Credentials(string uri,string version,string appName,string user,string password)
        {
            this.uri = uri;
            this.version = version;
            this.appName = appName;
            this.user = user;
            this.password = password;
        }
    }