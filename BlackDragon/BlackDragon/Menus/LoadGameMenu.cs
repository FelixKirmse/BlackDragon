using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Providers;
using BlackDragon.Managers;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace BlackDragon.Menus
{
    class LoadGameMenu : SlotSelector
    {
        protected override void CancelAction()
        {
            if (InputMapper.STRICTCANCEL)
            {
                if (StateManager.GamePaused)
                    StateManager.MenuState = MenuStates.Ingame;
                else
                    StateManager.MenuState = MenuStates.Main;
            }
        }

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            if (selectedItem != back)
            {
                VariableProvider.SaveSlot = selectedItem == slot1 ? "1" : selectedItem == slot2 ? "2" : selectedItem == slot3 ? "3" : null;

                try
                {
                    SaveManager.LoadSaveState(VariableProvider.SaveSlot);
                }
                catch (FileNotFoundException)
                { 
                    
                }
                
            }
            else
            {
                if (StateManager.GamePaused)
                    StateManager.MenuState = MenuStates.Ingame;
                else
                    StateManager.MenuState = MenuStates.Main;
            }
        }
    }
}
