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

        public static void Initialize()
        {
            mainMenu = new MainMenu();
        }

        public static void Update(GameTime gameTime)
        {
            VariableProvider.Game.IsMouseVisible = true;
            switch (StateManager.MenuState)
            { 
                case StateManager.MenuStates.MAIN:
                    mainMenu.Update(gameTime);
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
            } 
        }
    }
}
