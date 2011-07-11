using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Tile_Engine;

namespace BlackDragon
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        SpriteFont pericles8;
        Vector2 scorePosition = new Vector2(20, 580);
        enum GameState { TitleScreen, Playing, PlayerDead, GameOver };
        GameState gameState = GameState.TitleScreen;

        Vector2 gameOverPosition = new Vector2(350, 300);
        Vector2 livesPosition = new Vector2(600, 580);

        Texture2D titleScreen;

        float deathTimer = 0.0f;
        float deathDelay = 5.0f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TileMap.Initialize(Content.Load<Texture2D>(@"Textures/pkmtiles"));
            pericles8 = Content.Load<SpriteFont>(@"fonts/pericles8");
            titleScreen = Content.Load<Texture2D>(@"textures/TitleScreen");

            Camera.WorldRectangle = new Rectangle(0, 0, TileMap.TileWidth * TileMap.MapWidth, TileMap.MapHeight * TileMap.TileHeight);
            Camera.Position = Vector2.Zero;
            Camera.ViewPortWidth = 800;
            Camera.ViewPortHeight = 600;

            player = new Player(Content);
            LevelManager.Initialize(Content, player);    
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState keyState = Keyboard.GetState();
            GamePadState padState = GamePad.GetState(PlayerIndex.One);

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (gameState) { 
                case GameState.TitleScreen:
                    if (keyState.IsKeyDown(Keys.Enter) || padState.IsButtonDown(Buttons.A)) {
                        StartNewGame();
                        gameState = GameState.Playing;
                    }
                    break;
                case GameState.Playing:
                    player.Update(gameTime);
                    LevelManager.Update(gameTime);
                    if (player.Dead) {
                        if (player.LivesRemaining > 0)
                        {
                            gameState = GameState.PlayerDead;
                            deathTimer = 0.0f;
                        }
                        else {
                            gameState = GameState.GameOver;
                            deathTimer = 0.0f;
                        }
                    }
                    break;
                case GameState.PlayerDead:
                    player.Update(gameTime);
                    deathTimer += elapsed;
                    if (deathTimer > deathDelay) {
                        player.WorldLocation = Vector2.Zero;
                        LevelManager.ReloadLevel();
                        player.Revive();
                        gameState = GameState.Playing;
                    }
                    break;
                case GameState.GameOver:
                    deathTimer += elapsed;
                    if (deathTimer > deathDelay) {
                        gameState = GameState.TitleScreen;
                    }
                    break;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            if (gameState == GameState.TitleScreen) {
                spriteBatch.Draw(titleScreen, Vector2.Zero, Color.White);
            }
            else {
                TileMap.Draw(spriteBatch);
                player.Draw(spriteBatch);
                LevelManager.Draw(spriteBatch);
                spriteBatch.DrawString(pericles8, "Score: " + player.Score.ToString(), scorePosition, Color.White);
                spriteBatch.DrawString(pericles8, "Lives Remaining: " + player.LivesRemaining.ToString(), livesPosition, Color.White);
            }
            if (gameState == GameState.GameOver) {
                spriteBatch.DrawString(pericles8, "G A M E  O V E R !", gameOverPosition, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void StartNewGame() {
            player.Revive();
            player.LivesRemaining = 3;
            player.WorldLocation = Vector2.Zero;
            LevelManager.LoadLevel(0);
        }
    }
}
