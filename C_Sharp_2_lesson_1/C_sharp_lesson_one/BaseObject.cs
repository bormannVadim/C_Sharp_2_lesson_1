using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C_sharp_lesson_one
{
    abstract class  BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
   
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();


        public abstract void Update();

       
    }

}
