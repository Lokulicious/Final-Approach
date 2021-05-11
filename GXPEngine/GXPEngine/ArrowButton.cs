using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class ArrowButton : Sprite
{
    public ArrowButton(Vec2 position, bool isBack) : base("Arrow.png")
    {
        SetOrigin(width / 2, height / 2);
        SetScaleXY(0.5f, 0.5f);

        x = position.x;
        y = position.y;

        if (isBack)
        {
            SetScaleXY(-0.5f, 0.5f);
        }


    }
}
