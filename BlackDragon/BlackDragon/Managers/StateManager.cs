﻿using System;
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
        public static DialogueStates DialogState { get; set; }

        public static bool GamePaused { get; set; }
        public static bool InputLock { get; set; }

        public static void Initialize()
        {
            GameState = GameStates.Title;
            DialogState = DialogueStates.Inactive;
            GamePaused = false;
            InputLock = false;
        }

        public static void Update()
        {
            switch (GameState)
            { 
                case GameStates.Title:
                    TitleScreenManager.Update();
                    break;

                case GameStates.Menu:
                    MenuManager.Update();
                    break;

                case GameStates.Platform:
                    PlatformManager.Update();
                    break;

                case GameStates.RPG:
                    RPGManager.Update();
                    break;
            }

            if (GamePaused)
            {
                MenuManager.Update();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        { 
            switch (GameState)
            {
                case GameStates.Title:
                    TitleScreenManager.Draw(spriteBatch);
                    break;

                case GameStates.Menu:
                    MenuManager.Draw(spriteBatch);
                    break;
                
                case GameStates.Platform:                   
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
