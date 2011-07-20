using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Providers;
using BlackDragon.Managers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace BlackDragon.Menus
{
    class IngameMenu : Menu
    {
        private const string continueString = "Continue";
        private const string saveString = "Save";
        private const string loadString = "Load";
        private const string optionString = "Options";
        private const string quitString = "Quit";

        public IngameMenu()
        {
            menuItems.Add(new MenuItem(continueString, fontName, true));
            menuItems.Add(new MenuItem(saveString, fontName));
            menuItems.Add(new MenuItem(loadString, fontName));
            menuItems.Add(new MenuItem(optionString, fontName));
            menuItems.Add(new MenuItem(quitString, fontName));

            SetPositions();
        }

        public void Update(GameTime gameTime)
        {
            base.Update();
            if (StateManager.InputLock)
                StateManager.InputLock = false;
            else
            {
                if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Escape))
                {
                    StateManager.GamePaused = false;
                    StateManager.MenuState = StateManager.MenuStates.NULL;
                }
            }
        }       

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            switch (selectedItem)
            {
                case continueString:
                    StateManager.MenuState = StateManager.MenuStates.NULL;
                    StateManager.GamePaused = false;
                    break;

                case optionString:
                    StateManager.MenuState = StateManager.MenuStates.OPTIONS;
                    StateManager.OptionsState = StateManager.OptionStates.OVERVIEW;
                    break;

                case quitString:
                    StateManager.GamePaused = false;
                    StateManager.GameState = StateManager.GameStates.MENU;
                    StateManager.MenuState = StateManager.MenuStates.MAIN;
                    break;
            }
        }
    }
}
