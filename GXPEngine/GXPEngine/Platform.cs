using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;


    class Platform : Sprite
    {
    private Player player;


    Collider platformCollider;
    ColliderManager engine;


    public Platform(Player player, Vec2 position, float widthScale, float heightScale) : base("platform.png")
    {
        SetOrigin(width / 2, height / 2);
        SetScaleXY(widthScale / 35, heightScale / 6);

        this.x = position.x;
        this.y = position.y;



        float colliderWidth = (width / 2) + 1;
        float colliderHeight = (height / 2) - 1;

        this.player = player;


        platformCollider = new AABB(this, position, colliderWidth, colliderHeight);
        engine = ColliderManager.main;
        engine.AddSolidCollider(platformCollider);
    }






    void OnCollision(GameObject other)
    {
        if (other is Player && other.y < this.y)
        {
            Player player = other as Player;
            player.isGrounded = true;
        }

        if (other is Crate)
        {
            Crate crate = other as Crate;
            crate.isGrounded = true;
        }
    }




    }