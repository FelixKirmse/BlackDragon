using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Managers;
using BlackDragon.Providers;
using BlackDragonEngine.HelpMaps;
using BlackDragon.Menus;
using BlackDragon.Helpers;
using BlackDragonEngine.Providers;
using BlackDragonEngine.Managers;
using System.IO;
using xTile.Display;
using BlackDragonEngine.Helpers;

namespace BlackDragon
{
    
    public class BlackDragon : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;  

        public BlackDragon()
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
            GameVariableProvider.Initialize();

            if (!Directory.Exists(SaveManager.SaveFilePath))
                Directory.CreateDirectory(SaveManager.SaveFilePath);

            LevelManager.OnLevelLoad += CodeManager.CheckCodes;
            LevelManager.OnLevelLoad += OnLevelLoad;

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            VariableProvider.DisplayDevice = new XnaDisplayDevice(Content, GraphicsDevice);
            VariableProvider.Viewport = new xTile.Dimensions.Rectangle(new xTile.Dimensions.Size(800, 600));            
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
                VariableProvider.GameTime = gameTime;
                InputProvider.Update();
                StateManager.Update();
                Camera.Update();
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

        public void OnAfterDraw(object sender, xTile.Layers.LayerEventArgs layerEventArgs)
        {
            SpriteBatch spriteBatch = VariableProvider.DisplayDevice.SpriteBatchAlpha;
            switch (StateManager.GameState)
            {
                case GameStates.RPG:
                case GameStates.Platform:
                    IngameManager.Draw(spriteBatch);
                    break;
            }
        }

        public void OnLevelLoad()
        {
            GameVariableProvider.SaveState.CurrentLevel = LevelManager.CurrentLevel;
            LevelManager.CurrentMap.Layers[LevelManager.CurrentMap.Properties["PlayerLayer"]].AfterDraw += OnAfterDraw;            
        }
    }
}
