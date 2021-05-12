using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


class Goal : AnimationSprite
{
    private Player player;

    public Goal(Player _player, Vec2 position) : base("flagnew.png", 4, 1)
    {
        SetOrigin(width / 2, height / 2);
        SetCycle(0, 8);
        SetScaleXY(0.2f, 0.2f);

        x = position.x;
        y = position.y;

        player = _player;
    }


    void Update()
    {

        Animate();
    }



    void OnCollision(GameObject other)
    {
        if (other is Player)
        {
            FinishLevel();
        }
    }


    void FinishLevel()
    {
        SetCycle(8, 8);
    }

}
