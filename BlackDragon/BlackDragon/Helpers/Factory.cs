using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragonEngine.Entities;
using BlackDragon.Components.Platform.Player;
using BlackDragon.Components.RPG.Player;
using BlackDragon.Components.NPCs;
using BlackDragonEngine.Components;
using BlackDragon.Components.Entities;


namespace BlackDragon
{
    static class Factory
    {
        public static GameObject CreateRPGPlayer()
        {
            List<Component> components = new List<Component>();
            components.Add(new RPGPlayerPhysicsComponent());
            components.Add(new RPGPlayerGraphicsComponent());
            components.Add(new RPGPlayerInputComponent());            
            return new GameObject(components);
        }

        public static GameObject CreatePlatformPlayer()
        {
            List<Component> components = new List<Component>();
            components.Add(new PlatformPlayerPhysicsComponent());
            components.Add(new PlatformPlayerGraphicsComponent());
            components.Add(new PlatformPlayerInputComponent());
            return new GameObject(components);
        }

        public static GameObject CreateMaria()
        {
            List<Component> components = new List<Component>();
            components.Add(new MariaGraphicsComponent());
            components.Add(new MariaWaypointComponent());
            return new GameObject(components);
        }

        public static GameObject CreateWater()
        {
            List<Component> components = new List<Component>();
            components.Add(new WaterGraphicsComponent());
            return new GameObject(components);
        }

        public static GameObject CreatePartyMember()
        {
            List<Component> components = new List<Component>();
            components.Add(new MariaGraphicsComponent());
            components.Add(new PartyMemberWaypointComponent());
            return new GameObject(components);
        }
    }
}
