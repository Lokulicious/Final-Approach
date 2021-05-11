using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;


    class Player : AnimationSprite
    {


    //magnetism
    public bool isActive;
    public bool isPulling;
    public bool isPushing;
    public bool polaritySwitch;


    //sound
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


    //crate selection
    public GameObject[] crates;
    public GameObject targetCrate;
    float magnetRange;
    float yRange;
    bool inYRange;
    float yDist;

    //animation
    public int animState;
/*    bool idle;
    bool walking;
    bool jumping;*/



    public Player(Vec2 startPosition, int amountOfCrates) : base("character_final.png", 8, 6) 
    {


        SetOrigin(width / 2, height / 2);
        SetScaleXY(0.25f, 0.25f);

        this.x = startPosition.x;
        this.y = startPosition.y;

        SetCycle(9, 21);


        vfx = new SoundChannel(0);

        jumpSound = new Sound("Jump_Sound.wav", false, false);


        playerCollider = new AABB(this, startPosition, width / 2, height / 2);
        engine = ColliderManager.main;
        engine.AddTriggerCollider(playerCollider);


        crates = new GameObject[amountOfCrates];



        isActive = true;
        isPulling = true;


        isGrounded = true;
        speed = 7f;
        walkAccel = 75;
        airAccel = 30;
        decel = 0.8f;
        jumpHeight = 180;
        gravity = 0.35f;
        pullCharge = 300f;
        pushCharge = 310f;
        discharge = 1f;


        magnetRange = 250;
        yRange = 40;

        /*        idle = true;
                walking = false;
                jumping = false;*/

        animState = 1;


    }


    void Update()
    {
        magnetism();
        movement();
        CheckNearest();
        Animation();
    }


    void Animation()
    {
        switch (animState)
        {
            case 1:
                /*                SetCycle(35, 9, 6);*/
                SetCycle(9, 21, 7);
                break;
            case 2:
                SetCycle(0, 9, 5);
                break;
            case 3:
                SetCycle(31, 4, 5);
                break;
            case 4:
                SetCycle(35, 9, 5);
                Console.WriteLine("slut");
                break;
        }
        Animate();
    }



    void magnetism()
    {
/*        Console.WriteLine(animState);*/

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

        Console.WriteLine(polaritySwitch);

        if (polaritySwitch && isPulling)
        {
            isPulling = false;
            isPushing = true;
            polaritySwitch = false;
            Console.WriteLine("switch");
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
            if (Input.GetKeyDown(Key.SPACE)) 
            {
                Velocity.y = -Mathf.Sqrt(2 * jumpHeight * gravity);
                jumpSound.Play(false, 0);
            }
        }
        else
        {
            Velocity.y += gravity;
            animState = 3;
        }





        float acceleration = isGrounded ? walkAccel : airAccel;
        float deceleration = isGrounded ? decel : 0f;

        if (Input.GetKey(Key.A))
        {
            Velocity.x = -speed;
            animState = 2;
            SetScaleXY(-0.25f, 0.25f);
        }
        else if (Input.GetKey(Key.D))
        {
            Velocity.x = speed;
            animState = 2;
            SetScaleXY(0.25f, 0.25f);
        }
        else if(isGrounded && polaritySwitch == false)
        {
            Velocity.x = 0;
            animState = 1;
        }



        if (Velocity.x != 0)
        {
            if (Velocity.x > 0)
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




    void CheckNearest()
    {

        float lowestDistance = 50000;
        
        foreach (Crate crate in crates)
        {
            float range = this.y - crate.y;

            float dist = crate.DistanceTo(this);
            if (dist < magnetRange && dist < lowestDistance && range > -yRange && range < yRange)
            {
                lowestDistance = dist;
                targetCrate = crate;
                crate.isNearest = true;
                crate.SetCycle(1, 1);
            }
            else if (dist > magnetRange || dist > lowestDistance && range < -yRange || range > yRange)
            {
                crate.isNearest = false;
                crate.SetCycle(0, 1);
            }
        }
    }




    }
