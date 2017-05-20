using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePlusPlus.Contract
{
    public class FaceAttributes
    {
        public FaceAttributes()
        {

        }

        public Gender gender { get; set; }

        public Age age { get; set; }

        public Smile smile { get; set; }

        public Glass glass { get; set; }

        public HeadPose headpose { get; set; }

        public Blur blur { get; set; }

        public EyeStatus eyestatus { get; set; }

        public FaceQuality facequality { get; set; }

        public Ethnicity ethnicity { get; set; }
    }

    public class Gender
    {
        public Gender()
        {

        }

        public string value { get; set; }
    }

    public class Age
    {
        public Age()
        {

        }

        public int value { get; set; }
    }

    public class Smile
    {
        public Smile()
        {

        }

        public double value { get; set; }

        public double threshold { get; set; }
    }

    public class Glass
    {
        public Glass()
        {

        }

        public string value { get; set; }
    }

    public class HeadPose
    {
        public HeadPose()
        {

        }

        public double pitch_angle { get; set; }

        public double roll_angle { get; set; }

        public double yaw_angle { get; set; }
    }

    public class Blur
    {
        public Blur()
        {

        }

        public MotionBlur motionblur { get; set; }

        public Gaussianblur gaussianblur { get; set; }

        public Blurness blueness { get; set; }
    }

    public class EyeStatus
    {
        public EyeStatus()
        {

        }


    }

    public class FaceQuality
    {
        public FaceQuality()
        {

        }

        public double value { get; set; }

        public double threshold { get; set; }
    }

    public class Ethnicity
    {
        public Ethnicity()
        {

        }

        public string value { get; set; }
    }

    public class Blurness
    {
        public Blurness()
        {

        }

        public double value { get; set; }

        public double threshold { get; set; }
    }

    public class MotionBlur
    {
        public MotionBlur()
        {

        }

        public double value { get; set; }

        public double threshold { get; set; }
    }

    public class Gaussianblur
    {
        public Gaussianblur()
        {

        }

        public double value { get; set; }

        public double threshold { get; set; }
    }
}
