using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Providers;
using BlackDragon.Controller;

namespace BlackDragon.Menus
{
    class Menu
    {
        protected Vector2 itemOffset = new Vector2(0, 25);
        protected List<MenuItem> menuItems = new List<MenuItem>();
        protected string fontName = "Pericles14";

        public virtual void Update()
        {
            MenuController.Update(this);
            foreach (MenuItem menuItem in menuItems)
            {
                menuItem.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem menuItem in menuItems)
            {
                menuItem.Draw(spriteBatch);
            }
        }

        protected void SetPositions()
        { 
            for (int i = 0; i < menuItems.Count; ++i)
                {
                    menuItems[i].ItemPosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, menuItems[i].ItemName) + i * itemOffset;
                } 
        }

        public void NextMenuItem()
        {
            for (int i = 0; i < menuItems.Count; ++i)
            {
                if (menuItems[i].IsSelected)
                {
                    menuItems[i].IsSelected = false;
                    if (i == menuItems.Count - 1)
                        menuItems[0].IsSelected = true;
                    else
                        menuItems[i + 1].IsSelected = true;
                    break;
                }
            }
        }

        public void PreviousMenuItem()
        {
            for (int i = 0; i < menuItems.Count; ++i)
            {
                if (menuItems[i].IsSelected)
                {
                    menuItems[i].IsSelected = false;
                    if (i == 0)
                        menuItems[menuItems.Count - 1].IsSelected = true;
                    else
                        menuItems[i - 1].IsSelected = true;
                    break;
                }
            }
        }

        public void ResolveMouseSelection()
        {
            foreach (MenuItem menuItem in menuItems)
            {
                if (ShortcutProvider.MouseIntersectsRectangle(ShortcutProvider.GetFontRectangle(menuItem.ItemPosition, fontName, menuItem.ItemName)))
                {
                    foreach (MenuItem item in menuItems)
                        item.IsSelected = false;
                    menuItem.IsSelected = true;
                    break;
                }
            }
        }

        protected void GetSelectedItem(out string selectedItem)
        {
            selectedItem = "";
            foreach (MenuItem menuItem in menuItems)
            {
                if (menuItem.IsSelected)
                {
                    selectedItem = menuItem.ItemName;
                    break;
                }
            }
        }

        public virtual void SelectMenuItem()
        { 
        }
    }
}
