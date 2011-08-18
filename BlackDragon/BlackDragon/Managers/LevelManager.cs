using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragonEngine.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using BlackDragon.Managers;
using BlackDragon.Providers;
using System.Windows.Forms;
using xTile;
using BlackDragonEngine.Providers;

namespace BlackDragon.Managers
{
    static class LevelManager
    {
        private static string currentLevel;
        public static Map CurrentMap;

        public static void LoadLevel(string levelName)
        {
            currentLevel = levelName;
            string mode = "";
            switch(StateManager.GameState)
            {
                case GameStates.RPG:
                    mode = "rpg";
                    break;
                case GameStates.Platform:
                    mode = "platform";
                    break;
            }
            TileMap.LoadMap(new FileStream(Application.StartupPath + @"\Content\maps\" + mode + @"\" + levelName + ".map", FileMode.Open));
            CurrentMap = MapProvider.GetMap(levelName);
            CodeManager.CheckCodes();
            GameVariableProvider.SaveState.CurrentLevel = levelName;
            Camera.UpdateWorldRectangle();
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
