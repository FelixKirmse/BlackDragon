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

        private InputComponent input;
        private PhysicsComponent physics;
        private GraphicsComponent graphics;
        private SoundComponent sound;

        private List<Component> components = new List<Component>();

        public GameObject(InputComponent input, PhysicsComponent physics, GraphicsComponent graphics)
        {
            this.input = input;
            this.physics = physics;
            this.graphics = graphics;

            components.Add(input);
            components.Add(physics);
            components.Add(graphics);
        }

        public GameObject(InputComponent input, PhysicsComponent physics, GraphicsComponent graphics, SoundComponent sound)
            : this(input, physics, graphics)
        {
            this.sound = sound;
            components.Add(sound);
        }

        public void Update(GameTime gameTime)
        {
            input.Update(this);
            physics.Update(this, gameTime);
            graphics.Update(this, gameTime);
            if(sound != null)
                sound.Update(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            graphics.Draw(this, spriteBatch);
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
