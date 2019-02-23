using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic
{
    public abstract class Request<T> : IRequest
    {
        public Dictionary<string, string> Parameters { get; set; }
        public virtual string method { get; }
        public Credentials Credentials { get; set; }

        public object _response;

        public Request(params string[] args)
        {
            Parameters = new Dictionary<string, string>();
            if (args != null)
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    if (args[i] != null && args[i + 1] != null)
                        Parameters.Add(args[i], args[i + 1]);
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
            if (Parameters != null)
            {
                foreach (var item in Parameters)
                {
                    param += String.Format("&{0}={1}",
                        item.Key,
                        item.Value);
                }
            }
            if (Version.Parse(Credentials.version) >= Version.Parse("1.13.0"))
            {
                Credentials.RegenerateSalt();
                return String.Format("{0}/rest/{1}?u={2}&s={3}&t={4}&c={5}&v={6}{7}",
                    Credentials.uri,
                    method,
                    Credentials.user,
                    Credentials.salt,
                    Credentials.token,
                    Credentials.appName,
                    Credentials.version,
                    param);
            }
            else
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
            string requestUrl = getRequest(); //Only for debugging purposes
            string response = await rqst.GetStringAsync(requestUrl);
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
}