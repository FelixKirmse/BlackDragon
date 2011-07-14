using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BlackDragon.Providers;
using BlackDragon.Managers;
using BlackDragon.Controller;

namespace BlackDragon.Menus
{
     class MainMenu : Menu
    {
        private const string newGame = "New Game";
        private const string loadGame = "Load Game";
        private const string options = "Options";
        private const string quit = "Quit";

        private const string fontName = "Pericles14";

        private Vector2 newGamePosition;
        private Vector2 loadGamePosition;
        private Vector2 optionsPosition;
        private Vector2 quitPosition;        

        private Vector2 itemOffset = new Vector2(0, 25);

        private Dictionary<string, string> selectedItem = new Dictionary<string, string>(); 

        private Color newGameColor = Color.Red;
        private Color loadGameColor = Color.White;
        private Color optionsColor = Color.White;
        private Color quitColor = Color.White;

        public MainMenu()
        {
            selectedItem.Add("Selected", newGame);
            newGamePosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, newGame);
            loadGamePosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, loadGame) + itemOffset;
            optionsPosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, options) + 2 * itemOffset;
            quitPosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, quit) + 3 * itemOffset;
        }

        public void Update(GameTime gameTime)
        {
            MenuController.Update(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                FontProvider.GetFont(fontName),
                newGame,
                newGamePosition,
                newGameColor);

            spriteBatch.DrawString(
                FontProvider.GetFont(fontName),
                loadGame,
                loadGamePosition,
                loadGameColor);

            spriteBatch.DrawString(
                FontProvider.GetFont(fontName),
                options,
                optionsPosition,
                optionsColor);

            spriteBatch.DrawString(
                FontProvider.GetFont(fontName),
                quit,
                quitPosition,
                quitColor);
        }

        public override void NextMenuItem()
        {
            switch (selectedItem["Selected"])
            { 
                case newGame:
                    selectedItem["Selected"] = loadGame;
                    break;
                case loadGame:
                    selectedItem["Selected"] = options;
                    break;
                case options:
                    selectedItem["Selected"] = quit;
                    break;
                case quit:
                    selectedItem["Selected"] = newGame;
                    break;
            }
        }

        public override void PreviousMenuItem()
        {
            switch (selectedItem["Selected"])
            {
                case newGame:
                    selectedItem["Selected"] = quit;
                    break;
                case loadGame:
                    selectedItem["Selected"] = newGame;
                    break;
                case options:
                    selectedItem["Selected"] = loadGame;
                    break;
                case quit:
                    selectedItem["Selected"] = options;
                    break;
            }
        }

        public override void ResolveMouseSelection()
        {
            if (ShortcutProvider.MouseIntersectsRectangle(ShortcutProvider.GetFontRectangle(newGamePosition, fontName, newGame)))
                selectedItem["Selected"] = newGame;
            if (ShortcutProvider.MouseIntersectsRectangle(ShortcutProvider.GetFontRectangle(loadGamePosition, fontName, loadGame)))
                selectedItem["Selected"] = loadGame;
            if (ShortcutProvider.MouseIntersectsRectangle(ShortcutProvider.GetFontRectangle(optionsPosition, fontName, options)))
                selectedItem["Selected"] = options;
            if (ShortcutProvider.MouseIntersectsRectangle(ShortcutProvider.GetFontRectangle(quitPosition, fontName, quit)))
                selectedItem["Selected"] = quit;
        }

        public override void UpdateColors()
        {
            switch (selectedItem["Selected"])
            {
                case newGame:
                    newGameColor = Color.Red;
                    optionsColor = Color.White;
                    loadGameColor = Color.White;
                    quitColor = Color.White;
                    break;
                case loadGame:
                    newGameColor = Color.White;
                    optionsColor = Color.White;
                    loadGameColor = Color.Red;
                    quitColor = Color.White;
                    break;
                case options:
                    newGameColor = Color.White;
                    optionsColor = Color.Red;
                    loadGameColor = Color.White;
                    quitColor = Color.White;
                    break;
                case quit:
                    newGameColor = Color.White;
                    optionsColor = Color.White;
                    loadGameColor = Color.White;
                    quitColor = Color.Red;
                    break;
            }
        }

        public override void SelectMenuItem()
        {
            switch (selectedItem["Selected"])
            { 
                case newGame:
                    // Temporary Code, change to proper later!!!
                    StateManager.GameState = StateManager.GameStates.RPG;
                    StateManager.RPGState = StateManager.RPGStates.FIELD;
                    break;
                case loadGame:
                    break;
                case options:
                    break;
                case quit:
                    break;
            }
        }
    }
}
