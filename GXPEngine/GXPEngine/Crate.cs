using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;

    class Crate : Sprite
    {

    private Player player;

    Collider crateCollider;
    ColliderManager engine;


    public bool isGrounded; //checks if player is on the ground
    public float speed; //max speed
    bool pushStart;

    bool isTouching;
    public float gravity;
    float acceleration;

    public Vec2 velocity;

        public Crate(Player player, Vec2 position) : base("square.png")
        {
        SetOrigin(width / 2, height / 2);
        gravity = 0.05f;

        isTouching = false;

        pushStart = false;


        this.x = position.x;
        this.y = position.y;

        /*        this.x = x + game.width / 2 + 100;
                this.y = y + game.height / 2;*/

        float colliderWidth = (width / 2);
        float colliderHeight = (height / 2) - 2;

        acceleration = 0.2f;
        this.player = player;
        isGrounded = false;
        speed = 1;

        gravity = 0.05f;
        acceleration = 0.02f;


        crateCollider = new AABB(this, position, colliderWidth, colliderHeight);
        engine = ColliderManager.main;
        engine.AddSolidCollider(crateCollider);
    }


        void Update()
        {
            movement();
            isTouching = false;
            isGrounded = false;

        }


        void movement()
        {
            if (player.isActive && !isTouching)
            {
                if (player.isPulling)
                {
                    if (this.x < player.x)
                    {
                        velocity.x += acceleration;
                    }
                    else if (this.x > player.x)
                    {
                        velocity.x -= acceleration;
                    }
                }
                else if (player.isPushing)
                {
                    if (this.x < player.x)
                    {
                    velocity.x -= acceleration;
                    }
                    else if (this.x > player.x)
                    {
                    velocity.x += acceleration;
                    }
                }
            }
        else
        {
            velocity.x = 0;
        }




        if (velocity.x != 0)
        {
            if (velocity.x >= 0)
            {
                velocity.x += acceleration;
            }
            else
            {
                velocity.x -= acceleration;
            }

        }





        if (isGrounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity;
        }
        isGrounded = false;

        Translate(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime);

       }


    void OnCollision(GameObject Other)
    {
        if (Other is Player)
        {
            isTouching = true;
            Player player = Other as Player;
            velocity.x = 0;
            /*            player.Velocity.x = 0;*/
            if (this.y > player.y)
            {
                player.isGrounded = true;
            }

        }

        if (Other is Crate)
        {
            isGrounded = true;
            this.velocity.x = 0;
            this.velocity.y = 0;
        }
    }

    }
