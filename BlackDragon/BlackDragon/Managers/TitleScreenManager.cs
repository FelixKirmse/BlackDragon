﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BlackDragon.Providers;
using BlackDragonEngine.Helpers;

namespace BlackDragon.Managers
{
    static class TitleScreenManager
    {
        private static Texture2D titleTexture;

        public static void LoadContent(Texture2D texture)
        {
            titleTexture = texture;
        }

        public static void Update()
        {
            if (InputMapper.STRICTACTION)
            {
                StateManager.GameState = GameStates.Menu;
                StateManager.MenuState = MenuStates.Main;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(titleTexture, Vector2.Zero, Color.White);
        }
    }
}
