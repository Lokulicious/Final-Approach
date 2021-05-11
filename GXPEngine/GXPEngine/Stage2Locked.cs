using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Stage2Locked : Sprite
{

    public Stage2Locked(Vec2 position) : base("Stage_2_locked.png")
    {
        SetOrigin(width / 2, height / 2);
        x = position.x;
        y = position.y;
    }

}
