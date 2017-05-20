using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePlusPlus.Contract
{
    public class SetUserIDResult
    {
        public SetUserIDResult()
        {

        }

        public string request_id { get; set; }

        public string face_token { get; set; }

        public string user_id { get; set; }

        public int time_used { get; set; }

        public string error_message { get; set; }
    }
}
