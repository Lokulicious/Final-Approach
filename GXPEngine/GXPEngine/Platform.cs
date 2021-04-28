using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;


    class Platform : Sprite
    {
    private Player player;

    public Platform(Player player) : base("colors.png")
    {
        SetOrigin(0, height / 2);
        this.x = game.width / 2 - width * 5;
        this.y = game.height / 2 + 90;
        SetScaleXY(10, 1);

        this.player = player;
    }



    void OnCollision(GameObject other)
    {
        if (other is Player)
        {
            Player player = other as Player;
            player.isGrounded = true;

/*            if (player.y + 32 < this.y)
            {
                player.y = this.y - 64;
            }*/
        }

        if (other is Crate)
        {
            Crate crate = other as Crate;
            crate.isGrounded = true;
        }
    }




    }