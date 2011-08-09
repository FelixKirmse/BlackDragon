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

        public static void Update()
        {
            switch (StateManager.OptionsState)
            { 
                case OptionStates.Overview:
                    overview.Update();
                    break;
                case OptionStates.Graphics:
                    graphics.Update();
                    break;
                case OptionStates.Sound:
                    sound.Update();
                    break;
                case OptionStates.Controls:
                    controls.Update();
                    break;
                case OptionStates.General:
                    general.Update();
                    break;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            switch (StateManager.OptionsState)
            {
                case OptionStates.Overview:
                    overview.Draw(spriteBatch);
                    break;
                case OptionStates.Graphics:
                    graphics.Draw(spriteBatch);
                    break;
                case OptionStates.Sound:
                    sound.Draw(spriteBatch);
                    break;
                case OptionStates.Controls:
                    controls.Draw(spriteBatch);
                    break;
                case OptionStates.General:
                    general.Draw(spriteBatch);
                    break;
            }
        }
    }
}
