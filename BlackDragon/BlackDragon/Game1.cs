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
using BlackDragon.Managers;
using BlackDragon.Providers;
using Tile_Engine;
using BlackDragon.Menus;
using BlackDragon.Helpers;

namespace BlackDragon
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;  

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            VariableProvider.Game = this;
        }

        
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

            StaticClassesImportantVariablesInitializer.InitializeImportantVariables();
            StateManager.Initialize();
            WaypointProvider.Initialize();

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentLoader.LoadContent(Content);
            MenuManager.Initialize();
        }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                InputProvider.Update();
                StateManager.Update(gameTime);
            }

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            StateManager.Draw(spriteBatch);            
            spriteBatch.End();
            base.Draw(gameTime);
        }               
    }
}
