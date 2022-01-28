using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game0
{
    public class GhostSprite
    {
        /// <summary>
        /// The gamepads state
        /// </summary>
        private GamePadState gamePadState;

        /// <summary>
        /// The state of the keyboard
        /// </summary>
        private KeyboardState keyboardState;

        /// <summary>
        /// The texture of the ghost
        /// </summary>
        private Texture2D texture;

        /// <summary>
        /// Keeps track of which way the ghost is looking
        /// </summary>
        private bool flipped;

        /// <summary>
        /// The position of the ghost
        /// </summary>
        private Vector2 position = new Vector2(650, 230);

        /// <summary>
        /// Loads in the ghost
        /// </summary>
        /// <param name="content"> the manager that loads the content </param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("slime");
        }

        /// <summary>
        /// Updates the ghost object
        /// </summary>
        /// <param name="gameTime">the time of the game</param>
        public void Update(GameTime gameTime)
        {
            gamePadState = GamePad.GetState(0);
            keyboardState = Keyboard.GetState();

            position += gamePadState.ThumbSticks.Left * new Vector2(1, -1);
            if (gamePadState.ThumbSticks.Left.X < 0) flipped = true;
            if (gamePadState.ThumbSticks.Right.X > 0) flipped = false;

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)) position += new Vector2(0, -100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)) position += new Vector2(0, 100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                position += new Vector2(-100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
                flipped = true;
            }
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                position += new Vector2(100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
                flipped = false;
            }
        }

        /// <summary>
        /// Draws the ghost sprite
        /// </summary>
        /// <param name="gameTime"> the time of the game</param>
        /// <param name="spriteBatch"> the sprite batch</param>
        /// <param name="color"> the color of the object</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color color)
        {
            SpriteEffects spriteEffects = (flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(texture, position, null, color, 0.25f, new Vector2(64, 64), 0.25f, spriteEffects, 0);
        }
    }
}
