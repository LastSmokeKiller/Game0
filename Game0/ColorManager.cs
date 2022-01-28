using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game0
{
    public class ColorManager
    {
        public ColorManager(Color color)
        {
            Color = color;
        }

        public Color Color;

        private double colorTimer;
        public void Update(GameTime gameTime)
        {
            colorTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (colorTimer > 0.2)
            {
                if (Color.Equals(Color.Yellow))
                {
                    Color = Color.Orange;
                }
                else if (Color.Equals(Color.Orange))
                {
                    Color = Color.Pink;
                }
                else if (Color.Equals(Color.Pink))
                {
                    Color = Color.Blue;
                }
                else if (Color.Equals(Color.Blue))
                {
                    Color = Color.Purple;
                }
                else if (Color.Equals(Color.Purple))
                {
                    Color = Color.Yellow;
                }
                colorTimer -= 0.1;
            }
        }
    }
}
