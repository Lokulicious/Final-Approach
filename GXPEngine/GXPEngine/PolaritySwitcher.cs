using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


class PolaritySwitcher : Sprite
{
    private Player player;
    public bool isUsed;

    public PolaritySwitcher(Player player, float x, float y) : base("polarityswitch.png")
    {
        SetScaleXY(0.1f, 0.1f);
        SetOrigin(width / 2, height / 2);
        this.x = x;
        this.y = y;
        this.player = player;
    }

    void Update()
    {

    }


    void OnCollision(GameObject other)
    {

        if (other is Player && !isUsed)
        {
            player.polaritySwitch = true;
            player.animState = 4;
            isUsed = true;

        }
        else if (other is Player)
        {
            player.animState = 4;
/*            Console.WriteLine(player.animState);*/
        }
    }
}
