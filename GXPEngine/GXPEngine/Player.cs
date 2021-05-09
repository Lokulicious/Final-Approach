using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;


    class Player : Sprite
    {



    public bool isActive;
    public bool isPulling;
    public bool isPushing;
    public bool polaritySwitch;

    Sound jumpSound;
    SoundChannel vfx;


    //Movement

    public bool isGrounded; //checks if player is on the ground
    public float speed; //max speed
    float walkAccel; //accel on ground
    float airAccel; //accel in air
    float decel; //decel when not trying to move
    float jumpHeight; //max jump height
    public float gravity; //gravity of the player
    public Vec2 Velocity; //velocity of character
    public float pullCharge; //the charge of the magnet
    public float pushCharge;
    float discharge; //the amount the charge goes down by every tick


    //Collisions
    Collider playerCollider;
    ColliderManager engine;


    public Player(Vec2 startPosition) : base("square.png") 
    {
        SetOrigin(width / 2, height / 2);
        this.x = startPosition.x;
        this.y = startPosition.y;


        vfx = new SoundChannel(0);

        jumpSound = new Sound("Jump_Sound.wav", false, false);


        playerCollider = new AABB(this, startPosition, width / 2, height / 2);
        engine = ColliderManager.main;
        engine.AddTriggerCollider(playerCollider);


        isActive = true;
        isPulling = true;


        isGrounded = true;
        speed = 0;
        walkAccel = 75;
        airAccel = 30;
        decel = 0.8f;
        jumpHeight = 100;
        gravity = 0.35f;
        pullCharge = 100f;
        pushCharge = 100f;
        discharge = 1f;
    }


    void Update()
    {
        magnetism();
        movement();
    }



    void magnetism()
    {


        float charge = isPulling ? pullCharge : pushCharge;

        if (Input.GetKey(Key.R) && isGrounded && charge > 0f)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }



        if (isActive)
        {
            if (isPulling)
            {
                isPushing = false;
                pullCharge -= discharge;
            }
            else if (isPushing)
            {
                isPulling = false;
                pushCharge -= discharge;
            }

        }



        if (polaritySwitch && isPulling)
        {
            isPulling = false;
            isPushing = true;
            polaritySwitch = false;
        }
        else if (polaritySwitch && isPushing)
        {
            isPushing = false;
            isPulling = true;
            polaritySwitch = false;
        }
    }


    void movement()
    {
        if (isGrounded)
        {
            Console.WriteLine("grounded");

            if (Input.GetKeyDown(Key.SPACE)) 
            {
                Velocity.y = -Mathf.Sqrt(2 * jumpHeight * gravity);
                jumpSound.Play(false, 0);
                Console.WriteLine("Jumping");
            }
        }
        else
        {
            Velocity.y += gravity;
        }




        float acceleration = isGrounded ? walkAccel : airAccel;
        float deceleration = isGrounded ? decel : 0f;

        if (Input.GetKey(Key.A))
        {
            speed = -3f;
            Velocity.x = -10;
        }
        else if (Input.GetKey(Key.D))
        {
            speed = 3f;
            Velocity.x = 10;
        }



        if (Velocity.x != 0)
        {
            if (Velocity.x >= 0)
            {
                Velocity.x -= decel;
            }
            else
            {
                Velocity.x += decel;
            }

        }


        engine.MoveUntilCollision(playerCollider, new Vec2(Velocity.x, 0)); //move collider on x axis
        engine.MoveUntilCollision(playerCollider, new Vec2(0, Velocity.y)); //move collider on y axis

        x = playerCollider.position.x;
        y = playerCollider.position.y;

        /*        Translate(Velocity.x * Time.deltaTime, Velocity.y * Time.deltaTime); //move player

                playerCollider.position.x = x;
                playerCollider.position.y = y;*/


        isGrounded = false;
    }





    }
