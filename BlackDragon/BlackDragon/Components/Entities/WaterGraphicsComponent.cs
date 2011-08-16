using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Providers;
using BlackDragonEngine.Components;

namespace BlackDragon.Components.Entities
{
    class WaterGraphicsComponent : AnimatedGraphicsComponent
    {
        public WaterGraphicsComponent()
        {
            animations = AnimationDictionaryProvider.GetWaterAnimations();
            currentAnimation = "Idle";
            PlayAnimation(currentAnimation);
        }
    }
}
