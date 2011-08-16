﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Graphics;
using Tile_Engine;

namespace BlackDragon
{
    public static class LevelManager
    {
        #region Declarations
        private static ContentManager Content;        
        private static int currentLevel;
        private static Vector2 respawnLocation;

        
        #endregion

        #region Properties
        public static int Currentlevel {
            get { return currentLevel; }
        }

        public static Vector2 RespawnLocation {
            get { return respawnLocation; }
            set { respawnLocation = value; }
        }
        #endregion

        #region Initialization
        public static void Initialize(ContentManager content, Player gamePlayer) {
            Content = content;
            player = gamePlayer;
        }
        #endregion

        #region Public Methods
        public static void LoadLevel(int levelNumber) {
            TileMap.LoadMap((System.IO.FileStream)TitleContainer.OpenStream(@"Content/Maps/platform/MAP" + levelNumber.ToString().PadLeft(3, '0') + ".MAP"));
            gemstones.Clear();
            enemies.Clear();
            for (int x = 0; x < TileMap.MapWidth; ++x) {
                for (int y = 0; y < TileMap.MapHeight; ++y) {
                    if (TileMap.CellCodeValue(x, y) == "START") {
                        player.WorldLocation = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight - 15);
                    }
                    if (TileMap.CellCodeValue(x, y) == "GEM") {
                        gemstones.Add(new Gemstone(Content, x, y));
                    }
                    if (TileMap.CellCodeValue(x, y) == "ENEMY") {
                        enemies.Add(new Enemy(Content, x, y));
                    }
                }
            }

            currentLevel = levelNumber;
            respawnLocation = player.WorldLocation;
        }

        public static void ReloadLevel() {
            Vector2 saveRespawn = respawnLocation;
            LoadLevel(currentLevel);
            respawnLocation = saveRespawn;
            player.WorldLocation = respawnLocation;
            Camera.Position = Camera.WorldToScreen(player.WorldLocation);
        }
        #endregion

        #region Update and Draw
        public static void Update(GameTime gameTime) {
            System.Diagnostics.Debug.WriteLine(player.WorldLocation);
            if (!player.Dead) {
                checkCurrentCellCode();
                for (int x = gemstones.Count - 1; x >= 0; --x) {
                    gemstones[x].Update(gameTime);
                    if (player.CollisionRectangle.Intersects(gemstones[x].CollisionRectangle)) {
                        gemstones.RemoveAt(x);
                        player.Score += 10;
                    }
                }

                for (int x = enemies.Count - 1; x >= 0; --x) {
                    enemies[x].Update(gameTime);
                    if (!enemies[x].Dead)
                    {
                        if (player.CollisionRectangle.Intersects(enemies[x].CollisionRectangle))
                        {
                            if (player.WorldCenter.Y < enemies[x].WorldLocation.Y)
                            {
                                player.Jump();
                                player.Score += 5;
                                enemies[x].PlayAnimation("die");
                                enemies[x].Dead = true;
                            }
                            else player.Kill();
                        }
                    }
                    else
                    {
                        if (!enemies[x].Enabled) {
                            enemies.RemoveAt(x);
                        }
                    }
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch) {
            foreach (Gemstone gemstone in gemstones) {
                gemstone.Draw(spriteBatch);
            }
            foreach (Enemy enemy in enemies) {
                enemy.Draw(spriteBatch);
            }
        }
        #endregion

        #region Helper Methods
        private static void checkCurrentCellCode() {
            string code = TileMap.CellCodeValue(TileMap.GetCellByPixel(player.WorldCenter));

            if (code == "DEAD") player.Kill();
        }
        #endregion
    }
}
