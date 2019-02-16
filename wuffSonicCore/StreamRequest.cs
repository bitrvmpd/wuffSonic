using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace wuffSonic
{
    public abstract class StreamRequest : IRequest
    {
        public Dictionary<string, string> Parameters { get; set; }
        public virtual Credentials Credentials { get; set; }
        public virtual string method { get; }

        public object _response;

        public StreamRequest(params string[] args)
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

        /// <summary>
        ///  Response format will always be json
        /// </summary>
        /// <returns></returns>
        public virtual string getRequest()
        {
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