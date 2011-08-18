using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragonEngine.HelpMaps;
using BlackDragonEngine.Managers;
using BlackDragonEngine.Providers;
using BlackDragonEngine.Entities;
using BlackDragon.Helpers;
using BlackDragon.Providers;

namespace BlackDragon.Managers
{
    static class PlatformManager
    {    
        public static void Activate()
        {             
            GameVariableProvider.SaveState.CurrentMode = GameStates.Platform;

            VariableProvider.CurrentPlayer = Factory.CreatePlatformPlayer();            
         }

        public static void Update()
        {
            if (!StateManager.GamePaused)
            {
                EntityManager.Update();                
                GeneralInputManager.HandleGeneralInput();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            EntityManager.Draw(spriteBatch);
            TileMap.Draw(spriteBatch);
        }
    }
}
