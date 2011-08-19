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
using System.Windows.Forms;
using BlackDragonEngine.HelpMaps;
using BlackDragonEngine.Helpers;
using xTile;
using xTile.Display;
using xTile.Dimensions;
using xRectangle = xTile.Dimensions.Rectangle;

namespace CodeEditor
{
    public class Editor : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        IntPtr drawSurface;
        Form parentForm;
        PictureBox pictureBox;
        Control gameForm;
        MouseState ms;
        VScrollBar vscroll;
        HScrollBar hscroll;

        public XnaDisplayDevice DisplayDevice;
        public xRectangle Viewport;
        public Map CurrentMap;

        public Editor(IntPtr drawSurface, Form parentForm, PictureBox surfacePictureBox)
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

        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface;
        }

        private void gameForm_VisibleChanged(object sender, EventArgs e)
        {
            if (gameForm.Visible) gameForm.Visible = false;
        }

        void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (parentForm.WindowState != FormWindowState.Minimized)
            {
                graphics.PreferredBackBufferWidth = pictureBox.Width;
                graphics.PreferredBackBufferHeight = pictureBox.Height;
                Camera.ViewPortWidth = pictureBox.Width;
                Camera.ViewPortHeight = pictureBox.Height;
                graphics.ApplyChanges();
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            DisplayDevice = new XnaDisplayDevice(Content, GraphicsDevice);
            Viewport = new xRectangle(new Size(800, 600));

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Form.ActiveForm == parentForm)
            {
                Viewport.Location = new Location(hscroll.Value, vscroll.Value);
                Camera.Position = new Vector2(hscroll.Value, vscroll.Value);
                ms = Mouse.GetState();

                if (CurrentMap != null)
                {
                    CurrentMap.Update(gameTime.ElapsedGameTime.Milliseconds);
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            if (CurrentMap != null)
            {
                CurrentMap.Draw(DisplayDevice, Viewport);
            }
            base.Draw(gameTime);
        }
    }
}
