using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Providers;
using BlackDragonEngine.HelpMaps;
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
        public static void Activate()
        {                                   
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
                    VariableProvider.Viewport.X++;
                }
            }
            else 
            {
                DialogManager.Update();
            }  
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            //TileMap.Draw(spriteBatch);            
            EntityManager.Draw(spriteBatch);
            if (StateManager.DialogState == DialogueStates.Active)
            {
                DialogManager.Draw(spriteBatch);
            }
        }
    }
}
