using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20521363.Model
{
    internal class Animals
    {
        public string Name { set; get; }
        public Image Picture { set; get; }
        public string IPA { set; get; }
        public string Sound { set; get; }


        public Animals(string name, string iPA, Image picture, string sound)
        {
            Name = name; Picture = picture; Sound = sound;
            IPA = iPA;
        }
    }
}
