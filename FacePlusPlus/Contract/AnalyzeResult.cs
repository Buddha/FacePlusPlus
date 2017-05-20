﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePlusPlus.Contract
{
    public class AnalyzeResult
    {
        public AnalyzeResult()
        {

        }

        public string request_id { get; set; }

        public Face[] faces { get; set; }

        public int time_used { get; set; }

        public string error_message { get; set; }
    }
}
