using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePlusPlus.Contract
{
    public class Error
    {
        public Error()
        {

        }

        public int time_used { get; set; }

        public int error_message { get; set; }

        public string request_id { get; set; }
    }
}
