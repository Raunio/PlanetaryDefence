/*
    XnaGame.cs
    Copyright © Stickmansoft 2012.
	www.Stickmansoft.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace XnaGame
{
    /*
    Here are defined all the empty interfaces that all inherit from IGameScreen.
    This allows the game screen objects to all be accessed the same way and 
    allows them to be registered as a game services. A game service and 
    therefore game screen too must have a unique interface. Whenever the game
    needs a new game screen, the game need to add new interface. */
    public interface IStartGameScreen : IGameScreen { }
    public interface IPlayGameScreen : IGameScreen { }
    public interface IGameOverScreen : IGameScreen { }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class XnaGame : Microsoft.Xna.Framework.Game
    {
        // HW
        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        // Game screen management
        GameScreenManager screenManager;
        // Game screens
        public IStartGameScreen StartGameScreen;
        public IPlayGameScreen PlayGameScreen;
        public IGameOverScreen GameOverScreen;
        // Touch
        Vector2 touchPosition = Vector2.Zero;

        public XnaGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Game screen manager
            screenManager = new GameScreenManager(this);
            Components.Add(screenManager);

            // Game screens
            StartGameScreen = new StartGameScreen(this);
            PlayGameScreen = new PlayGameScreen(this);
            GameOverScreen = new GameOverScreen(this);

            // First game screen.
            screenManager.ChangeScreen(StartGameScreen.Screen);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
#if WINDOWS || XBOX
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }
#endif
            // Allows the game to exit.
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                this.Exit();
            }

            // Touch
            HandleTouchScreenInputs();

            base.Update(gameTime);
        }

        private void HandleTouchScreenInputs()
        {
            TouchCollection touchCollection = TouchPanel.GetState();

            foreach (TouchLocation touchLoc in touchCollection)
            {
                if ((touchLoc.State == TouchLocationState.Pressed) /*|| (touchLoc.State == TouchLocationState.Moved)*/)
                {
                    touchPosition = touchLoc.Position;
                }
            }
        }

        private Boolean CheckIntersection(Rectangle Rect, Vector2 Pt)
        {
            if (Rect.Intersects(new Rectangle((int)Pt.X - 1, (int)Pt.Y - 1, 2, 2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            SpriteBatch.Begin();

            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}
