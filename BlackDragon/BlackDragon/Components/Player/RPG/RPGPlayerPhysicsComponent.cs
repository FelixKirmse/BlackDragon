using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Managers;
using Tile_Engine;

namespace BlackDragon.Components.RPG.Player
{
    class RPGPlayerPhysicsComponent : PhysicsComponent
    {
        private Vector2 desiredPosition;
        private Rectangle collisionRectangle = new Rectangle(2, 10, 12, 10);               

        public override void Update(GameObject obj, GameTime gameTime)
        {
            Vector2 moveAmount = desiredPosition - obj.Position;

            moveAmount = horizontalCollisionTest(moveAmount, obj);
            moveAmount = verticalCollisionTest(moveAmount, obj);

            obj.Position +=  moveAmount;

            obj.Velocity = Vector2.Zero;
        }

        public override void Receive<T>(string message, T obj)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "PHYSICS")
            {
                if (messageParts[1] == "DESIREDPOSITION")
                {
                    if (obj is Vector2)
                        this.desiredPosition = (Vector2)(object)obj;                    
                }
            }
        }

        private Vector2 horizontalCollisionTest(Vector2 moveAmount, GameObject obj)
        {
            if (moveAmount.X == 0) return moveAmount;
            Rectangle afterMoveRect = obj.GetCollisionRectangle(collisionRectangle);
            afterMoveRect.Offset((int)moveAmount.X, 0);
            Vector2 corner1, corner2, middle;
            if (moveAmount.X < 0)
            {
                corner1 = new Vector2(afterMoveRect.Left, afterMoveRect.Top + 1);
                corner2 = new Vector2(afterMoveRect.Left, afterMoveRect.Bottom - 1);
                middle = new Vector2(afterMoveRect.Left, (afterMoveRect.Top + afterMoveRect.Bottom) / 2);
            }
            else
            {
                corner1 = new Vector2(afterMoveRect.Right, afterMoveRect.Top + 1);
                corner2 = new Vector2(afterMoveRect.Right, afterMoveRect.Bottom - 1);
                middle = new Vector2(afterMoveRect.Right, (afterMoveRect.Top + afterMoveRect.Bottom) / 2);
            }
            
            Vector2 mapCell1 = TileMap.GetCellByPixel(corner1);
            Vector2 mapCell2 = TileMap.GetCellByPixel(corner2);
            Vector2 mapCell3 = TileMap.GetCellByPixel(middle);
            if (!TileMap.CellIsPassable(mapCell1) || !TileMap.CellIsPassable(mapCell2) || !TileMap.CellIsPassable(mapCell3))
            {
                moveAmount.X = 0;
                obj.Velocity.X = 0;
            }            
            return moveAmount;
        }

        private Vector2 verticalCollisionTest(Vector2 moveAmount, GameObject obj)
        {
            if (moveAmount.Y == 0) return moveAmount;
            Rectangle afterMoveRect = obj.GetCollisionRectangle(collisionRectangle);
            afterMoveRect.Offset((int)moveAmount.X, (int)moveAmount.Y);
            Vector2 corner1, corner2;
            if (moveAmount.Y < 0)
            {
                corner1 = new Vector2(afterMoveRect.Left + 1, afterMoveRect.Top);
                corner2 = new Vector2(afterMoveRect.Right - 1, afterMoveRect.Top);
            }
            else
            {
                corner1 = new Vector2(afterMoveRect.Left + 1, afterMoveRect.Bottom);
                corner2 = new Vector2(afterMoveRect.Right - 1, afterMoveRect.Bottom);
            }
            Vector2 mapCell1 = TileMap.GetCellByPixel(corner1);
            Vector2 mapCell2 = TileMap.GetCellByPixel(corner2);
            if (!TileMap.CellIsPassable(mapCell1) || !TileMap.CellIsPassable(mapCell2))
            {                
                moveAmount.Y = 0;
                obj.Velocity.Y = 0;
            }            
            return moveAmount;
        }
    }
}
