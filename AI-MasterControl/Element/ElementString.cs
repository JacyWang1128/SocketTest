using System;
using System.Collections.Generic;
using System.Text;

namespace AI_MasterControl.Element
{
    class ElementString:Element
    {
        public Int32 fontsize;
        public String content;
        public ElementString(Int32 type,Int32 x,Int32 y,ElementColor color,Int32 fontsize,String content) : base(type, color, x, y)
        {
            this.fontsize = fontsize;
            this.content = content;
        }
    }
}
