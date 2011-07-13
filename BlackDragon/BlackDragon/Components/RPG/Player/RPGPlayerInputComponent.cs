using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlackDragon.Components.RPG.Player
{
    class RPGPlayerInputComponent : InputComponent
    {
        public override void Update(GameObject obj)
        {
            
        }

        public override void Receive(string message)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "INPUT")
            {

            }
        }
    }
}
