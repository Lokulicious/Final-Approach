﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;


    class Platform : Sprite
    {
    private Player player;

    public bool platformCollision;

    public Platform(Player player, float x, float y) : base("colors.png")
    {
        SetOrigin(0, height / 2);
        this.x = x + game.width / 2 - width * 5;
        this.y = y + game.height / 2 + 90;
        SetScaleXY(10, 1);

        this.player = player;
    }



    void Update()
    {

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