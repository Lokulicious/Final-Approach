using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class LevelButton : Sprite
{
    public LevelButton(Vec2 position) : base("LevelImage.png")
    {
        SetOrigin(width / 2, height / 2);
        x = position.x;
        y = position.y;
    }
}
