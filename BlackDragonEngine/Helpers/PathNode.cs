﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragonEngine.Providers;
using BlackDragonEngine.HelpMaps;

namespace BlackDragonEngine.Helpers
{
    public class PathNode
    {
        #region Declarations
        public PathNode ParentNode;
        public PathNode EndNode;
        private Vector2 gridLocation;
        public float TotalCost;
        public float DirectCost;
        #endregion

        #region Properties
        public Vector2 GridLocation {
            get { return gridLocation; }
            set { gridLocation = new Vector2((float)MathHelper.Clamp(value.X, 0f, (float)TileMap.MapWidth), (float)MathHelper.Clamp(value.Y, 0f, (float)TileMap.MapHeight)); }
        }

        public int GridX {
            get { return (int)gridLocation.X; }
        }

        public int GridY {
            get { return (int)gridLocation.Y; }
        }
        #endregion

        #region Constructor
        public PathNode(PathNode parentNode, PathNode endNode, Vector2 gridLocation, float cost) {
            ParentNode = parentNode;
            GridLocation = gridLocation;
            EndNode = endNode;
            DirectCost = cost;
            if (!(endNode == null)) {
                TotalCost = DirectCost + LinearCost();
            }
        }
        #endregion

        #region Helper Methods
        public float LinearCost() {            
            return (1 + 1/1000) * (Math.Abs(this.GridX - EndNode.GridX) + Math.Abs(this.GridY - EndNode.GridY));            
        }
        #endregion

        #region Public Methods
        public bool IsEqualToNode(PathNode node) {
            return GridLocation == node.GridLocation;
        }
        #endregion
    }
}
