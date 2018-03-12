using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication22
{
    class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double escalar { get; set; }

        public Vector2D() {
            //origem do referencial
            X = 0;
            Y = 0;
        }

        public Vector2D(Vector2D v)
        {
            //qualquer objeto vector2d
            X = v.X;
            Y = v.Y;
        }
    }
}
