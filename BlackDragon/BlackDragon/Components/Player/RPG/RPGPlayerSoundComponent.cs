using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragonEngine.Entities;
using BlackDragonEngine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace BlackDragon.Components.RPG.Player
{
    class RPGPlayerSoundComponent : SoundComponent
    {
        public override void Update(GameObject obj)
        {
            
        }

        public override void Receive<T>(string message, T desiredPosition)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "SOUND")
            {

            }
        }
    }
}
