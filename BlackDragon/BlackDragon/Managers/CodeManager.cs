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
                    switch (TileMap.CellCodeValue(x, y))
                    { 
                        case "START":
                            player.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                            break;

                        case "SPAWN_MARIA":
                            GameObject maria = Factory.CreateMaria();
                            maria.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                            EntityManager.AddEntity(maria);
                            break;

                        case "WATER_TOP":
                            GameObject water = Factory.CreateWater();
                            water.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                            EntityManager.AddEntity(water);
                            break;
                    }
                }
            }
        }


        public static void CheckPlayerCodes()
        {
            GameObject player = VariableProvider.CurrentPlayer;
            checkCodesInPlayerCenter(player);
            if (StateManager.GameState == StateManager.GameStates.PLATFORM)
                checkCodesUnderPlayer(player);
        }

        private static void checkCodesUnderPlayer(GameObject player)
        {
            Rectangle playerCollisionRectangle = player.GetCollisionRectangle(player.PublicCollisionRectangle);
            string[] codeArrayLeft = TileMap.CellCodeValue
                (
                    TileMap.GetCellByPixel(
                        new Vector2(
                            playerCollisionRectangle.Left,
                            playerCollisionRectangle.Bottom
                            )
                    )
                ).Split('_');

            string[] codeArrayRight = TileMap.CellCodeValue
                (
                    TileMap.GetCellByPixel(
                        new Vector2(
                            playerCollisionRectangle.Right,
                            playerCollisionRectangle.Bottom
                            )
                    )
                ).Split('_');

            string[] codeArrayCenter = TileMap.CellCodeValue
                (
                    TileMap.GetCellByPixel(
                        new Vector2(
                            playerCollisionRectangle.Center.X,
                            playerCollisionRectangle.Bottom
                            )
                    )
                ).Split('_');

            string[] firstCode = new string[] { codeArrayCenter[0], codeArrayLeft[0], codeArrayRight[0] };
            

            if(firstCode.Contains("JUMPTHROUGHTOP"))
                player.Send<bool>("PHYSICS_SET_JUMPTHROUGHCHECK", true);

            if (firstCode.Contains("WATER"))
                player.Send<bool>("PHYSICS_SET_INWATER", true);
            
        }

        private static void checkCodesInPlayerCenter(GameObject player)
        {
            string[] codeArray = TileMap.CellCodeValue(TileMap.GetCellByPixel(player.GetCollisionCenter(player.PublicCollisionRectangle))).Split('_');

            switch (codeArray[0])
            {
                case "TRANSITION":
                    switch (codeArray[1])
                    {
                        case "PLATFORM":
                            StateManager.GameState = StateManager.GameStates.PLATFORM;
                            PlatformManager.Activate();
                            break;

                        case "RPG":
                            StateManager.GameState = StateManager.GameStates.RPG;
                            RPGManager.Activate();
                            break;
                    }
                    LevelManager.LoadLevel(codeArray[2]);                    
                    break;

                case "PIPE":
                    if (InputMapper.STRICTDOWN)
                    {
                        StateManager.GameState = StateManager.GameStates.RPG;
                        RPGManager.Activate();
                    }
                    break;
            }  
        }
    }
}
