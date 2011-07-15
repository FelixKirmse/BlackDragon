using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Menus;
using BlackDragon.Providers;

namespace BlackDragon.Managers
{
    static class MenuManager
    {
        private static MainMenu mainMenu;
        private static LoadGame loadGame;
        private static IngameMenu ingameMenu;

        public static void Initialize()
        {
            mainMenu = new MainMenu();
            loadGame = new LoadGame();
            ingameMenu = new IngameMenu();
            OptionMenuManager.Initialize();
        }

        public static void Update(GameTime gameTime)
        {
            VariableProvider.Game.IsMouseVisible = true;

            switch (StateManager.MenuState)
            { 
                case StateManager.MenuStates.MAIN:
                    mainMenu.Update();
                    break;

                case StateManager.MenuStates.LOADGAME:
                    loadGame.Update(gameTime);
                    break;

                case StateManager.MenuStates.OPTIONS:
                    OptionMenuManager.Update(gameTime);
                    break;

                case StateManager.MenuStates.INGAME:
                    ingameMenu.Update(gameTime);
                    break;
            }            
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            switch (StateManager.MenuState)
            {
                case StateManager.MenuStates.MAIN:
                    mainMenu.Draw(spriteBatch);
                    break;

                case StateManager.MenuStates.LOADGAME:
                    loadGame.Draw(spriteBatch);
                    break;

                case StateManager.MenuStates.OPTIONS:
                    OptionMenuManager.Draw(spriteBatch);
                    break;

                case StateManager.MenuStates.INGAME:
                    ingameMenu.Draw(spriteBatch);
                    break;
            } 
        }
    }
}
