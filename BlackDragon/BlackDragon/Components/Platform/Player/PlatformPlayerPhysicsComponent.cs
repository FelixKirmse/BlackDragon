using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tile_Engine;
using BlackDragon.Providers;
using Microsoft.Xna.Framework.Input;

namespace BlackDragon.Components.Platform.Player
{
    class PlatformPlayerPhysicsComponent : PhysicsComponent
    {
        private float gravity;
        private float horiz;        

        public override void Update(GameObject obj, GameTime gameTime)
        {
            Vector2 bottomLeftCorner, bottomRightCorner, topLeftCorner, topRightCorner, middleLeft, middleRight;            

            if (horiz != 0)
            {
                for (int i = 0; i < Math.Abs(horiz); ++i)
                {           
                    obj.Position.X += horiz / Math.Abs(horiz);

                    bottomLeftCorner = TileMap.GetCellByPixel(new Vector2(obj.CollisionRectangle.Left - 1, obj.CollisionRectangle.Bottom));
                    bottomRightCorner = TileMap.GetCellByPixel(new Vector2(obj.CollisionRectangle.Right + 1, obj.CollisionRectangle.Bottom));

                    topLeftCorner = TileMap.GetCellByPixel(new Vector2(obj.CollisionRectangle.Left - 1, obj.CollisionRectangle.Top));
                    topRightCorner = TileMap.GetCellByPixel(new Vector2(obj.CollisionRectangle.Right + 1, obj.CollisionRectangle.Top));

                    middleLeft = TileMap.GetCellByPixel(new Vector2(obj.CollisionRectangle.Left - 1, (obj.CollisionRectangle.Bottom + obj.CollisionRectangle.Top) / 2));
                    middleRight = TileMap.GetCellByPixel(new Vector2(obj.CollisionRectangle.Right + 1, (obj.CollisionRectangle.Bottom + obj.CollisionRectangle.Top) / 2));

                    if (!TileMap.CellIsPassable(bottomLeftCorner) || !TileMap.CellIsPassable(bottomRightCorner) || !TileMap.CellIsPassable(topRightCorner) || !TileMap.CellIsPassable(topLeftCorner) || !TileMap.CellIsPassable(middleRight) || !TileMap.CellIsPassable(middleLeft))
                    {
                        obj.Position.X -= horiz / Math.Abs(horiz);                        
                        horiz = 0;
                        break;
                    }
                }
            }
        }

        private void gravityLoop(GameObject obj)
        {
            Vector2 bottomLeftCorner, bottomRightCorner, topLeftCorner, topRightCorner;

            

            if (gravity != 0)
            {
                for (int i = 0; i < Math.Abs(gravity); ++i)
                {
                    bottomLeftCorner = TileMap.GetCellByPixel(new Vector2(obj.CollisionRectangle.Left, obj.CollisionRectangle.Bottom + 1));
                    bottomRightCorner = TileMap.GetCellByPixel(new Vector2(obj.CollisionRectangle.Right - 1, obj.CollisionRectangle.Bottom + 1));

                    topLeftCorner = TileMap.GetCellByPixel(new Vector2(obj.CollisionRectangle.Left, obj.CollisionRectangle.Top - 1));
                    topRightCorner = TileMap.GetCellByPixel(new Vector2(obj.CollisionRectangle.Right - 1, obj.CollisionRectangle.Top - 1));

                    if (gravity > 0 && (!TileMap.CellIsPassable(bottomLeftCorner) || !TileMap.CellIsPassable(bottomRightCorner)))
                    {
                        gravity = 0;                        
                        obj.Send<int>("INPUT_SET_JUMPCOUNT", 0);
                        obj.Send<bool>("INPUT_SET_ONGROUND", true);
                        break;
                    }

                    if (gravity < 0 && (!TileMap.CellIsPassable(topLeftCorner) || !TileMap.CellIsPassable(topRightCorner)))
                    {
                        gravity = 0;
                        obj.Position.Y += 1;
                        break;
                    }

                    if (gravity > 0)
                    {
                        obj.Position.Y += 1;                        
                    }

                    if (gravity < 0)
                    {
                        obj.Position.Y -= 1;                        
                    }
                }
            }
            obj.Send<float>("INPUT_SET_GRAVITY", gravity);            
        }

        public override void Receive<T>(string message, T obj)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "PHYSICS")
            {
                if (messageParts[1] == "SET")
                {
                    switch (messageParts[2])
                    {
                        case "GRAVITY":
                            if (obj is float)
                                gravity = (float)(object)obj;
                            break;

                        case "HORIZ":
                            if (obj is float)
                                horiz = (float)(object)obj;
                            break;                        
                    }
                }
                if (messageParts[1] == "RUN")
                {
                    if (messageParts[2] == "GRAVITYLOOP")
                    {
                        gravityLoop((GameObject)(object)obj);
                    }
                }
            }
        }
    }
}
