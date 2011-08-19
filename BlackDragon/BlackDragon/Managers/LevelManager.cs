using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragonEngine.HelpMaps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using BlackDragon.Managers;
using BlackDragon.Providers;
using System.Windows.Forms;
using xTile;
using BlackDragonEngine.Providers;
using BlackDragonEngine.Helpers;

namespace BlackDragon.Managers
{
    static class LevelManager
    {
        private static string currentLevel;
        public static Map CurrentMap;

        public static void LoadLevel(string levelName)
        {
            currentLevel = levelName;                        
            TileMap.LoadMap(new FileStream(Application.StartupPath + @"\Content\maps\" + levelName + ".map", FileMode.Open));
            CurrentMap = MapProvider.GetMap(levelName);
            CodeManager.CheckCodes();
            GameVariableProvider.SaveState.CurrentLevel = levelName;
            Camera.UpdateWorldRectangle();
            CurrentMap.Layers[CurrentMap.Properties["PlayerLayer"]].AfterDraw += ((BlackDragon)VariableProvider.Game).OnAfterDraw;

            int editorLayerInt = CurrentMap.Properties["PlayerLayer"];
            xTile.Layers.Layer editorLayer = CurrentMap.Layers[editorLayerInt];
            TileMap.TileHeight = editorLayer.TileHeight;
            TileMap.TileWidth = editorLayer.TileWidth;
            TileMap.MapHeight = editorLayer.LayerHeight;
            TileMap.MapWidth = editorLayer.LayerWidth;
        }

        public static void Draw()
        {
            CurrentMap.Draw(VariableProvider.DisplayDevice, VariableProvider.Viewport);
        }

        public static void ReloadLevel()
        {
            LoadLevel(currentLevel);
        }
    }
}
