using System;
using System.Collections.Generic;
using System.Text;

namespace AI_MasterControl.Element
{
    public class ElementArrow:Element
    {
        public Int32 dx;
        public Int32 dy;
        public Int32 ap;
        public Int32 ad;
        public ElementArrow(Int32 type,Int32 x,Int32 y,ElementColor color,Int32 dx,Int32 dy,Int32 ap,Int32 ad) : base(type, color, x, y)
        {
            this.dx = dx;
            this.dy = dy;
            this.ap = ap;
            this.ad = ad;
        }
    }
}
