﻿using System;
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
    public float gravity; //gravity of the player
    public Vector2 Velocity; //velocity of character
    public float charge; //the charge of the magnet
    float discharge; //the amount the charge goes down by every tick


    public Player() : base("square.png") 
    {
        SetOrigin(width / 2, height / 2);
        this.x = game.width / 2;
        this.y = game.height / 2;

        isActive = true;
        isPulling = true;


        isGrounded = true;
        speed = 0;
        walkAccel = 75;
        airAccel = 30;
        decel = 0.5f;
        jumpHeight = 8;
        gravity = 0.05f;
        charge = 100f;
        discharge = 1f;
    }


    void Update()
    {
        magnetism();
        movement();

    }




    void magnetism()
    {
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
            }
            else if (isPushing)
            {
                isPulling = false;
            }
            charge -= discharge;
        }
    }


    void movement()
    {
        if (isGrounded)
        {
            Velocity.y = 0f;

            Console.WriteLine("grounded");

            if (Input.GetKeyDown(Key.SPACE))
            {
                Velocity.y = -Mathf.Sqrt(2 * jumpHeight * gravity);
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
        isGrounded = false;
    }









    }