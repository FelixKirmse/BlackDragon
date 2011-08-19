using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragonEngine.Entities;
using BlackDragonEngine.Components;
using Microsoft.Xna.Framework;
using BlackDragonEngine.HelpMaps;
using BlackDragonEngine.Providers;
using BlackDragonEngine.Managers;
using BlackDragonEngine.Helpers;
using BlackDragon.Providers;

namespace BlackDragon.Managers
{
    static class CodeManager
    {
        public static void CheckCodes()
        {
            EntityManager.ClearEntities();
            GameObject player = VariableProvider.CurrentPlayer;
            EntityManager.SetPlayer();

            for (int y = 0; y < TileMap.MapHeight; ++y)
            {
                for (int x = 0; x < TileMap.MapWidth; ++x)
                {                    
                    foreach (string codePart in TileMap.GetCellCodes(x,y))
                    {
                        string[] code = codePart.Split('_'); 
                        switch (code[0])
                        {
                            case "START":
                                player.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                                break;

                            case "SPAWN":
                                SpawnManager.Spawn(code[1], x, y);
                                break;
                        }
                    }
                }
            }
        }


        public static void CheckPlayerCodes()
        {
            GameObject player = VariableProvider.CurrentPlayer;
            checkCodesInPlayerCenter(player);
            if (StateManager.GameState == GameStates.Platform)
                checkCodesUnderPlayer(player);
        }

        private static void checkCodesUnderPlayer(GameObject player)
        {
            Rectangle playerCollisionRectangle = player.GetCollisionRectangle(player.PublicCollisionRectangle);
            checkCodesUnderPlayer(player, TileMap.GetCellCodes
                (
                    TileMap.GetCellByPixel(
                        new Vector2(
                            playerCollisionRectangle.Left,
                            playerCollisionRectangle.Bottom
                            )
                    )
                ));
            checkCodesUnderPlayer(player, TileMap.GetCellCodes
                (
                    TileMap.GetCellByPixel(
                        new Vector2(
                            playerCollisionRectangle.Right,
                            playerCollisionRectangle.Bottom
                            )
                    )
                ));
            checkCodesUnderPlayer(player, TileMap.GetCellCodes
                (
                    TileMap.GetCellByPixel(
                        new Vector2(
                            playerCollisionRectangle.Center.X,
                            playerCollisionRectangle.Bottom
                            )
                    )
                ));
        }

        private static void checkCodesUnderPlayer(GameObject player, List<string> codes )
        {
            foreach (string code in codes)
            {
                string[] codeArray = code.Split('_');
                switch (codeArray[0])
                { 
                    case "JUMPTHROUGHTOP":
                        player.Send<bool>("PHYSICS_SET_JUMPTHROUGHCHECK", true);
                        break;

                    case "WATER":
                        player.Send<bool>("PHYSICS_SET_INWATER", true);
                        break;
                }
            }
        }

        private static void checkCodesInPlayerCenter(GameObject player)
        {
            Vector2 collisionCenter = player.GetCollisionCenter(player.PublicCollisionRectangle);

            foreach (string codePart in TileMap.GetCellCodes(TileMap.GetCellByPixel(collisionCenter)))
            {
                string[] codeArray = codePart.Split('_');
                switch (codeArray[0])
                {
                    case "TRANSITION":
                        if (LevelManager.CurrentMap.Properties["Mode"] == "RPG")
                            StateManager.GameState = GameStates.RPG;
                        else if (LevelManager.CurrentMap.Properties["Mode"] == "Platform")
                            StateManager.GameState = GameStates.Platform;
                        IngameManager.Activate();
                        LevelManager.LoadLevel(codeArray[1]);
                        break;

                    case "PIPE":
                        if (InputMapper.STRICTDOWN)
                        {
                            StateManager.GameState = GameStates.RPG;
                            RPGManager.Activate();
                        }
                        break;

                    case "DIALOG":
                        if (InputMapper.STRICTACTION)
                        {
                            DialogManager.PlayDialog(DialogDictionaryProvider.GetDummyDialog(), "Test1");
                            StateManager.DialogState = DialogueStates.Active;
                        }
                        break;
                }
            }
        }        
    }
}
