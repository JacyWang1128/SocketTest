using System;
using System.Collections.Generic;
using System.Text;

namespace AI_MasterControl.Element
{
    public class ElementCircle:Element
    {
        public Int32 rx;
        public Int32 ry;
        public ElementCircle(Int32 type,Int32 x,Int32 y,ElementColor color,Int32 rx,Int32 ry) : base(type, color, x, y)
        {
            this.rx = rx;
            this.ry = ry;
        }
    }
}
