using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tile_Engine
{
    public static class TileMap
    {
        #region Declarations
        public const int TileWidth = 16;
        public const int TileHeight = 16;
        public static int MapWidth = 256;
        public static int MapHeight = 256;
        public const int MapLayers = 3;
        private const int skyTile = 0;
        private const int transparentTile = 278;
        private const int whiteTile = 1791;

        static private MapSquare[,] mapCells = new MapSquare[MapWidth, MapHeight];

        public static bool EditorMode = false;

        public static SpriteFont spriteFont;
        private static Texture2D tileSheet;
        #endregion

        #region Initialization
        public static void Initialize(Texture2D tileTexture) {
            tileSheet = tileTexture;
            for (int x = 0; x < MapWidth; ++x) {
                for (int y = 0; y < MapHeight; ++y) {
                    for (int z = 0; z < MapLayers; ++z) {
                        mapCells[x, y] = new MapSquare(skyTile, transparentTile, transparentTile, "", true);
                    }
                }
            }
        }
        #endregion

        #region Tile and Tile Sheet Handling
        public static int TilesPerRow {
            get { return tileSheet.Width / TileWidth; }
        }

        public static Rectangle TileSourceRectangle(int tileIndex) {
            return new Rectangle((tileIndex % TilesPerRow) * TileWidth, (tileIndex / TilesPerRow) * TileHeight, TileWidth, TileHeight);
        }
        #endregion

        #region Information about Map Cells
        public static int GetCellByPixelX(int pixelX) {
            return pixelX / TileWidth;
        }

        public static int GetCellByPixelY(int pixelY) {
            return pixelY / TileHeight;
        }

        public static Vector2 GetCellByPixel(Vector2 pixelLocation) {
            return new Vector2(GetCellByPixelX((int)pixelLocation.X), GetCellByPixelY((int)pixelLocation.Y));
        }

        public static Vector2 GetCellCenter(int cellX, int cellY) { 
            return new Vector2((cellX * TileWidth) + (TileWidth /2), (cellY * TileHeight) + (TileHeight /2));
        }

        public static Vector2 GetCellCenter(Vector2 cell) {
            return GetCellCenter((int)cell.X, (int)cell.Y);
        }

        public static Rectangle CellWorldRectangle(int cellX, int cellY) {
            return new Rectangle(cellX * TileWidth, cellY * TileHeight, TileWidth, TileHeight);
        }

        public static Rectangle CellWorldRectangle(Vector2 cell) {
            return CellWorldRectangle((int)cell.X, (int)cell.Y);
        }

        public static Rectangle CellScreenRectangle(int cellX, int cellY) {
            return Camera.WorldToScreen(CellWorldRectangle(cellX, cellY));
        }

        public static Rectangle CellScreenRectangle(Vector2 cell) {
            return CellScreenRectangle((int)cell.X, (int)cell.Y);
        }

        public static bool CellIsPassable(int cellX, int cellY) {
            MapSquare square = GetMapSquareAtCell(cellX, cellY);
            if (square == null) return false;
            else return square.Passable;
        }

        public static bool CellIsPassable(Vector2 cell) {
            return CellIsPassable((int)cell.X, (int)cell.Y);
        }

        public static bool CellIsPassableByPixel(Vector2 pixelLocation) { 
            return CellIsPassable(GetCellByPixelX((int)pixelLocation.X), GetCellByPixelY((int)pixelLocation.Y));
        }

        public static string CellCodeValue(int cellX, int cellY) {
            MapSquare square = GetMapSquareAtCell(cellX, cellY);

            if (square == null) return "";
            else return square.CodeValue;
        }

        public static string CellCodeValue(Vector2 cell) {
            return CellCodeValue((int)cell.X, (int)cell.Y);
        }
        #endregion

        #region Information about MapSquare objects
        public static MapSquare GetMapSquareAtCell(int tileX, int tileY) {
            if ((tileX >= 0) && (tileX < MapWidth) && (tileY >= 0) && (tileY < MapHeight)) {
                return mapCells[tileX, tileY];
            }
            else return null;
        }

        public static void SetMapSquareAtCell(int tileX, int tileY, MapSquare tile) {
            if ((tileX >= 0) && (tileX < MapWidth) && (tileY >= 0) && (tileY < MapHeight)) {
                mapCells[tileX, tileY] = tile;
            }
        }

        public static void SetTileAtCell(int tileX, int tileY, int layer, int tileIndex) {
            if ((tileX >= 0) && (tileX < MapWidth) && (tileY >= 0) && (tileY < MapHeight)) {
                mapCells[tileX, tileY].LayerTiles[layer] = tileIndex;
            }
        }

        public static MapSquare GetMapSquareAtPixel(int pixelX, int pixelY) {
            return GetMapSquareAtCell(GetCellByPixelX(pixelX), GetCellByPixelY(pixelY));
        }

        public static MapSquare GetMapSquareAtPixel(Vector2 pixelLocation) {
            return GetMapSquareAtPixel((int)pixelLocation.X, (int)pixelLocation.Y);
        }
        #endregion

        #region Drawing
        public static void Draw(SpriteBatch spriteBatch) { 
            int startX = GetCellByPixelX((int)Camera.Position.X);
            int endX = GetCellByPixelX((int)Camera.Position.X + Camera.ViewPortWidth);

            int startY = GetCellByPixelY((int)Camera.Position.Y);
            int endY = GetCellByPixelY((int)Camera.Position.Y + Camera.ViewPortHeight);

            for (int x = startX; x <= endX; ++x) {
                for (int y = startY; y <= endY; ++y) {
                    for (int z = 0; z < MapLayers; ++z) {
                        if ((x >= 0) && (y >= 0) && (x < MapWidth) && (y < MapHeight)) {
                            spriteBatch.Draw(tileSheet, CellScreenRectangle(x, y), TileSourceRectangle(mapCells[x, y].LayerTiles[z]), Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 1f - ((float)z * 0.1f));
                        }
                    }
                    if (EditorMode) {
                        DrawEditModeItems(spriteBatch, x, y);
                    }
                }
            }
        }

        public static void DrawEditModeItems(SpriteBatch spriteBatch, int x, int y) {
            if ((x < 0) || (y < 0) || (x >= MapWidth) || (y >= MapHeight)){
                return;
            }
            if (!CellIsPassable(x, y)) {
                spriteBatch.Draw(tileSheet, CellScreenRectangle(x, y), TileSourceRectangle(whiteTile), new Color(255, 0, 0, 80), 0f, Vector2.Zero, SpriteEffects.None, 0f);
            }
            if (mapCells[x, y].CodeValue != "") {
                Rectangle screenRect = CellScreenRectangle(x, y);

                spriteBatch.DrawString(spriteFont, mapCells[x, y].CodeValue, new Vector2(screenRect.X, screenRect.Y), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }
        #endregion

        #region Loading and Saving
        public static void SaveMap(FileStream fileStream) {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, mapCells);
            fileStream.Close();
        }

        public static void LoadMap(FileStream fileStream) {
            try {
                BinaryFormatter formatter = new BinaryFormatter();
                mapCells = (MapSquare[,])formatter.Deserialize(fileStream);
                fileStream.Close();
            } catch {
                ClearMap();
            }
        }

        public static void ClearMap() {
            for (int x = 0; x < MapWidth; ++x) {
                for (int y = 0; y < MapHeight; ++y) {
                    for (int z = 0; z < MapLayers; ++z) {
                        mapCells[x, y] = new MapSquare(skyTile, transparentTile, transparentTile, "", true);
                    }
                }
            }
        }
        #endregion
    }
}
