using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using BlackDragonEngine.Entities;
using BlackDragonEngine.Components;
using BlackDragon.Providers;
using Microsoft.Xna.Framework;

namespace BlackDragon.Components.NPCs
{
    class MariaGraphicsComponent : AnimatedGraphicsComponent
    {       

        public MariaGraphicsComponent()
        {
            currentAnimation = "IdleDown";
            drawDepth = .86f;
            animations = AnimationDictionaryProvider.GetMariaAnimations();            
        }

        public override void Update(GameObject obj)
        {    
            if (receivedAnimation != currentAnimation)
            {
                PlayAnimation(receivedAnimation);
            }
            receivedAnimation = "";

            base.Update(obj);
        }
    }
}
