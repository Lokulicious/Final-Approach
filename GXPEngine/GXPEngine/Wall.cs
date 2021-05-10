using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;


    class Wall : Sprite
    {
    private Player player;


    Collider wallCollider;
    ColliderManager engine;


    public Wall(Player player, Vec2 position, float heightScale) : base("colors.png")
    {
        SetOrigin(width / 2, height / 2);
        SetScaleXY(1, heightScale);

        this.x = position.x;
        this.y = position.y;



        float colliderWidth = (width / 2);
        float colliderHeight = (height / 2) - 2;

        this.player = player;


        wallCollider = new AABB(this, position, colliderWidth, colliderHeight);
        engine = ColliderManager.main;
        engine.AddSolidCollider(wallCollider);
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