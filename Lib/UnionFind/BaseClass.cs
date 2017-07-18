using System;

namespace DataStructures.UnionFind
{   
    abstract public class BaseClass
    {
        public int[] Components { get; private set; }
        public int NumberOfNodes { get; private set; }

        public int NumberOfComponents 
        {
            get 
            {
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

        protected BaseClass(int numberOfNodes) 
        {
            NumberOfNodes =  numberOfNodes;
            Components = new int[numberOfNodes];
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
                throw new System.ArgumentException("The supplied node (" + node + ") is out of rage", "node");
            }
        }
    }
}
