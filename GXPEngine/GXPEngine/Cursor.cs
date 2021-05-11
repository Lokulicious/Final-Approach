using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Cursor : Sprite
{
    public Cursor() : base("cursor.png")
    {
        
    }

    void Update()
    {
        SetScaleXY(2f, 2f);

        this.x = Input.mouseX;
        this.y = Input.mouseY;
    }
}
