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
}
