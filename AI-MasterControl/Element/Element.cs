using System;
using System.Collections.Generic;
using System.Text;

namespace AI_MasterControl.Element
{
    public enum ElementColor
    {
        Bad = 0,
        Good = 1,
        Standard = 2,
        Warning = 3
    }
    public class Element
    {
        public Int32 type;
        public ElementColor color;
        public Int32 x;
        public Int32 y;

        public Element(Int32 type,ElementColor color,Int32 x,Int32 y)
        {
            this.type = type;
            this.color = color;
            this.x = x;
            this.y = y;
        }
    }
}
