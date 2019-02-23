using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wuffSonic.Models
{    
    public class GetAlbumInfo2 : Request<GetAlbumInfoResponse>
    {
        /// <summary>
        /// Similar to getAlbumInfo2, but organizes music according to ID3 tags.
        /// </summary>
        /// <param name="id">The album ID.</param>
        public GetAlbumInfo2(string id)
           : base(nameof(id), id)
        {

        }
        public GetAlbumInfoResponse Response
        {
            get
            {
                return (GetAlbumInfoResponse)_response;
            }
        }
        public override string method
        {
            get
            {
                return "getAlbumInfo2";
            }
        }
    }
}

