using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragonEngine.Providers;
using BlackDragon.Managers;
using Microsoft.Xna.Framework.Input;
using BlackDragonEngine.Menus;

namespace BlackDragon.Menus
{
    class OptionsGeneral : Menu
    {
        private const string NYI = "Not Yet Implemented";

        public OptionsGeneral()
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
