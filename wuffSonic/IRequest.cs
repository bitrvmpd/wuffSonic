using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic 
{
    interface IRequest
    {
        Credentials Credentials { get; set; }
        string method { get; }       
        string getRequest();
    }

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

    public abstract class Request<T> : IRequest
    {
        public virtual Dictionary<string, string> parameters { get; set; }            
        public virtual string method { get; }
        public Credentials Credentials { get; set; }

        public object _response;

        public Request(params string[] args)
        {            
            parameters = new Dictionary<string, string>();
            if (args != null)
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    if (args[i] != null && args[i + 1] != null)
                        parameters.Add(args[i], args[i + 1]);
                }
            }
        }

        public virtual string getRequest()
        {
            if (Credentials == null)
                throw new SubsonicException()
                {
                    Error = new Error()
                    {
                        Details = new ErrorDetails() { code = "0", message = "Credentials cannot be null" },
                        status = "failed",
                        type = "wuffSonic",
                        version = "1.0.3-alpha1"
                    }
                };

            string param = "";
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    param += String.Format("&{0}={1}",
                        item.Key,
                        item.Value);
                }
            }
            return String.Format("{0}/rest/{1}?u={2}&p=enc:{3}&c={4}&v={5}{6}",
                Credentials.uri,
                method,
                Credentials.user,
                Credentials.password,
                Credentials.appName,
                Credentials.version,
                param);
        }

        public virtual async Task<T> DoRequest()
        {
            dynamic resultingMessage = (T)Activator.CreateInstance(typeof(T));
            HttpClient rqst = new HttpClient();
            string response = await rqst.GetStringAsync(getRequest());
            response = response.Replace("\n", "");


            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader rdr = new StringReader(response);
            resultingMessage = (T)serializer.Deserialize(rdr);

            if (resultingMessage.status != "ok")
            {
                throw new SubsonicException(response);
            }

            _response = resultingMessage;
            return resultingMessage;

        }
    }

    public abstract class StreamRequest : IRequest
    {
        public virtual Dictionary<string, string> parameters { get; set; }
        public virtual Credentials Credentials { get; set; }
        public virtual string method { get; }       

        public object _response;

        public StreamRequest(params string[] args)
        {
            parameters = new Dictionary<string, string>();
            if (args != null)
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    if (args[i] != null && args[i + 1] != null)
                        parameters.Add(args[i], args[i + 1]);
                }
            }
        }

        /// <summary>
        ///  Response format will always be json
        /// </summary>
        /// <returns></returns>
        public virtual string getRequest()
        {
            string param = "";
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    param += String.Format("&{0}={1}",
                        item.Key,
                        item.Value);
                }
            }
            return String.Format("{0}/rest/{1}?u={2}&p=enc:{3}&c={4}&v={5}{6}",
                Credentials.uri,
                method,
                Credentials.user,
                Credentials.password,
                Credentials.appName,
                Credentials.version,
                param);
        }

        public virtual async Task<MemoryStream> DoRequest()
        {
            HttpClient rqst = new HttpClient();
            MemoryStream memStream = new MemoryStream();
            System.IO.Stream response = await rqst.GetStreamAsync(getRequest());
            await response.CopyToAsync(memStream);
            memStream.Position = 0;
            return memStream;
        }
    }
}
