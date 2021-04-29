using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;

    class Crate : Sprite
    {

        private Player player;


    public bool isGrounded; //checks if player is on the ground
    public float speed; //max speed


    bool isTouching;
    public float gravity;
    float acceleration;

    public Vector2 velocity;

        public Crate(Player player, float x, float y) : base("square.png")
        {
            SetOrigin(width / 2, height / 2);
            gravity = 0.05f;

        isTouching = false;

        this.x = x + game.width / 2 + 100;
        this.y = y + game.height / 2;

        acceleration = 0.2f;
        this.player = player;
            isGrounded = false;
            speed = 0;

            gravity = 0.05f;

    }


        void Update()
        {
            movement();
            isTouching = false;
        }


        void movement()
        {
            if (player.isActive && !isTouching)
            {
                if (player.isPulling)
                {
                    if (this.x < player.x)
                    {
                        velocity.x = 1;
                    }
                    else if (this.x > player.x)
                    {
                        velocity.x = -1;
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
