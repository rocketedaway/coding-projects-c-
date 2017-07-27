namespace DataStructures.DisjointSet
{
    interface IUnionFind
    {
        int[] Nodes { get; } 
        int[] Components { get; }
        int NumberOfNodes { get; }
        int NumberOfComponents { get; }
        
        int Find(int node);
        int Union(int nodeA, int nodeB);
        bool IsConnected(int nodeA, int nodeB);
    }
}
