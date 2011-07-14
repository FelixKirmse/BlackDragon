using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Menus;

namespace BlackDragon.Managers
{
    static class OptionMenuManager
    {
        private static OptionsOverview overview;

        public static void Initialize()
        {
            overview = new OptionsOverview();
        }

        public static void Update(GameTime gameTime)
        {
            switch (StateManager.OptionsState)
            { 
                case StateManager.OptionStates.OVERVIEW:
                    overview.Update(gameTime);
                    break;
            }
        }

        public static void Draw(SpriteBatch spritebatch)
        {
            switch (StateManager.OptionsState)
            {
                case StateManager.OptionStates.OVERVIEW:
                    overview.Draw(spritebatch);
                    break;
            }
        }
    }
}
