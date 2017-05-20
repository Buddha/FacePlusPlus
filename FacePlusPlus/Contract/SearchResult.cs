using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePlusPlus.Contract
{
    public class SearchResult
    {
        public SearchResult()
        {

        }

        public string request_id { get; set; }

        public SearchResults results { get; set; }

        public Thresholds thresholds { get; set; }

        public string image_id { get; set; }

        public Face[] faces { get; set; }

        public int time_used { get; set; }

        public string error_message { get; set; }
    }

    public class SearchResults
    {
        public SearchResults()
        {

        }

        public string face_token { get; set; }

        public double confidence { get; set; }

        public string user_id { get; set; }
    }
}
