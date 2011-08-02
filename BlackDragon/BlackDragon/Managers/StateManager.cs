using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Providers;

namespace BlackDragon.Managers
{
    static class StateManager
    {   
        public static GameStates GameState { get; set; }
        public static MenuStates MenuState { get; set; }
        public static PlayerStates PlayerState { get; set; }
        public static PlatformStates PlatformState { get; set; }
        public static RPGStates RPGState { get; set; }
        public static OptionStates OptionsState { get; set; }

        public static bool GamePaused { get; set; }
        public static bool InputLock { get; set; }

        public static void Initialize()
        {
            GameState = GameStates.TITLE;
            GamePaused = false;
            InputLock = false;
        }

        public static void Update(GameTime gameTime)
        {
            switch (GameState)
            { 
                case GameStates.TITLE:
                    TitleScreenManager.Update();
                    break;

                case GameStates.MENU:
                    MenuManager.Update(gameTime);
                    break;

                case GameStates.PLATFORM:                    
                    PlatformManager.Update(gameTime);
                    break;

                case GameStates.RPG:                    
                    RPGManager.Update(gameTime);
                    break;
            }

            if (GamePaused)
            {
                MenuManager.Update(gameTime);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        { 
            switch (GameState)
            {
                case GameStates.TITLE:
                    TitleScreenManager.Draw(spriteBatch);
                    break;

                case GameStates.MENU:
                    MenuManager.Draw(spriteBatch);
                    break;
                
                case GameStates.PLATFORM:                   
                    PlatformManager.Draw(spriteBatch);
                    break;

                case GameStates.RPG:                    
                    RPGManager.Draw(spriteBatch);
                    break;
            }

            if (GamePaused)
            {
                MenuManager.Draw(spriteBatch);
            }
        }
    }
}
