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
        public static LoadGameMenu LoadGameMenu;
        private static IngameMenu ingameMenu;
        private static NewGameMenu newGameMenu;
        public static SlotSelector SlotSelector;

        public static void Initialize()
        {
            mainMenu = new MainMenu();
            LoadGameMenu = new LoadGameMenu();
            ingameMenu = new IngameMenu();
            newGameMenu = new NewGameMenu();
            SlotSelector = new SlotSelector();
            OptionMenuManager.Initialize();
        }

        public static void Update()
        {
            VariableProvider.Game.IsMouseVisible = true;

            switch (StateManager.MenuState)
            { 
                case MenuStates.Main:
                    mainMenu.Update();
                    break;

                case MenuStates.LoadGame:
                    LoadGameMenu.Update();
                    break;

                case MenuStates.Options:
                    OptionMenuManager.Update();
                    break;

                case MenuStates.Ingame:
                    ingameMenu.Update();
                    break;

                case MenuStates.NewGame:
                    newGameMenu.Update();
                    break;

                case MenuStates.SlotSelector:
                    SlotSelector.Update();
                    break;
            }            
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            switch (StateManager.MenuState)
            {
                case MenuStates.Main:
                    mainMenu.Draw(spriteBatch);
                    break;

                case MenuStates.LoadGame:
                    LoadGameMenu.Draw(spriteBatch);
                    break;

                case MenuStates.Options:
                    OptionMenuManager.Draw(spriteBatch);
                    break;

                case MenuStates.Ingame:
                    ingameMenu.Draw(spriteBatch);
                    break;

                case MenuStates.NewGame:
                    newGameMenu.Draw(spriteBatch);
                    break;

                case MenuStates.SlotSelector:
                    SlotSelector.Draw(spriteBatch);
                    break;
            } 
        }
    }
}
