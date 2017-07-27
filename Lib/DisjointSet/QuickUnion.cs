using System;

namespace DataStructures.DisjointSet
{
    public class QuickUnion : UnionFind
    {
        public QuickUnion(int numberOfNodes) : base(numberOfNodes) {}

        public override int Find(int node)
        {
            throw new NotImplementedException();
        }

        public override int Union(int nodeA, int nodeB)
        {
            throw new NotImplementedException();
        }
    }
}
