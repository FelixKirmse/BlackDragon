using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Providers;
using BlackDragonEngine.TileEngine;
using BlackDragonEngine.Providers;
using BlackDragonEngine.Managers;
using BlackDragonEngine.Entities;
using BlackDragonEngine.Helpers;
using BlackDragonEngine.Dialogue;
using BlackDragon.Dialogue.Dialogs;

namespace BlackDragon.Managers
{
    static class RPGManager
    {
        private static Texture2D rpgTileSet;        

        public static void LoadContent(Texture2D tileSet)
        {
            rpgTileSet = tileSet;
        }

        public static void Activate()
        {
            TileMap.TileOffset = 0;
            TileMap.DefaultTile = 0;
            TileMap.WhiteTile = 1791;
            TileMap.TransparentTile = 278;
            TileMap.Initialize(rpgTileSet);
            GameVariableProvider.SaveState.CurrentMode = GameStates.RPG;

            /// temporary code            
            VariableProvider.CurrentPlayer = Factory.CreateRPGPlayer();                
        }

        public static void Update()
        {
            if (StateManager.DialogState == DialogueStates.Inactive)
            {
                if (!StateManager.GamePaused)
                {
                    EntityManager.Update();
                    CodeManager.CheckPlayerCodes();
                    GeneralInputManager.HandleGeneralInput();
                }
            }
            else 
            {
                DialogManager.Update();
            }  
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            TileMap.Draw(spriteBatch);
            EntityManager.Draw(spriteBatch);
            if (StateManager.DialogState == DialogueStates.Active)
            {
                DialogManager.Draw(spriteBatch);
            }
        }
    }
}
