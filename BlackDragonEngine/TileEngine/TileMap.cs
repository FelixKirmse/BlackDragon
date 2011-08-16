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

namespace BlackDragonEngine.TileEngine
{
    [Serializable]
    public class MapRow
    {
        public List<MapSquare> MapCellRow = new List<MapSquare>();

        public void AddRow(int background, int interactive, int foreground, bool passable)
        {
            MapCellRow.Add(new MapSquare(background, interactive, foreground, passable));
        }
    }

    public static class TileMap
    {
        #region Declarations
        public const int TileWidth = 16;
        public const int TileHeight = 16;
        public static int MapWidth = 50;
        public static int MapHeight = 38;
        public const int MapLayers = 3;
        
        public static int DefaultTile = 0;
        public static int TransparentTile = 278;
        public static int WhiteTile = 1791;

        public static int TileOffset = 0;
        
        static private List<MapRow> MapCellColumns = new List<MapRow>();

        //static private MapSquare[,] mapCells = new MapSquare[MapWidth, MapHeight];

        public static bool EditorMode = false;

        public static SpriteFont spriteFont;
        private static Texture2D tileSheet;
        #endregion

        #region Initialization
        public static void Initialize(Texture2D tileTexture) {
            tileSheet = tileTexture;

            MapCellColumns.Clear();
            for (int x = 0; x < MapWidth; ++x)
            {
                MapRow newColumn = new MapRow();
                for (int y = 0; y < MapHeight; ++y)
                {

                    newColumn.AddRow(DefaultTile, TransparentTile, TransparentTile, true);

                    //mapCells[x, y] = new MapSquare(skyTile, transparentTile, transparentTile, "", true);

                }
                MapCellColumns.Add(newColumn);
            }
        }
        #endregion

        #region Tile and Tile Sheet Handling
        public static int TilesPerRow {
            get { return tileSheet.Width / (TileWidth+TileOffset); }
        }

        public static Rectangle TileSourceRectangle(int tileIndex) {
            return new Rectangle((tileIndex % TilesPerRow) * (TileWidth+TileOffset), (tileIndex / TilesPerRow) * (TileHeight+TileOffset), TileWidth, TileHeight);
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

        public static List<string> GetCellCodes(int cellX, int cellY)
        {
            MapSquare square = GetMapSquareAtCell(cellX, cellY);
            if (square == null) return null;
            return square.Codes;
        }

        public static List<string> GetCellCodes(Vector2 cell) {
            return GetCellCodes((int)cell.X, (int)cell.Y);
        }
        #endregion

        #region Information about MapSquare objects
        public static MapSquare GetMapSquareAtCell(int tileX, int tileY) {
            if ((tileX >= 0) && (tileX < MapWidth) && (tileY >= 0) && (tileY < MapHeight)) {
                return MapCellColumns[tileX].MapCellRow[tileY];
                // return mapCells[tileX, tileY];
            }
            else return null;
        }

        public static void SetMapSquareAtCell(int tileX, int tileY, MapSquare tile) {
            if ((tileX >= 0) && (tileX < MapWidth) && (tileY >= 0) && (tileY < MapHeight)) {
                MapCellColumns[tileX].MapCellRow[tileY] = tile;
                //mapCells[tileX, tileY] = tile;
            }
        }

        public static void SetTileAtCell(int tileX, int tileY, int layer, int tileIndex) {
            if ((tileX >= 0) && (tileX < MapWidth) && (tileY >= 0) && (tileY < MapHeight)) {
                MapCellColumns[tileX].MapCellRow[tileY].LayerTiles[layer] = tileIndex;
                //mapCells[tileX, tileY].LayerTiles[layer] = tileIndex;
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
                            spriteBatch.Draw(tileSheet, CellScreenRectangle(x, y), TileSourceRectangle(MapCellColumns[x].MapCellRow[y].LayerTiles[z]), Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 1f - ((float)z * 0.1f));
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
                spriteBatch.Draw(tileSheet, CellScreenRectangle(x, y), TileSourceRectangle(WhiteTile), new Color(255, 0, 0, 80), 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            }
            if (MapCellColumns[x].MapCellRow[y].Codes.Count != 0)
            {
                spriteBatch.Draw(tileSheet, CellScreenRectangle(x, y), TileSourceRectangle(WhiteTile), new Color(0, 0, 255, 80), 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
                spriteBatch.DrawString(spriteFont, MapCellColumns[x].MapCellRow[y].Codes.Count.ToString(), Camera.WorldToScreen(new Vector2(x*TileWidth, y*TileHeight)), Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, .09f);                 
            }
        }

        

        public static void DrawRectangleIndicator(SpriteBatch spriteBatch, MouseState ms, Vector2 startCell)
        {
            if ((ms.X > 0) && (ms.Y > 0) && (ms.X < Camera.ViewPortWidth) && (ms.Y < Camera.ViewPortHeight))
            {
                Vector2 mouseLoc = Camera.ScreenToWorld(new Vector2(ms.X, ms.Y));
                int cellX = (int)MathHelper.Clamp(TileMap.GetCellByPixelX((int)mouseLoc.X), 0, TileMap.MapWidth - 1);
                int cellY = (int)MathHelper.Clamp(TileMap.GetCellByPixelY((int)mouseLoc.Y), 0, TileMap.MapHeight - 1);

                for (int cellx = (int)startCell.X; cellx <= cellX; ++cellx)
                {
                    for (int celly = (int)startCell.Y; celly <= cellY; ++celly)
                    {
                        spriteBatch.Draw(tileSheet, CellScreenRectangle(cellx, celly), TileSourceRectangle(WhiteTile), new Color(1,1,1,80) , 0f, Vector2.Zero, SpriteEffects.None, 0f);
                    }
                }
            }
        }
        #endregion

        #region Loading and Saving
        public static void SaveMap(FileStream fileStream) {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, MapCellColumns);
            fileStream.Close();
        }

        public static void LoadMap(FileStream fileStream) {
            try {
                MapCellColumns.Clear();
                BinaryFormatter formatter = new BinaryFormatter();
                MapCellColumns = (List<MapRow>)formatter.Deserialize(fileStream);
                fileStream.Close();

                MapWidth = MapCellColumns.Count;
                MapHeight = MapCellColumns[0].MapCellRow.Count;
            } catch {
                ClearMap();
                fileStream.Close();
            }
        }

        public static void ClearMap()
        {
            MapCellColumns.Clear();
            for (int x = 0; x < MapWidth; ++x)
            {
                MapRow newColumn = new MapRow();
                for (int y = 0; y < MapHeight; ++y)
                {
                    
                    newColumn.AddRow(DefaultTile, TransparentTile, TransparentTile, true);
                    
                    //mapCells[x, y] = new MapSquare(skyTile, transparentTile, transparentTile, "", true);

                }
                MapCellColumns.Add(newColumn);
            }
        }
        #endregion
    }
}