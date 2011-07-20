using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using BlackDragon.Components.Platform.Player;
using BlackDragon.Components.RPG.Player;

namespace BlackDragon
{
    static class Factory
    {
        public static GameObject CreateRPGPlayer()
        {
            return new GameObject(
                new RPGPlayerInputComponent(),
                new RPGPlayerPhysicsComponent(),
                new RPGPlayerGraphicsComponent(),
                new RPGPlayerSoundComponent());
        }

        public static GameObject CreatePlatformPlayer()
        {
            return new GameObject(
                new PlatformPlayerInputComponent(),
                new PlatformPlayerPhysicsComponent(),
                new PlatformPlayerGraphicsComponent(),
                new PlatformPlayerSoundComponent());
        }

        public static GameObject CreateWorldPlayer()
        {
            return new GameObject(
                new WorldPlayerInputComponent(),
                new RPGPlayerPhysicsComponent(),
                new RPGPlayerGraphicsComponent());
        }
    }
}
