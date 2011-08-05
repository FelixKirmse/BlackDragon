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

        public static void Update()
        {
            VariableProvider.Game.IsMouseVisible = true;

            switch (StateManager.MenuState)
            { 
                case MenuStates.MAIN:
                    mainMenu.Update();
                    break;

                case MenuStates.LOADGAME:
                    loadGame.Update();
                    break;

                case MenuStates.OPTIONS:
                    OptionMenuManager.Update();
                    break;

                case MenuStates.INGAME:
                    ingameMenu.Update();
                    break;
            }            
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            switch (StateManager.MenuState)
            {
                case MenuStates.MAIN:
                    mainMenu.Draw(spriteBatch);
                    break;

                case MenuStates.LOADGAME:
                    loadGame.Draw(spriteBatch);
                    break;

                case MenuStates.OPTIONS:
                    OptionMenuManager.Draw(spriteBatch);
                    break;

                case MenuStates.INGAME:
                    ingameMenu.Draw(spriteBatch);
                    break;
            } 
        }
    }
}
