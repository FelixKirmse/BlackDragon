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
    class OptionsGraphics : Menu
    {
        private const string NYI = "Not Yet Implemented";

        public OptionsGraphics()
        {
            menuItems.Add(new MenuItem(NYI, fontName, true));

            SetPositions();
        }

        public override void Update()
        {
            base.Update();
            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Escape))
            {
                StateManager.OptionsState = OptionStates.Overview;
            }
        }

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            switch (selectedItem)
            {                
                case NYI:
                    StateManager.OptionsState = OptionStates.Overview;
                    break;
            }
        }
    }
}
