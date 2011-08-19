using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using System.IO;
using BlackDragonEngine.HelpMaps;
using Microsoft.Xna.Framework.Input;
using BlackDragonEngine.Helpers;
using XNARectangle = Microsoft.Xna.Framework.Rectangle;
using xTile;

namespace CodeEditor
{
    public partial class EditorForm : Form
    {
        public Editor Editor;        
        private string cwd;
        private string mapPath;
        private string editorContentPath;

        private string currentMap;

        public EditorForm()
        {
            InitializeComponent();
        }

        private void Exit(object sender, EventArgs e)
        {
            Editor.Exit();
            Application.Exit();
        }

        private void gameUpdate_Tick(object sender, EventArgs e)
        {
            FixScrollBarScales();

            if (Form.ActiveForm == this)
                Editor.Tick();
        }

        public void FixScrollBarScales()
        {
            Camera.WorldRectangle = new XNARectangle(0, 0, TileMap.TileWidth * TileMap.MapWidth, TileMap.TileHeight * TileMap.MapHeight);
            Camera.ViewPortWidth = editorOutput.Width;
            Camera.ViewPortHeight = editorOutput.Height;
                        
            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = Camera.WorldRectangle.Height - Camera.ViewPortHeight;

            hScrollBar1.Minimum = 0;
            hScrollBar1.Maximum = Camera.WorldRectangle.Width - Camera.ViewPortWidth;
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            FixScrollBarScales();
        }

        private void EditorForm_Shown(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + @"\config.cfg");
                cwd = sr.ReadLine();
                editorContentPath = sr.ReadLine();
                sr.Close();               
            }
            catch
            {
                folderBrowser.Description = @"Select Game's Map Directory";
                folderBrowser.ShowDialog();
                cwd = folderBrowser.SelectedPath;

                folderBrowser.Description = @"Select the ContentFolder of the Editor";
                folderBrowser.ShowDialog();
                editorContentPath = folderBrowser.SelectedPath;

                StreamWriter sw = new StreamWriter(Application.StartupPath + @"\config.cfg");
                sw.WriteLine(cwd);
                sw.WriteLine(editorContentPath);
                sw.Close();
            }
            while (cwd == "")
            {
                folderBrowser.Description = @"Select Game's Map Directory";
                folderBrowser.ShowDialog();
                cwd = folderBrowser.SelectedPath;

                folderBrowser.Description = @"Select the ContentFolder of the Editor";
                folderBrowser.ShowDialog();
                editorContentPath = folderBrowser.SelectedPath;

                StreamWriter sw = new StreamWriter(Application.StartupPath + @"\config.cfg");
                sw.WriteLine(cwd);
                sw.WriteLine(editorContentPath);
                sw.Close();
            }
            gameUpdate.Start();
            CopyContentFiles();
            openFileDialog.Title = "Select Map to Load";
            openFileDialog.ShowDialog();
        }

        private void CopyContentFiles()
        {                       
            string sourceTextures = cwd + @"\textures\TileSets";
            string sourceMaps = cwd + @"\maps";
            mapPath = sourceMaps;
            openFileDialog.InitialDirectory = mapPath;            
        }       

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            currentMap = openFileDialog.SafeFileName.Split('.')[0];
            Editor.CurrentMap = Editor.Content.Load<Map>(@"maps/" + currentMap);
            Editor.CurrentMap.LoadTileSheets(Editor.DisplayDevice);

            int editorLayerInt = Editor.CurrentMap.Properties["PlayerLayer"];
            xTile.Layers.Layer editorLayer = Editor.CurrentMap.Layers[editorLayerInt];
            TileMap.TileHeight = editorLayer.TileHeight;
            TileMap.TileWidth = editorLayer.TileWidth;
            TileMap.MapHeight = editorLayer.LayerHeight;
            TileMap.MapWidth = editorLayer.LayerWidth;
        }

        private void newWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowser.Description = @"Select Game's Content Directory";
            folderBrowser.ShowDialog();
            cwd = folderBrowser.SelectedPath;

            folderBrowser.Description = @"Select the ContentFolder of the Editor";
            folderBrowser.ShowDialog();
            editorContentPath = folderBrowser.SelectedPath;

            StreamWriter sw = new StreamWriter(Application.StartupPath + @"\config.cfg");
            sw.WriteLine(cwd);
            sw.WriteLine(editorContentPath);
            sw.Close();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void contentCopyButton_Click(object sender, EventArgs e)
        {
            CopyContentFiles();
            Exit(null, null);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TileMap.SaveMap(new FileStream(mapPath + @"/" + currentMap + ".map", FileMode.Create));
        }
    }
}
