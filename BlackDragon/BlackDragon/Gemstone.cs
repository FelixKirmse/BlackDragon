using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Tile_Engine;

namespace Gemstone_Hunter
{
    public class Gemstone : GameObject
    {
        #region Constructor
        public Gemstone(ContentManager content, int cellX, int cellY){
            worldLocation.X = TileMap.TileWidth * cellX;
            worldLocation.Y = TileMap.TileHeight * cellY;

            frameWidth = TileMap.TileWidth;
            frameHeight = TileMap.TileHeight;

            animations.Add("idle",
                new AnimationStrip(
                    content.Load<Texture2D>(@"textures/Gem"),
                    48,
                    "idle"));
            animations["idle"].LoopAnimation = true;
            animations["idle"].FrameLength = 0.15f;
            PlayAnimation("idle");
            drawDepth = 0.875f;
            collisionRectangle = new Rectangle(9, 24, 30, 24);
            enabled = true;
        }
        #endregion
    }
}
