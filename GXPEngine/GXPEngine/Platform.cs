using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;


    class Platform : Sprite
    {
    private Player player;

    public bool platformCollision;

    Collider platformCollider;
    Collider groundCheck;
    ColliderManager engine;



    public Platform(Player player, Vec2 position, Vec2 groundPos) : base("colors.png")
    {
        SetOrigin(width / 2, height / 2);
        this.x = position.x;
        this.y = position.y;


        groundPos.x = position.x - width / 2;
        groundPos.y = position.y - (height / 2 + 10);

        SetScaleXY(10, 1);

        this.player = player;


        platformCollider = new AABB(this, position, width / 2, height / 2);
        groundCheck = new HorizontalLineSegment(this, groundPos, width);
        engine = ColliderManager.main;
        engine.AddSolidCollider(platformCollider);
        engine.AddTriggerCollider(groundCheck);
    }



    void Update()
    {
        checkPlayerCollision();
    }



    void checkPlayerCollision()
    {
        List<Collider> overlaps = engine.GetOverlaps(groundCheck);
        foreach (Collider col in overlaps)
        {
            Console.WriteLine(col);
            if (col.owner is Player/* && !player.isGrounded*/)
            {
                player.isGrounded = true;
                Console.WriteLine("Grounded");
            }
        }
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