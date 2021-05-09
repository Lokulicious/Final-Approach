using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;


    class Platform : Sprite
    {
    private Player player;

    public bool platformCollision;

    Collider platformCollider;
    CollisionManager engine;


    public Platform(Player player, float x, float y) : base("colors.png")
    {
        SetOrigin(0, height / 2);
        this.x = x + game.width / 2 - width * 5;
        this.y = y + game.height / 2 + 90;
        SetScaleXY(10, 1);

        this.player = player;

        platformCollider = new BoxCollider(this);
        engine = new CollisionManager();
    }



    void Update()
    {
        GroundTest();
    }


    void GroundTest()
    {
        if (HitTest(player)/* && player.y > this.y*/)
        {
            player.isGrounded = true;
            Console.WriteLine("grounded");
        }   
    }


    void OnCollision(GameObject other)
    {
/*        if (other is Player)
        {

            Player player = other as Player;
            player.isGrounded = true;

            Console.WriteLine("isGrounded = " + player.isGrounded);
*//*            if (player.y + 32 < this.y)
            {
                player.y = this.y - 64;
            }*//*
        }*/

        if (other is Crate)
        {
            Crate crate = other as Crate;
            crate.isGrounded = true;
        }
    }




    bool HitTest(Collider other)
    {
        if (other == player.playerCollider)
        {
/*            Player player = other as Player;*/
            player.isGrounded = true;
            Console.WriteLine("grounded");
            return true;
        }
        return false;
    }






}