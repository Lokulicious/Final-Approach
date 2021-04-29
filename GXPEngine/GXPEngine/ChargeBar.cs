using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class ChargeBar : Sprite
    {
        private Player player;
        float barScaler;


        public ChargeBar(Player player) : base("Bar.png")
        {
            this.player = player;

            SetOrigin(0, height / 2);
            scaleY = 0.1f;

            this.x = 50;
            this.y = 50;
        }


        void Update()
        {


            barScaler = 0.1f * player.charge / 100;
            scaleX = barScaler;
        }
    }
}
