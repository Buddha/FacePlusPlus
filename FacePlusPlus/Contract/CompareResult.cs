using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePlusPlus.Contract
{
    public class CompareResult
    {
        public CompareResult()
        {

        }

        public string request_id { get; set; }

        public double confidence { get; set; }

        public Thresholds thresholds { get; set; }

        public string image_id1 { get; set; }

        public string image_id2 { get; set; }

        public Face[] faces1 { get; set; }

        public Face[] faces2 { get; set; }

        public int time_used { get; set; }

        public string error_message { get; set; }
    }
}
