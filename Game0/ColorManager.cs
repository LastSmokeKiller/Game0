using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game0
{
    /// <summary>
    /// A manager for how the objects change color on a loop
    /// </summary>
    public class ColorManager
    {
        /// <summary>
        /// initializes the color manager
        /// </summary>
        /// <param name="color"> The initial color </param>
        public ColorManager(Color color)
        {
            Color = color;
        }

        /// <summary>
        /// The color of the color manager
        /// </summary>
        public Color Color;

        /// <summary>
        /// The timer of when the color changes
        /// </summary>
        private double colorTimer;

        /// <summary>
        /// Updates the color
        /// </summary>
        /// <param name="gameTime"> the time of the game</param>
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
