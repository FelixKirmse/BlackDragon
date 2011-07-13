using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace BlackDragon.Components
{
    abstract class SoundComponent : Component
    {
        public abstract void Update(GameObject obj);
        public abstract override void Receive(string message);
    }
}
