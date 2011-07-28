using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tile_Engine;
using Microsoft.Xna.Framework;
using BlackDragon.Providers;

namespace BlackDragon.Helpers
{
    class PathNode
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
            float diagonal = MathHelper.Min(Math.Abs(this.GridX - EndNode.GridX), Math.Abs(this.GridY - EndNode.GridY));
            float straight = Math.Abs(this.GridX - EndNode.GridX) + Math.Abs(this.GridY - EndNode.GridY);
            if (InputMapper.ACTION)
                return (float)Math.Sqrt(Math.Pow((this.GridX - EndNode.GridX) + (this.GridY - EndNode.GridY),2));
            if(InputMapper.JUMP)
                return Math.Abs(this.GridX - EndNode.GridX) + Math.Abs(this.GridY - EndNode.GridY);
            return (1 + 1/1000)*(PathFinder.CostDiagonal * diagonal + PathFinder.CostStraight * (straight - 2*diagonal));
        }
        #endregion

        #region Public Methods
        public bool IsEqualToNode(PathNode node) {
            return GridLocation == node.GridLocation;
        }
        #endregion
    }
}
