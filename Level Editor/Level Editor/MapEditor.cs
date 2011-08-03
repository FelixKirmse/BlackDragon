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
using Tile_Engine;
using Microsoft.Xna.Framework.Input;

using XNARectangle = Microsoft.Xna.Framework.Rectangle;

namespace Level_Editor
{
    
    public partial class MapEditor : Form
    {
        public Game1 game;
        private string cwd;
        private string modeModifier = @"\rpg";        

        public MapEditor()
        {
            InitializeComponent();            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Exit();
            Application.Exit();
        }

        private void LoadImageLists()
        {
            LoadImageLists(false);
        }

        private void LoadImageLists(bool createImages)
        {
            for (int i = 0; i < 2; ++i)
            {
                string filepath;
                if (i == 0)
                {
                    TileMap.TileOffset = 0;
                    filepath = Application.StartupPath + @"\Content\textures\TileSets\rpg.png";
                    rpgListTiles.Images.Clear();
                }
                else 
                {
                    TileMap.TileOffset = 1;
                    filepath = Application.StartupPath + @"\Content\textures\TileSets\platform.png";
                    platformListTiles.Images.Clear();
                }
                Bitmap tileSheet = new Bitmap(filepath);
                int tilecount = 0;
                for (int y = 0; y < tileSheet.Height / (TileMap.TileHeight + TileMap.TileOffset); ++y)
                {
                    for (int x = 0; x < tileSheet.Width / (TileMap.TileWidth + TileMap.TileOffset); ++x)
                    {

                        if (!createImages)
                        {
                            if(i == 0)
                                rpgListTiles.Images.Add(new Bitmap(Application.StartupPath + "/tiles/rpg/" + tilecount.ToString() + ".bmp"));
                            else
                                platformListTiles.Images.Add(new Bitmap(Application.StartupPath + "/tiles/platform/" + tilecount.ToString() + ".bmp"));

                            
                        }
                        else
                        {
                            Bitmap newBitmap = tileSheet.Clone(new System.Drawing.Rectangle(x * (TileMap.TileWidth + TileMap.TileOffset), y * (TileMap.TileHeight + TileMap.TileOffset), TileMap.TileWidth, TileMap.TileHeight), System.Drawing.Imaging.PixelFormat.DontCare);

                            if (i == 0)
                                rpgListTiles.Images.Add(newBitmap);
                            else
                                platformListTiles.Images.Add(newBitmap);                            

                            if(i == 0)
                                newBitmap.Save(Application.StartupPath + "/tiles/rpg/" + tilecount.ToString() + ".bmp");
                            else
                                newBitmap.Save(Application.StartupPath + "/tiles/platform/" + tilecount.ToString() + ".bmp");                            
                            
                        }
                        ++tilecount;
                    }
                }
            }            
        }

        private void ChangeImageList(string mode) {
            string filepath = "";
            switch(mode)
            {                
                case "RPG":
                    listTiles.SmallImageList = rpgListTiles;
                    filepath = Application.StartupPath + @"\Content\textures\TileSets\rpg.png";
                    break;
                case "Platform":
                    listTiles.SmallImageList = platformListTiles;
                    filepath = Application.StartupPath + @"\Content\textures\TileSets\platform.png";
                    break;
            }

            Bitmap tileSheet = new Bitmap(filepath);
            int tilecount = 0;
            listTiles.Clear();            

            for (int y = 0; y < tileSheet.Height / (TileMap.TileHeight + TileMap.TileOffset); ++y)
            {
                for (int x = 0; x < tileSheet.Width / (TileMap.TileWidth + TileMap.TileOffset); ++x)
                {
                    string itemName = tilecount.ToString();
                    listTiles.Items.Add(new ListViewItem(itemName, tilecount++));
                }
            }
             
        }
        

        private void FixScrollBarScales() {
            Camera.WorldRectangle = new XNARectangle(0, 0, TileMap.TileWidth * TileMap.MapWidth, TileMap.TileHeight * TileMap.MapHeight);
            Camera.ViewPortWidth = pctSurface.Width;
            Camera.ViewPortHeight = pctSurface.Height;

            Camera.Move(Vector2.Zero);

            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = Camera.WorldRectangle.Height - Camera.ViewPortHeight;

            hScrollBar1.Minimum = 0;
            hScrollBar1.Maximum = Camera.WorldRectangle.Width - Camera.ViewPortWidth;
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            timerGameUpdate.Stop();
            LoadImageLists();
            FixScrollBarScales();           

            for (int x = 0; x < 100; ++x) {
                cboMapNumber.Items.Add(x.ToString().PadLeft(3, '0'));
            }

            cboMapNumber.SelectedIndex = 0;            
            TileMap.EditorMode = true;
            backgroundToolStripMenuItem.Checked = true;                        
        }

        private void MapEditor_Resize(object sender, EventArgs e)
        {
            FixScrollBarScales();
        }        

        private void listTiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTiles.SelectedIndices.Count > 0) {
                defaultTileRadioButton.Checked = false;
                whiteTileRadioButton.Checked = false;
                transparentTileRadioButton.Checked = false;
                game.DrawTile = listTiles.SelectedIndices[0];
                tileIndexLabel.Text = "Selected Tile Index: "+listTiles.SelectedIndices[0].ToString();                
            }
        }

        private void radioPassable_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPassable.Checked){
                game.SettingCode = false;
                game.MakePassable = true;
                game.MakeUnpassable = false;
                game.GettingCode = false;
            }
        }        

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.DrawLayer = 0;
            backgroundToolStripMenuItem.Checked = true;
            interactiveToolStripMenuItem.Checked = false;
            foregroundToolStripMenuItem.Checked = false;
        }

        private void interactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.DrawLayer = 1;
            backgroundToolStripMenuItem.Checked = false;
            interactiveToolStripMenuItem.Checked = true;
            foregroundToolStripMenuItem.Checked = false;
        }

        private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.DrawLayer = 2;
            backgroundToolStripMenuItem.Checked = false;
            interactiveToolStripMenuItem.Checked = false;
            foregroundToolStripMenuItem.Checked = true;
        }

        private void timerGameUpdate_Tick(object sender, EventArgs e)
        {
            FixScrollBarScales();
            
            if(Form.ActiveForm == this)
            game.Tick();           

            coordLbl.Text = "MapCell: (" + game.CellCoords.X + @"|" + game.CellCoords.Y+")";
            
        }

        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                TileMap.LoadMap(new FileStream(cwd + modeModifier + @"/MAP" + cboMapNumber.Items[cboMapNumber.SelectedIndex] + ".MAP", FileMode.Open));
                tileMapHeightInput.Text = TileMap.MapHeight.ToString();
                tileMapWidthInput.Text = TileMap.MapWidth.ToString();
            }
            catch {
                System.Diagnostics.Debug.Print("Unable to load map file");
            }
                
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TileMap.SaveMap(new FileStream(cwd + modeModifier + @"/MAP" + cboMapNumber.Items[cboMapNumber.SelectedIndex] + ".MAP", FileMode.Create));
        }

        private void clearMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TileMap.ClearMap();
        }        

        private void MapEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            game.Exit();
            Application.Exit();
        }

        private void radioUnpassable_CheckedChanged(object sender, EventArgs e)
        {
            if (radioUnpassable.Checked)
            {
                game.SettingCode = false;
                game.MakePassable = false;
                game.MakeUnpassable = true;
                game.GettingCode = false;
            }            
        }

        private void radioCode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCode.Checked)
            {
                game.SettingCode = true;
                game.MakePassable = false;
                game.MakeUnpassable = false;
                game.GettingCode = false;
            }            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();
            cwd = folderBrowser.SelectedPath;
            cwdLabel.Text = "Current Working Directory: " + cwd + modeModifier;
            StreamWriter sw = new StreamWriter(Application.StartupPath + @"\config.cfg");
            
            sw.WriteLine(cwd);
            sw.Close();
        }

        private void MapEditor_Shown(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + @"\config.cfg");
                cwd = sr.ReadLine();
                sr.Close();
                cwdLabel.Text = cwd + modeModifier;
            }
            catch {
                folderBrowser.ShowDialog();
                cwd = folderBrowser.SelectedPath;
                cwdLabel.Text = cwd + modeModifier;
                StreamWriter sw = new StreamWriter(Application.StartupPath + @"\config.cfg");                
                sw.WriteLine(cwd);
                sw.Close();
            }
            if (cwd == "")
            {
                folderBrowser.ShowDialog();
                cwd = folderBrowser.SelectedPath;
                cwdLabel.Text = cwd + modeModifier; 
                StreamWriter sw = new StreamWriter(Application.StartupPath + @"\config.cfg");                
                sw.WriteLine(cwd);
                sw.Close();
            }            
            modeComboBox.SelectedIndex = 0;
            timerGameUpdate.Start();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            Process.Start(cwd + @"\..\..\BlackDragon.exe");
            System.Diagnostics.Debug.Print(cwd + @"\..\..\BlackDragon.exe");
        }       

        private void tileMapWidthInput_Leave(object sender, EventArgs e)
        {
            TileMap.MapWidth = Convert.ToInt32(tileMapWidthInput.Text);
            TileMap.ClearMap();
        }

        private void tileMapHeightInput_Leave(object sender, EventArgs e)
        {
            TileMap.MapHeight = Convert.ToInt32(tileMapHeightInput.Text);
            TileMap.ClearMap();
        }

        private void modeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (modeComboBox.Items[modeComboBox.SelectedIndex].ToString()) 
            {
                case "RPG":
                    modeModifier = @"\rpg";
                    TileMap.TileOffset = 0;
                    TileMap.DefaultTile = 0;
                    TileMap.TransparentTile = 278;
                    TileMap.WhiteTile = 1791;
                    ChangeImageList("RPG");                    
                    game.ChangeTileMapTileSet(game.RpgTiles);
                    break;
                case "Platform":
                    modeModifier = @"\platform";
                    TileMap.TileOffset = 1;
                    TileMap.DefaultTile = 125;
                    TileMap.WhiteTile = 830;
                    TileMap.TransparentTile = 831;
                    ChangeImageList("Platform");
                    game.ChangeTileMapTileSet(game.PlatformTiles);                   
                    break;
            }
        }

        private void defaultTileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultTileRadioButton.Checked)
            {
                game.DrawTile = TileMap.DefaultTile;
                tileIndexLabel.Text = "Selected Tile Index: " + TileMap.DefaultTile.ToString();
            }
        }

        private void whiteTileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (whiteTileRadioButton.Checked)
            {
                game.DrawTile = TileMap.WhiteTile;
                tileIndexLabel.Text = "Selected Tile Index: " + TileMap.WhiteTile.ToString();
            }
        }

        private void transparentTileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (transparentTileRadioButton.Checked)
            {
                game.DrawTile = TileMap.TransparentTile;
                tileIndexLabel.Text = "Selected Tile Index: " + TileMap.TransparentTile.ToString();
            }
        }

        private void backgroundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (backgroundRadioButton.Checked)
            {
                game.DrawLayer = 0;
                backgroundToolStripMenuItem.Checked = true;
                interactiveToolStripMenuItem.Checked = false;
                foregroundToolStripMenuItem.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (interactiveRadioButton.Checked)
            {
                game.DrawLayer = 1;
                backgroundToolStripMenuItem.Checked = false;
                interactiveToolStripMenuItem.Checked = true;
                foregroundToolStripMenuItem.Checked = false;
            }
        }

        private void foregroundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (foregroundRadioButton.Checked)
            {
                game.DrawLayer = 2;
                backgroundToolStripMenuItem.Checked = false;
                interactiveToolStripMenuItem.Checked = false;
                foregroundToolStripMenuItem.Checked = true;
            }
        }        

        private void editModeItemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (editModeItemCheckBox.Checked)
                TileMap.EditorMode = true;
            else
                TileMap.EditorMode = false;
        }

        private void rectangleSelectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rectangleSelectionCheckBox.Checked)
            {
                game.FillMode = "RECTANGLEFILL";
                getCodeRadio.Enabled = false;
            }
            else
            {
                game.FillMode = "TILEFILL";
                getCodeRadio.Enabled = true;
            }

            
        }

        private void getCodeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (getCodeRadio.Checked)
            {
                game.SettingCode = false;
                game.MakePassable = false;
                game.MakeUnpassable = false;
                game.GettingCode = true;
            } 
        }

        public void GetCodeList(List<string> codeList)
        {
            codeListBox.Items.Clear();
            foreach (string code in codeList)
            {
                codeListBox.Items.Add(code);
            }
        }

        public void SetCodeList(int cellX,int cellY)
        {
            List<string> codeList = new List<string>();             
            foreach (string code in codeListBox.Items)
            {
                codeList.Add(code);
            }

            MapSquare square = TileMap.GetMapSquareAtCell(cellX, cellY);
            square.Codes = codeList;
        }

        private void addCodeButton_Click(object sender, EventArgs e)
        {
            if(addCodeInput.Text != "")
                codeListBox.Items.Add(addCodeInput.Text);
            addCodeInput.Text = "";
        }

        private void removeCodesButton_Click(object sender, EventArgs e)
        {
            string[] items = new string[codeListBox.SelectedItems.Count];
            for (int i = 0; i < codeListBox.SelectedItems.Count; ++i)
            {
                items[i] = (string)codeListBox.SelectedItems[i];
            }
            foreach (string item in items)
            {
                codeListBox.Items.Remove(item);
            }
        }

        private void addCodeInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
            {
                addCodeButton_Click(sender, e);
            }
        }

        private void codeListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Delete))
            {
                removeCodesButton_Click(sender, e);
            }
        }
    }
}
