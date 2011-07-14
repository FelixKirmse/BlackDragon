using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Controller;
using BlackDragon.Providers;
using BlackDragon.Managers;

namespace BlackDragon.Menus
{
    class OptionsOverview : Menu
    {
        private const string graphicsString = "Graphics";
        private const string soundString = "Sounds";
        private const string controlString = "Controls";
        private const string generalString = "General";

        private Vector2 graphicsPosition;
        private Vector2 soundPosition;
        private Vector2 controlPosition;
        private Vector2 generalPosition;

        private Color graphicsColor;
        private Color soundColor;
        private Color controlColor;
        private Color generalColor;
        
        private const string fontName = "Pericles14";

        private Vector2 itemOffset = new Vector2(0, 25);

        private Dictionary<string, string> selectedItem = new Dictionary<string, string>();

        public OptionsOverview()
        {
            selectedItem["Selected"] = generalString;
            generalPosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, generalString);
            graphicsPosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, graphicsString) + itemOffset;
            soundPosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, soundString) + 2 * itemOffset;
            controlPosition = ShortcutProvider.ScreenCenter - ShortcutProvider.GetFontCenter(fontName, controlString) + 3 * itemOffset;
        }

        public void Update(GameTime gameTime)
        {
            MenuController.Update(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                FontProvider.GetFont(fontName),
                generalString,
                generalPosition,
                generalColor);

            spriteBatch.DrawString(
                FontProvider.GetFont(fontName),
                graphicsString,
                graphicsPosition,
                graphicsColor);

            spriteBatch.DrawString(
                FontProvider.GetFont(fontName),
                soundString,
                soundPosition,
                soundColor);

            spriteBatch.DrawString(
                FontProvider.GetFont(fontName),
                controlString,
                controlPosition,
                controlColor);        
        }

        public override void NextMenuItem()
        {
            switch (selectedItem["Selected"])
            {
                case generalString:
                    selectedItem["Selected"] = graphicsString;
                    break;
                case graphicsString:
                    selectedItem["Selected"] = soundString;
                    break;
                case soundString:
                    selectedItem["Selected"] = controlString;
                    break;
                case controlString:
                    selectedItem["Selected"] = generalString;
                    break;
            }
        }

        public override void PreviousMenuItem()
        {
            switch (selectedItem["Selected"])
            {
                case generalString:
                    selectedItem["Selected"] = controlString;
                    break;
                case graphicsString:
                    selectedItem["Selected"] = generalString;
                    break;
                case soundString:
                    selectedItem["Selected"] = graphicsString;
                    break;
                case controlString:
                    selectedItem["Selected"] = soundString;
                    break;
            }
        }

        public override void ResolveMouseSelection()
        {
            if (ShortcutProvider.MouseIntersectsRectangle(ShortcutProvider.GetFontRectangle(generalPosition, fontName, generalString)))
                selectedItem["Selected"] = generalString;
            if (ShortcutProvider.MouseIntersectsRectangle(ShortcutProvider.GetFontRectangle(graphicsPosition, fontName, graphicsString)))
                selectedItem["Selected"] = graphicsString;
            if (ShortcutProvider.MouseIntersectsRectangle(ShortcutProvider.GetFontRectangle(soundPosition, fontName, soundString)))
                selectedItem["Selected"] = soundString;
            if (ShortcutProvider.MouseIntersectsRectangle(ShortcutProvider.GetFontRectangle(controlPosition, fontName, controlString)))
                selectedItem["Selected"] = controlString;
        }

        public override void UpdateColors()
        {
            switch (selectedItem["Selected"])
            {
                case generalString:
                    generalColor = Color.Red;
                    graphicsColor = Color.White;
                    soundColor = Color.White;
                    controlColor = Color.White;
                    break;
                case graphicsString:
                    generalColor = Color.White;
                    graphicsColor = Color.Red;
                    soundColor = Color.White;
                    controlColor = Color.White;
                    break;
                case soundString:
                    generalColor = Color.White;
                    graphicsColor = Color.White;
                    soundColor = Color.Red;
                    controlColor = Color.White;
                    break;
                case controlString:
                    generalColor = Color.White;
                    graphicsColor = Color.White;
                    soundColor = Color.White;
                    controlColor = Color.Red;
                    break;
            }
        }

        public override void SelectMenuItem()
        {
            switch (selectedItem["Selected"])
            {
                case generalString:                    
                    break;
                case graphicsString:
                    break;
                case soundString:                   
                    break;
                case controlString:
                    break;
            }
        }
    }
}
