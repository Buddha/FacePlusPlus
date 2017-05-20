using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePlusPlus.Contract
{
    public class Face
    {
        public Face()
        {

        }

        public string face_token { get; set; }

        public FaceRectangle face_rectangle { get; set; }

        public FaceLandmarks landmark { get; set; }

        public FaceAttributes attributes { get; set; }
    }
}
