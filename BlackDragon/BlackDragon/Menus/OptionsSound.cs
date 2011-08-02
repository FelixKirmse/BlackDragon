using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Providers;
using BlackDragon.Managers;
using Microsoft.Xna.Framework.Input;

namespace BlackDragon.Menus
{
    class OptionsSound : Menu
    {
        private const string NYI = "Not Yet Implemented";

        public OptionsSound()
        {
            menuItems.Add(new MenuItem(NYI, fontName, true));

            SetPositions();
        }

        public void Update(GameTime gameTime)
        {
            base.Update();
            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Escape))
            {
                StateManager.OptionsState = OptionStates.OVERVIEW;
            }
        }

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            switch (selectedItem)
            {
                case NYI:
                    StateManager.OptionsState = OptionStates.OVERVIEW;
                    break;
            }
        }
    }
}
