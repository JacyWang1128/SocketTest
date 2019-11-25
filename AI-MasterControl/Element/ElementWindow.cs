﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AI_MasterControl.Element
{
    public class ElementWindow:Element
    {
        Int32 dx;
        Int32 dy;
        public ElementWindow(Int32 type,Int32 x,Int32 y,ElementColor color,Int32 dx,Int32 dy) : base(type, color, x, y)
        {
            this.dx = dx;
            this.dy = dy;
        }
    }
}
