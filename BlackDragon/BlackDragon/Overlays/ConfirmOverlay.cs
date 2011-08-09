using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Managers;
using BlackDragon.Menus;
using BlackDragon.Providers;
using System.IO;

namespace BlackDragon.Overlays
{
    class ConfirmOverlay : Menu
    {
        private string confirmText = "Use name: ";
        private const string yes = "Yes";
        private const string no = "No";

        NewGameMenu parent;
        

        public ConfirmOverlay(NewGameMenu parent)
        {
            this.parent = parent;

            menuItems.Add(new MenuItem(yes, fontName));
            menuItems.Add(new MenuItem(no, fontName, true));

            SetPositions();
        }

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            switch (selectedItem)
            {
                case yes:                    
                    SaveManager.SaveSaveState(VariableProvider.SaveSlot);
                    StateManager.GameState = GameStates.RPG;
                    StateManager.RPGState = RPGStates.FIELD;
                    RPGManager.Activate();
                    parent.Confirmation = false;
                    parent.TextBuffer = "";
                    LevelManager.LoadLevel("000");
                    break;

                case no:
                    parent.Confirmation = false;
                    parent.TextBuffer = "";
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.DrawString(
                FontProvider.GetFont(fontName),
                confirmText + SaveManager.SaveState.PlayerName + "?",
                ShortcutProvider.Vector2Point(menuItems[0].ItemPosition - itemOffset - new Vector2(ShortcutProvider.GetFontCenter(fontName, confirmText + SaveManager.SaveState.PlayerName + "?").X  ,0)),
                Color.White,
                0,
                Vector2.Zero,
                1,
                SpriteEffects.None,
                .2f);
        }
    }
}
