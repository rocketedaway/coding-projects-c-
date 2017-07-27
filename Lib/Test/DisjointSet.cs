using Xunit;
using System;
using System.Linq;
using DataStructures.DisjointSet;

namespace DataStructures.Test
{
    public class DisjointSet : UnitTest<UnionFind>
    {
        int numberOfNodes = 10;

        public DisjointSet()
        {
            implementations = new UnionFind[] {
                new QuickFind(numberOfNodes),
                new QuickUnion(numberOfNodes),
                new QuickUnionWeighted(numberOfNodes),
                new QuickUnionWeightedWithPathCompression(numberOfNodes)
            };
        }

        [Fact]
        void NumberOfNodes()
        {
            TestImplementations((implementation) => Assert.Equal(implementation.NumberOfNodes, numberOfNodes));
        }

        [Fact]
        void NumberOfComponents() 
        {
            PrepareImplementationsForTest((implementation) => {
                implementation.Union(2, 0);
                implementation.Union(3, 0);
                implementation.Union(9, 0);
                implementation.Union(5, 4);
                implementation.Union(6, 4);
                implementation.Union(7, 8);
            });

            TestImplementations((implementation) => {
                Assert.Equal(implementation.NumberOfComponents, 4);
            });
        }

        [Fact]
        void IsConnected()
        {
            int nodeToConnectTo = 9;
            int[] nodesToUnion = {0, 1, 2};
            int[] nodesInComponent = {0, 1, 2, 9};
            int[] nodesNotInComponent = Enumerable
                .Range(0, numberOfNodes)
                .Where(node => !nodesInComponent.Contains(node))
                .ToArray();

            PrepareImplementationsForTest((implementation) => {
                foreach(int node in nodesToUnion)
                {
                    implementation.Union(node, nodeToConnectTo);
                }
            });
            
            TestImplementations((implementation) => {
                foreach(int node in nodesInComponent)
                {
                    Assert.Equal(implementation.IsConnected(node, nodeToConnectTo), true);
                }

                foreach(int node in nodesNotInComponent) 
                {
                    Assert.Equal(implementation.IsConnected(node, nodeToConnectTo), false);
                }
            });
        }

        [Fact]
        void UnionAndFind()
        {
            int[][] components = {
                new int[]{0},
                new int[]{1},
                new int[]{7,3,9},
                new int[]{4,5,8},
                new int[]{6,2}
            };
            
            PrepareImplementationsForTest((implementation) => {
                int parentNode;
                foreach(int[] component in components)
                {
                    parentNode = component[0];
                    foreach(int node in component)
                    {
                        implementation.Union(node, parentNode);
                    }
                }
            });

            TestImplementations((implementation) => {
                foreach(int[] component in components)
                {
                    int componentId = component[0];
                    foreach(int node in implementation.Nodes)
                    {
                        if (component.Contains(node)) 
                        {
                            Assert.Equal(implementation.Find(node), componentId);    
                        }
                        else {
                            Assert.NotEqual(implementation.Find(node), componentId);    
                        }
                    }
                }
            });
        }

        [Fact]
        void FindThrowsBoundsException()
        {
            TestImplementations((implementation) => {
                Assert.Throws<System.ArgumentOutOfRangeException>(() => implementation.Find(-1));
                Assert.Throws<System.ArgumentOutOfRangeException>(() => implementation.Find(numberOfNodes));
            });
        }

        [Fact]
        void UnionThrowsBoundsException()
        {
            TestImplementations((implementation) => {
                Assert.Throws<System.ArgumentOutOfRangeException>(() => implementation.Union(-1, 8));
                Assert.Throws<System.ArgumentOutOfRangeException>(() => implementation.Union(0, numberOfNodes));
                Assert.Throws<System.ArgumentOutOfRangeException>(() => implementation.Union(-1, numberOfNodes));   
            });
        }

        [Fact]
        void IsConnectedThrowsBoundsException()
        {
            TestImplementations((implementation) => {
                Assert.Throws<System.ArgumentOutOfRangeException>(() => implementation.IsConnected(-1, 8));
                Assert.Throws<System.ArgumentOutOfRangeException>(() => implementation.IsConnected(0, numberOfNodes));
                Assert.Throws<System.ArgumentOutOfRangeException>(() => implementation.IsConnected(-1, numberOfNodes));   
            });
        }
    }
}
