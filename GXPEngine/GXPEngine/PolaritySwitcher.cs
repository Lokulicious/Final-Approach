using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


class PolaritySwitcher : Sprite
{
    private Player player;
    public bool isUsed;

    public PolaritySwitcher(Player player, float x, float y) : base("checkers.png")
    {

        SetOrigin(width / 2, height / 2);
        this.x = x;
        this.y = y;
        this.player = player;
    }




    void OnCollision(GameObject other)
    {
        if (other is Player && !isUsed)
        {
            player.polaritySwitch = true;
            isUsed = true;
            Console.WriteLine("switch");
        }
    }
}
