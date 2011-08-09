using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Helpers;
using BlackDragon.Managers;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BlackDragon.Providers;

namespace BlackDragon.Menus
{
    class SlotSelector : Menu
    {        
        protected string slot1, slot2, slot3;
        protected const string back = "Back";
        protected const string select = "Select profile:";

        public SlotSelector()
        {
            RebuildItems();  
        }

        public override void Update()
        {
            base.Update();
            CancelAction();            
        }

        protected virtual void CancelAction()
        {
            if (InputMapper.CANCEL)
            {
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
                StateManager.MenuState = MenuStates.NewGame;
            }
            else
            {
                StateManager.MenuState = MenuStates.Main;
            }
        }

        public void RebuildItems()
        {
            List<SaveState> saveStates = new List<SaveState>();
            string[] files = Directory.GetFiles(SaveManager.SaveFilePath, "*.svf", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                FileStream fs = new FileStream(file, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                saveStates.Add((SaveState)bf.Deserialize(fs));
                fs.Close();
            }
            slot1 = saveStates.Count == 0 || String.IsNullOrEmpty(saveStates[0].PlayerName) ? "---" : saveStates[0].PlayerName;
            slot2 = saveStates.Count <= 1 || String.IsNullOrEmpty(saveStates[1].PlayerName) ? "---" : saveStates[1].PlayerName;
            slot3 = saveStates.Count <= 2 || String.IsNullOrEmpty(saveStates[2].PlayerName) ? "---" : saveStates[2].PlayerName;

            menuItems.Clear();            
            menuItems.Add(new MenuItem(slot1, fontName, true));
            menuItems.Add(new MenuItem(slot2, fontName));
            menuItems.Add(new MenuItem(slot3, fontName));
            menuItems.Add(new MenuItem(back, fontName));

            SetPositions();

            menuItems[3].ItemPosition += itemOffset;

            menuLabels.Clear();
            menuLabels.Add(new MenuLabel(select, fontName));
            menuLabels[0].Position = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, select) - 3 * itemOffset;
        }
    }
}
