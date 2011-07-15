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
        private static OptionsGraphics graphics;
        private static OptionsSound sound;
        private static OptionsControl controls;
        private static OptionsGeneral general;

        public static void Initialize()
        {
            overview = new OptionsOverview();
            graphics = new OptionsGraphics();
            sound = new OptionsSound();
            controls = new OptionsControl();
            general = new OptionsGeneral();
        }

        public static void Update(GameTime gameTime)
        {
            switch (StateManager.OptionsState)
            { 
                case StateManager.OptionStates.OVERVIEW:
                    overview.Update();
                    break;
                case StateManager.OptionStates.GRAPHICS:
                    graphics.Update(gameTime);
                    break;
                case StateManager.OptionStates.SOUND:
                    sound.Update(gameTime);
                    break;
                case StateManager.OptionStates.CONTROL:
                    controls.Update(gameTime);
                    break;
                case StateManager.OptionStates.GENERAL:
                    general.Update(gameTime);
                    break;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            switch (StateManager.OptionsState)
            {
                case StateManager.OptionStates.OVERVIEW:
                    overview.Draw(spriteBatch);
                    break;
                case StateManager.OptionStates.GRAPHICS:
                    graphics.Draw(spriteBatch);
                    break;
                case StateManager.OptionStates.SOUND:
                    sound.Draw(spriteBatch);
                    break;
                case StateManager.OptionStates.CONTROL:
                    controls.Draw(spriteBatch);
                    break;
                case StateManager.OptionStates.GENERAL:
                    general.Draw(spriteBatch);
                    break;
            }
        }
    }
}
