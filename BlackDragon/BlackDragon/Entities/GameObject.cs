using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Components;

namespace BlackDragon.Entities
{
    class GameObject
    {
        public Vector2 Velocity;
        public Vector2 Position;
        public Rectangle PublicCollisionRectangle;        

        private List<Component> components = new List<Component>();

        public GameObject(List<Component> components)
        {
            this.components = components;
        }        

        public void Update(GameTime gameTime)
        {
            foreach (Component component in components)
            {
                component.Update(this, gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component component in components)
            {
                if (component is GraphicsComponent)
                {
                    ((GraphicsComponent)component).Draw(this, spriteBatch);
                }
            }
        }        

        public void Send<T>(string Message, T obj)
        {
            foreach (Component component in components)
            {
                component.Receive<T>(Message, obj);
            }
        }

        public Rectangle GetCollisionRectangle(Rectangle collisionRectangle)
        {
            if (PublicCollisionRectangle != collisionRectangle)
                PublicCollisionRectangle = collisionRectangle;
            return new Rectangle((int)Position.X + collisionRectangle.X, (int)Position.Y + collisionRectangle.Y, collisionRectangle.Width, collisionRectangle.Height);
        }

        public Vector2 GetCollisionCenter(Rectangle collisionRectangle)
        {
            Rectangle CollisionRectangle = GetCollisionRectangle(collisionRectangle);
            return new Vector2((CollisionRectangle.Right + CollisionRectangle.Left) / 2, (CollisionRectangle.Bottom + CollisionRectangle.Top) / 2);
        }
    }
}
