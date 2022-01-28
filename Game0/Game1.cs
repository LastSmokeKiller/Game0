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
        private GhostSprite ghost;
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
        private Texture2D textPack;

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
            ghost = new GhostSprite();
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
            ghost.LoadContent(Content);
            textPack = Content.Load<Texture2D>("colored_packed");
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
            ghost.Update(gameTime);

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

            bat.Draw(gameTime, spriteBatch);

            #region Draws the sprites from the texture pack

            spriteBatch.Draw(textPack, new Vector2(50, 50), new Rectangle(320, 256, 16, 16), Color.White);
            spriteBatch.Draw(textPack, new Vector2(500, 125), new Rectangle(530, 334, 16, 16), Color.Pink);
            spriteBatch.Draw(textPack, new Vector2(725, 390), new Rectangle(400, 80, 16, 16), Color.Red);
            spriteBatch.Draw(textPack, new Vector2(125, 275), new Rectangle(366, 65, 16, 16), Color.Black);
            #endregion

            #region Draws the Strings with the banger font

            spriteBatch.DrawString(bangers, "Press ESC to Exit", new Vector2(250,200), color1);
            spriteBatch.DrawString(bangers, "This is a Crab ->", new Vector2(400, 375), crabColor);
            spriteBatch.DrawString(bangers, "His name is Bob", new Vector2(400, 425), bobColor);
            #endregion

            ghost.Draw(gameTime, spriteBatch, slimeC);

            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
