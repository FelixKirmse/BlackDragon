using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Entities;
using BlackDragon.Providers;
using Microsoft.Xna.Framework.Graphics;

namespace BlackDragon.Managers
{
    static class EntityManager
    {
        private static GameObject player;
        private static List<GameObject> partyMembers = new List<GameObject>();
        private static List<GameObject> entities = new List<GameObject>();

        public static void Update()
        {
            foreach (GameObject entity in entities)
            {
                entity.Update();
            }
            player.Update();
            CodeManager.CheckPlayerCodes();
            checkPartyMemberDistances();
            foreach (GameObject partyMember in partyMembers)
            {
                partyMember.Update();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject entity in entities)
            {
                entity.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
        }

        public static void SetPlayer()
        {
            player = VariableProvider.CurrentPlayer;
        }

        public static void AddEntity(GameObject entity)
        {
            entities.Add(entity);
        }

        public static void ClearEntities()
        {
            entities.Clear();
        }

        private static void checkPartyMemberDistances()
        { 
            
        }
    }
}
