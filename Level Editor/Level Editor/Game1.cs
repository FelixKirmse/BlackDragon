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
using Tile_Engine;
using System.Windows.Forms;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace Level_Editor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        IntPtr drawSurface;
        Form parentForm;
        PictureBox pictureBox;
        Control gameForm;
        public int DrawLayer = 0;
        public int DrawTile = 0;
        public bool EditingCode = false;
        public bool MakeUnpassable = false;
        public bool MakePassable = true;
        public string CurrentCodeValue = "";
        public string HoverCodeValue = "";

        public MouseState lastMouseState;
        VScrollBar vscroll;
        HScrollBar hscroll;



        public Game1(IntPtr drawSurface, Form parentForm, PictureBox surfacePictureBox)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.drawSurface = drawSurface;
            this.parentForm = parentForm;
            this.pictureBox = surfacePictureBox;

            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);

            Mouse.WindowHandle = drawSurface;

            gameForm = Control.FromHandle(this.Window.Handle);
            gameForm.VisibleChanged += new EventHandler(gameForm_VisibleChanged);
            pictureBox.SizeChanged += new EventHandler(pictureBox_SizeChanged);

            vscroll = (VScrollBar)parentForm.Controls["vScrollBar1"];
            hscroll = (HScrollBar)parentForm.Controls["hScrollBar1"];
        }

        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e) {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface;
        }

        private void gameForm_VisibleChanged(object sender, EventArgs e) {
            if (gameForm.Visible) gameForm.Visible = false;
        }

        void pictureBox_SizeChanged(object sender, EventArgs e) {
            if (parentForm.WindowState != FormWindowState.Minimized) {
                graphics.PreferredBackBufferWidth = pictureBox.Width;
                graphics.PreferredBackBufferHeight = pictureBox.Height;
                Camera.ViewPortWidth = pictureBox.Width;
                Camera.ViewPortHeight = pictureBox.Height;
                graphics.ApplyChanges();
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Camera.ViewPortWidth = pictureBox.Width;
            Camera.ViewPortHeight = pictureBox.Height;
            Camera.WorldRectangle = new Rectangle(0, 0, TileMap.TileWidth * TileMap.MapWidth, TileMap.TileHeight * TileMap.MapHeight);
            TileMap.Initialize(Content.Load<Texture2D>(@"textures/pkmtiles"));
            TileMap.spriteFont = Content.Load<SpriteFont>(@"fonts/pericles8");
            lastMouseState = Mouse.GetState();
            pictureBox_SizeChanged(null, null);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            Camera.Position = new Vector2(hscroll.Value, vscroll.Value);

            MouseState ms = Mouse.GetState();

            if ((ms.X > 0) && (ms.Y > 0) && (ms.X < Camera.ViewPortWidth) && (ms.Y < Camera.ViewPortHeight)) {
                Vector2 mouseLoc = Camera.ScreenToWorld(new Vector2(ms.X, ms.Y));
                if (Camera.WorldRectangle.Contains((int)mouseLoc.X, (int)mouseLoc.Y)) {
                    if (ms.LeftButton == ButtonState.Pressed) { 
                        TileMap.SetTileAtCell(TileMap.GetCellByPixelX((int)mouseLoc.X),TileMap.GetCellByPixelY((int)mouseLoc.Y),DrawLayer, DrawTile);
                    }
                    if ((ms.RightButton == ButtonState.Pressed)) {
                        if (EditingCode) {
                            TileMap.GetMapSquareAtCell(TileMap.GetCellByPixelX((int)mouseLoc.X), TileMap.GetCellByPixelY((int)mouseLoc.Y)).CodeValue = CurrentCodeValue;
                        }
                        else if(MakePassable) {
                            TileMap.GetMapSquareAtCell(TileMap.GetCellByPixelX((int)mouseLoc.X), TileMap.GetCellByPixelY((int)mouseLoc.Y)).Passable = true;
                        }
                        else if (MakeUnpassable) {
                            TileMap.GetMapSquareAtCell(TileMap.GetCellByPixelX((int)mouseLoc.X), TileMap.GetCellByPixelY((int)mouseLoc.Y)).Passable = false;
                        }
                    }
                    HoverCodeValue = TileMap.GetMapSquareAtCell(TileMap.GetCellByPixelX((int)mouseLoc.X), TileMap.GetCellByPixelY((int)mouseLoc.Y)).CodeValue;
                }
            }
            lastMouseState = ms;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            TileMap.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
