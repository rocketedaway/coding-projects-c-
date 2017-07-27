using System;

namespace DataStructures.DisjointSet
{
    public class QuickFind : UnionFind
    {
        public QuickFind(int numberOfNodes) : base(numberOfNodes) {}

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
