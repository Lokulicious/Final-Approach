using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

namespace GXPEngine
{
    class ChargeBar : AnimationSprite
    {
        private Player player;
        float barScaler;
        bool isPullBar;
        string color;
        int frame;

        public ChargeBar(Player player, bool isPullBar) : base("chargemeter.png", 34, 1)
        {
            this.player = player;

            SetCycle(0, 1);
            SetOrigin(width, height);
            SetScaleXY(0.8f, 0.8f);
            SetFrame(17);

            this.x = game.width;
            this.y = game.height;
            this.isPullBar = isPullBar;
        }


        void CalculateChargeFrame()
        {
            if (player.isPulling)
            {
                float charge = (player.pullCharge / 300f) * 17;
                frame = 34 - (int)Math.Round(charge);
                SetCycle(frame, 1);
            }
            else if (!player.isPulling)
            {
                float charge = (player.pushCharge / 300f) * 17;
                frame = 16 - (int)Math.Round(charge);
                SetCycle(frame, 1);
            }
            Animate();
        }


        void Update()
        {
            CalculateChargeFrame();
/*
            if (player.isPulling)
            {
                SetFrame(frame);
*//*                SetCycle(17, 17);*//*
            }
            else if(!player.isPulling)
            {
                SetFrame(frame);
*//*                SetCycle(0, 17);*//*
            }
            Console.WriteLine(frame);*/


        }
    }
}
