using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        /// <summary>
        /// Sprites in the game
        /// </summary>
        private BatSprite bat;
        private SpriteFont bangers;

        /// <summary>
        /// Colors and Color managers
        /// </summary>
        private Color color1 = Color.Yellow;
        private Color crabColor = Color.Orange;
        private Color bobColor = Color.Blue;
        private Color slimeC = Color.Purple;
        private ColorManager slimeMan;
        private ColorManager crabColorMan;
        private ColorManager bobColorMan;
        private ColorManager colorManager;

        /// <summary>
        /// Texture pack
        /// </summary>
        private Texture2D tnt;
        private Texture2D fire;
        private Texture2D background;
        private Texture2D bomb;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "THIS IS A GAME!";
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bat = new BatSprite() { Position = new Vector2(200, 200), Direction = Direction.Down };
            colorManager = new ColorManager(color1);
            bobColorMan = new ColorManager(bobColor);
            crabColorMan = new ColorManager(crabColor);
            slimeMan = new ColorManager(slimeC);

            base.Initialize();
        }

        /// <summary>
        /// Loads in the objects
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tnt = Content.Load<Texture2D>("TnT");
            fire = Content.Load<Texture2D>("fire");
            bomb = Content.Load<Texture2D>("TheBomb");
            background = Content.Load<Texture2D>("BombBackground");
            bat.LoadContent(Content);

            bangers = Content.Load<SpriteFont>("bangers");
        }

        /// <summary>
        /// Updates the objects within the game
        /// </summary>
        /// <param name="gameTime"> the time of the game</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            #region The section that manages and updates the colors

            slimeMan.Update(gameTime);
            colorManager.Update(gameTime);
            bobColorMan.Update(gameTime);
            crabColorMan.Update(gameTime);
            slimeC = slimeMan.Color;
            color1 = colorManager.Color;
            bobColor = bobColorMan.Color;
            crabColor = crabColorMan.Color;

            #endregion

            bat.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws every object within the game
        /// </summary>
        /// <param name="gameTime"> the time of the game </param>
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            bangers.MeasureString("This is a string to measure");
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, null, Color.White);
            bat.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(tnt, new Vector2(225, 190), null, Color.White);
            spriteBatch.Draw(tnt, new Vector2(500, 190), null, Color.White);
            spriteBatch.Draw(fire, new Vector2(245, 150), null, Color.White);
            spriteBatch.Draw(fire, new Vector2(520, 150), null, Color.White);
            spriteBatch.Draw(bomb, new Vector2(360, 350), null, Color.White);
            #region Draws the Strings with the banger font
            spriteBatch.DrawString(bangers, "Play Game", new Vector2(350, 300), Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(bangers, "Press ESC to Exit", new Vector2(25,25), color1, 0f, Vector2.Zero,.5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(bangers, "Bomb Squad", new Vector2(275, 200), Color.White);
            #endregion


            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
