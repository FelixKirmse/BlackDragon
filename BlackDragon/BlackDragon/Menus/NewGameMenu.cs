using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Providers;
using BlackDragon.Managers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Overlays;

namespace BlackDragon.Menus
{
    class NewGameMenu : Menu
    {
        private const string name = "Enter Name: ";
        private const string ok = "Ok";
        private const string back = "Back";

        public string TextBuffer;

        public bool Confirmation = false;
        private ConfirmOverlay confirmDialog;

        public NewGameMenu()
        {
            menuLabels.Add(new MenuLabel(name, fontName));
            menuItems.Add(new MenuItem(ok, fontName, false));
            menuItems.Add(new MenuItem(back, fontName, true));

            menuLabels[0].Position = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, menuItems[0].ItemName) + new Vector2(-200, 0);
            menuItems[0].ItemPosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, menuItems[1].ItemName) + 2 * itemOffset;
            menuItems[1].ItemPosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, menuItems[1].ItemName) + 3 * itemOffset;

            EventInput.EventInput.Initialize(VariableProvider.Game.Window);            
            EventInput.EventInput.CharEntered += new EventInput.CharEnteredHandler(CharacterEntered);
            TextBuffer = "";

            confirmDialog = new ConfirmOverlay(this);
        }

        public override void Update()
        {
            if (Confirmation)
            {
                confirmDialog.Update();
                return;
            }

            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Down))
            {
                NextMenuItem();
            }

            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Up))
            {
                PreviousMenuItem();
            }

            ResolveMouseSelection();

            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Enter) || ShortcutProvider.LeftButtonClickedNowButNotLastFrame())
            {
                SelectMenuItem();
            }

            foreach (MenuItem menuItem in menuItems)
            {
                menuItem.Update();
            }
            if (InputMapper.STRICTCANCEL)
            {
                StateManager.MenuState = MenuStates.Main;
            }
            if (TextBuffer.Length == 0)
            {
                menuItems[0].IsSelected = false;
                menuItems[1].IsSelected = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Confirmation)
            {
                confirmDialog.Draw(spriteBatch);
                return;
            }

            base.Draw(spriteBatch);

            spriteBatch.DrawString(
                FontProvider.GetFont(fontName),
                TextBuffer,
                ShortcutProvider.Vector2Point(menuLabels[0].Position + new Vector2(FontProvider.GetFont(fontName).MeasureString(menuLabels[0].Text).X + 14, 0)),
                Color.White,
                0,
                Vector2.Zero,
                1,
                SpriteEffects.None,
                .2f);
        }

        private void CharacterEntered(object sender, EventInput.CharacterEventArgs e)
        {
            if (StateManager.GameState != GameStates.Menu || StateManager.MenuState != MenuStates.NewGame || Confirmation)
                return;
            // Add key to text buffer. If not a symbol key. 
            if (!((int)e.Character < 32 || (int)e.Character > 126)) //From space to tilde
            {
                // Capitals are already supported in DLL so we don't have to worry about checking shift
                if (!(ShortcutProvider.IsKeyDown(Keys.LeftControl) || ShortcutProvider.IsKeyDown(Keys.RightControl)))
                {
                    if (TextBuffer.Length < 10)
                    {
                        TextBuffer += e.Character;
                    }
                }
            }

            // Backspace - remove character if there are any
            if ((int)e.Character == 0x08 && TextBuffer.Length > 0)
            {
                TextBuffer = TextBuffer.Remove(TextBuffer.Length - 1);
            }
        }

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            switch (selectedItem)
            { 
                case ok:                    
                    SaveManager.SaveState.PlayerName = TextBuffer;
                    Confirmation = true;
                    break;

                case back:
                    StateManager.MenuState = MenuStates.Main;
                    break;
            }
        }        
    }
}
