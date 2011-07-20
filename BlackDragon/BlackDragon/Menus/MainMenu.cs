using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BlackDragon.Providers;
using BlackDragon.Managers;
using BlackDragon.Controller;

namespace BlackDragon.Menus
{
     class MainMenu : Menu
    {
         private const string newGame = "New Game";
         private const string loadGame = "Load Game";
         private const string options = "Options";
         private const string quit = "Quit";         

        public MainMenu()
        {
            menuItems.Add(new MenuItem(newGame, fontName, true));
            menuItems.Add(new MenuItem(loadGame, fontName));
            menuItems.Add(new MenuItem(options, fontName));
            menuItems.Add(new MenuItem(quit, fontName));

            SetPositions();
        }

        public override void Update()
        {
            base.Update();
            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Escape))
            {
                StateManager.GameState = StateManager.GameStates.TITLE;
            }
        }

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            switch (selectedItem)
            { 
                case newGame:
                    // Temporary Code, change to proper later!!!
                    StateManager.GameState = StateManager.GameStates.RPG;
                    StateManager.RPGState = StateManager.RPGStates.FIELD;
                    RPGManager.Activate();                    
                    break;
                case loadGame:
                    StateManager.MenuState = StateManager.MenuStates.LOADGAME;
                    break;
                case options:
                    StateManager.MenuState = StateManager.MenuStates.OPTIONS;
                    StateManager.OptionsState = StateManager.OptionStates.OVERVIEW;
                    break;
                case quit:
                    VariableProvider.Game.Exit();
                    break;
            }
        }
    }
}
