using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePlusPlus.Contract
{
    public class FaceSetResult
    {
        public FaceSetResult()
        {

        }

        public string request_id { get; set; }

        public string faceset_token { get; set; }

        public string outer_id { get; set; }

        public string display_name { get; set; }

        public string user_data { get; set; }

        public string tags { get; set; }

        public int face_added { get; set; }

        public int face_removed { get; set; }

        public int face_count { get; set; }

        public string[] face_tokens { get; set; }

        public FaceSetCreateResultFailure[] failure_detail { get; set; }

        public int time_used { get; set; }

        public string error_message { get; set; }
    }

    public class FaceSetCreateResultFailure
    {
        public FaceSetCreateResultFailure()
        {

        }

        public string face_token { get; set; }

        public string reason { get; set; }
    }
}
