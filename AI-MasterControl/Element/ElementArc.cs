﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AI_MasterControl.Element
{
    public class ElementArc:Element
    {
        public Int32 rx;
        public Int32 ry;
        public float Start_angle;
        public float End_anlge;
        public ElementArc(Int32 type,Int32 x,Int32 y,ElementColor color,Int32 rx,Int32 ry,float start_angle,float end_angle) : base(type, color, x, y)
        {
            this.rx = rx;
            this.ry = ry;
            this.Start_angle = start_angle;
            this.End_anlge = end_angle;
        }
    }
}
