using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePlusPlus.Contract
{
    public class FaceSet
    {
        public FaceSet()
        {

        }

        public string faceset_token { get; set; }

        public string outer_id { get; set; }

        public string display_name { get; set; }

        public string tags { get; set; }
    }
}
