﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tile_Engine;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using BlackDragon.Helpers;

namespace BlackDragon.Components.NPCs
{
    class PartyMemberWaypointComponent : WaypointComponent
    {
        private GameObject objectToFollow;
        private string currentAnimation = "";

        public PartyMemberWaypointComponent()
        {
            speed = 1.4f;
            objectState = ObjectStates.IDLE;
        }

        public override void Update(GameObject obj, GameTime gameTime)
        {
            if (Vector2.Distance(objectToFollow.GetCollisionCenter(objectToFollow.PublicCollisionRectangle), obj.GetCollisionCenter(collisionRectangle)) >= 24)
            {
                base.Update(obj, gameTime);
            }
            else
            {
                objectState = ObjectStates.IDLE;
                determineIdleAnimation(obj);
            }
        }

        protected override void idleUpdate(Vector2 collisionCenter, GameObject obj)
        {
            int counter = 0;
            do
            {
                ++counter;
                if (counter == 5)
                {
                    //obj.Position = objectToFollow.Position;
                    return;
                }
                currentWaypoint = getNextWaypoint();
                currentPath = PathFinder.FindReducedPath(TileMap.GetCellByPixel(collisionCenter), currentWaypoint);                
            } while (currentPath == null);
            pathIndex = 0;
            currentGoal = currentPath[pathIndex];
            changeDirection(collisionCenter, obj);
            objectState = ObjectStates.WALKING;
        }

        protected void determineIdleAnimation(GameObject obj)
        {
            obj.Send("GRAPHICS_SEND_WAYPOINT_CURRENTANIMATION", obj);
            currentAnimation = currentAnimation.Replace("Walk", "Idle");
            obj.Send("GRAPHICS_PLAYANIMATION", currentAnimation);
        }

        protected override Vector2 getNextWaypoint()
        {
            return TileMap.GetCellByPixel(objectToFollow.GetCollisionCenter(objectToFollow.PublicCollisionRectangle));
        }

        public override void Receive<T>(string message, T obj)
        {
            string[] messageArray = message.Split('_');
            if (messageArray[0] == "WAYPOINT")
            {
                if (messageArray[1] == "FOLLOW")
                {
                    if (obj is GameObject)
                        objectToFollow = (GameObject)(object)obj;
                }

                if (messageArray[1] == "SET")
                {
                    if (messageArray[2] == "CURRENTANIMATION")
                    {
                        if (obj is string)
                            currentAnimation = (string)(object)obj;
                    }
                }
            }
            base.Receive<T>(message, obj);
        }
    }
}