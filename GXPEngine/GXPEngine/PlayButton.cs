using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class PlayButton : AnimationSprite
{

    public int buttonState;

    public PlayButton(Vec2 position) : base("Play_button.png", 2, 1)
    {
        SetOrigin(width / 2, height / 2);
        SetCycle(0, 1);
        SetScaleXY(0.9f, 0.9f);


        x = position.x;
        y = position.y;

        buttonState = 1;
    }

    void Update()
    {
        switch (buttonState)
        {
            case 1:
                SetCycle(0, 1);
                break;
            case 2:
                SetCycle(1, 1);
                break;
        }
    }

}

