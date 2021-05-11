using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Stage1Select : Sprite
{
    public Stage1Select(float _x, float _y) : base("Stage1Locked.png")
    {
        SetOrigin(width / 2, height / 2);
        x = _x;
        y = _y;

    }


}

