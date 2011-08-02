using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Tile_Engine;
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
                    string[] codeParts = TileMap.CellCodeValue(x, y).Split('*');
                    foreach (string codePart in codeParts)
                    {
                        string[] code = codePart.Split('_'); 
                        switch (code[0])
                        {
                            case "START":
                                player.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                                break;

                            case "SPAWN":
                                if (code[1] == "MARIA")
                                {
                                    GameObject maria = Factory.CreateMaria();
                                    maria.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                                    EntityManager.AddEntity(maria);
                                }
                                break;

                            case "WATER":
                                if (code.Length >= 2)
                                {
                                    if (code[1] == "TOP")
                                    {
                                        GameObject water = Factory.CreateWater();
                                        water.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                                        EntityManager.AddEntity(water);
                                    }
                                }
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
            if (StateManager.GameState == GameStates.PLATFORM)
                checkCodesUnderPlayer(player);
        }

        private static void checkCodesUnderPlayer(GameObject player)
        {
            Rectangle playerCollisionRectangle = player.GetCollisionRectangle(player.PublicCollisionRectangle);

            string codeLeft = TileMap.CellCodeValue
                (
                    TileMap.GetCellByPixel(
                        new Vector2(
                            playerCollisionRectangle.Left,
                            playerCollisionRectangle.Bottom
                            )
                    )
                );

            string codeParts = TileMap.CellCodeValue
                (
                    TileMap.GetCellByPixel(
                        new Vector2(
                            playerCollisionRectangle.Right,
                            playerCollisionRectangle.Bottom
                            )
                    )
                );

            string codeCenter = TileMap.CellCodeValue
                (
                    TileMap.GetCellByPixel(
                        new Vector2(
                            playerCollisionRectangle.Center.X,
                            playerCollisionRectangle.Bottom
                            )
                    )
                );

            string longCode = codeLeft + codeParts + codeCenter;
            if(longCode.Contains("JUMPTHROUGHTOP"))            
                player.Send<bool>("PHYSICS_SET_JUMPTHROUGHCHECK", true);
            if(longCode.Contains("WATER"))
                player.Send<bool>("PHYSICS_SET_INWATER", true);

            
        }

        private static void checkCodesInPlayerCenter(GameObject player)
        {
            string[] codeParts = TileMap.CellCodeValue(TileMap.GetCellByPixel(player.GetCollisionCenter(player.PublicCollisionRectangle))).Split('*');

            foreach (string codePart in codeParts)
            {
                string[] codeArray = codePart.Split('_');
                switch (codeArray[0])
                {
                    case "TRANSITION":
                        switch (codeArray[1])
                        {
                            case "PLATFORM":
                                StateManager.GameState = GameStates.PLATFORM;
                                PlatformManager.Activate();
                                break;

                            case "RPG":
                                StateManager.GameState = GameStates.RPG;
                                RPGManager.Activate();
                                break;
                        }
                        LevelManager.LoadLevel(codeArray[2]);
                        break;

                    case "PIPE":
                        if (InputMapper.STRICTDOWN)
                        {
                            StateManager.GameState = GameStates.RPG;
                            RPGManager.Activate();
                        }
                        break;
                }
            }
        }        
    }
}
