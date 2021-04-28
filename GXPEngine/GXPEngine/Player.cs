using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;


    class Player : Sprite
    {



    public bool isActive;
    public bool isPulling;
    public bool isPushing;


    //movement

    public bool isGrounded; //checks if player is on the ground
    public float speed; //max speed
    float walkAccel; //accel on ground
    float airAccel; //accel in air
    float decel; //decel when not trying to move
    float jumpHeight; //max jump height
    public float gravity;
    public Vector2 Velocity; // velocity of character

    public Player() : base("square.png") 
    {
        SetOrigin(width / 2, height / 2);
        this.x = game.width / 2;
        this.y = game.height / 2;

        isActive = true;
        isPulling = true;


        isGrounded = false;
        speed = 0;
        walkAccel = 75;
        airAccel = 30;
        decel = 0.5f;
        jumpHeight = 8;
        gravity = 0.05f;
    }


    void Update()
    {
        movement();
        magnetism();
    }


    void movement()
    {


        if (isGrounded)
        {
            Velocity.y = 0f;

            if (Input.GetKeyDown(Key.SPACE))
            {
                Velocity.y = -Mathf.Sqrt(2 * jumpHeight * gravity);
            }
        }
        else
        {
            Velocity.y += gravity;
        }

        isGrounded = false;

        float acceleration = isGrounded ? walkAccel : airAccel;
        float deceleration = isGrounded ? decel : 0f;

        if (Input.GetKey(Key.A))
        {
            speed = -3f;
            Velocity.x = -1;
        }
        else if (Input.GetKey(Key.D))
        {
            speed = 3f;
            Velocity.x = 1;
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
 

        Translate(Velocity.x * Time.deltaTime, Velocity.y * Time.deltaTime);
    }



    void magnetism()
    {
        if (Input.GetKeyDown(Key.F))
        {
            isPulling = false;
        }

        if (isActive)
        {
            if (isPulling)
            {
                isPushing = false;
            }
            else if (isPushing)
            {
                isPulling = false;
            }
        }


        Console.WriteLine(isPulling);
    }





    }
