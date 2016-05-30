using System;
using System.Collections.Generic;
using System.Text;

namespace EmotionsX.Models
{
    public class Emotion
    {
        public Facerectangle faceRectangle { get; set; }
        public Scores scores { get; set; }
    }

    public class Facerectangle
    {
        public int height { get; set; }
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
    }

    public class Scores
    {
        public float anger { get; set; }
        public float contempt { get; set; }
        public float disgust { get; set; }
        public float fear { get; set; }
        public float happiness { get; set; }
        public float neutral { get; set; }
        public float sadness { get; set; }
        public float surprise { get; set; }
    }
}

