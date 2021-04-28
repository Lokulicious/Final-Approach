using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;

    class Crate : Sprite
    {

        private Player player;

        float speed;
        float gravity;

        public Vector2 velocity;

        public Crate() : base("square.png")
        {
            SetOrigin(width / 2, height / 2);
            gravity = 0.05f;
        }


        void Update()
        {
            movement();
        }


        void movement()
        {

            if (player.isActive)
            {
                if (player.isPulling)
                {
                    
                }
            }

        }
    }
