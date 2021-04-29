using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

namespace GXPEngine
{
    class ChargeBar : Sprite
    {
        private Player player;
        float barScaler;
        float charge;
        bool isPullBar;
        string color;

        public ChargeBar(Player player, bool isPullBar, float y, string color) : base(color)
        {
            this.player = player;

            SetOrigin(0, height / 2);
            scaleY = 0.1f;

            this.x = 50;
            this.y = y;
            this.isPullBar = isPullBar;

            this.color = color;
        }


        void Update()
        {
            if (isPullBar)
            {
                charge = player.pullCharge;
            }
            else
            {
                charge = player.pushCharge;
            }

            barScaler = 0.1f * charge / 100;
            scaleX = barScaler;
        }
    }
}
