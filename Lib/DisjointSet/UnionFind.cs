using System;
using System.Linq;

namespace DataStructures.DisjointSet
{   
    abstract public class UnionFind : IUnionFind
    {
        public int[] Nodes { get; private set; } 
        public int[] Components { get; private set; }

        public int NumberOfNodes
        {
            get 
            {
                return Nodes.Length;
            }
        }

        public int NumberOfComponents 
        {
            get 
            {
                // @TODO: Currently this is O(n) so it can be improved if nessisary
                int numberOfComponents = 0;
                for (int i = 0; i < Components.Length; i++)
                {
                    if (i == Components[i]) 
                    {
                        numberOfComponents++;
                    }
                }
                
                return numberOfComponents;
            }
        }

        protected UnionFind(int numberOfNodes) {
            Nodes = Enumerable.Range(0, numberOfNodes).ToArray();
            Components = Enumerable.Range(0, numberOfNodes).ToArray();
        }

        public bool IsConnected(int nodeA, int nodeB)
        {
            return Find(nodeA) == Find(nodeB);
        }

        virtual public int Find(int node) 
        {
            EnsureNodeIsInBounds(node);
            return -1;
        }
        virtual public int Union(int nodeA, int nodeB)
        {
            EnsureNodeIsInBounds(nodeA);
            EnsureNodeIsInBounds(nodeB);
            return -1;
        }

        protected void EnsureNodeIsInBounds(int node) {
            bool nodeIsInBounds = node >= 0 && node < NumberOfNodes;
            if (!nodeIsInBounds)
            {
                throw new System.ArgumentOutOfRangeException("The supplied node (" + node + ") is out of rage", "node");
            }
        }
    }
}
