using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;

namespace BlackDragon.Components.Platform.Player
{
    class PlatformPlayerInputComponent : InputComponent
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
