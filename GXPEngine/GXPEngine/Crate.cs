using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;

    class Crate : AnimationSprite
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
    public bool isTouchingCrate;


    public Vec2 velocity;

    public bool isNearest;
    public float crateRange;
    public float playerDistance;
    


        public Crate(Player player, Vec2 position, string filename) : base(filename, 2, 1)
        {


        SetOrigin(width / 2, height / 2);
        SetScaleXY(0.15f, 0.15f);
        gravity = 0.05f;

        isTouching = false;
        isTouchingCrate = false;

        SetCycle(0, 1);


        pushStart = false;


        this.x = position.x;
        this.y = position.y;

        /*        this.x = x + game.width / 2 + 100;
                this.y = y + game.height / 2;*/

        float colliderWidth = (width / 2);
        float colliderHeight = (height / 2) - 1;

        acceleration = 0.2f;
        this.player = player;
        isGrounded = false;
        speed = 1;

        gravity = 0.05f;
        acceleration = 0.02f;



        crateCollider = new AABB(this, position, colliderWidth, colliderHeight);
        engine = ColliderManager.main;
        engine.AddSolidCollider(crateCollider);
        engine.AddTriggerCollider(crateCollider);
    }


        void Update()
        {


            movement();
            isTouching = false;
            isGrounded = false;
        ChangeNearestColor();
        GetDistanceToPlayer();
        }


        void movement()
        {
            if (player.isActive && isNearest)
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

        if (!isGrounded)
        {
            velocity.y += gravity;
        }
        isGrounded = false;

        /*        Translate(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime);*/


        engine.MoveUntilCollision(crateCollider, new Vec2(velocity.x, 0)); //move collider on x axis
        engine.MoveUntilCollision(crateCollider, new Vec2(0, velocity.y)); //move collider on y axis


        x = crateCollider.position.x;
        y = crateCollider.position.y;
    }






    void GetDistanceToPlayer()
    {
        if (this.x < player.x)
        {
            playerDistance = player.x - this.x;
        }
        else if (this.x > player.x)
        {
            playerDistance = this.x - player.x;
        }
    }




    void ChangeNearestColor()
    {


        //testcode to see if color change works
        /*        if (Input.GetKey(Key.F))
                {
                    isNearest = true;
                }
                else
                {
                    isNearest = false;
                }*/

        //change color if nearest
        if (isNearest)
        {
            SetCycle(1, 1);
        }
        else
        {
            SetCycle(0, 1);
        }

        
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

            if (this.y < Other.y)
            {
                isTouchingCrate = true;
            }
            else if (this.y > Other.y)
            {
                this.x = Other.x;
            }

        }
    }





    }
