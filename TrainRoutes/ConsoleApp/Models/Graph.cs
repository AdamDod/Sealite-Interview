using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp.Models.Graph
{
    public class Graph 
    {
        public int[,] Matrix;
        protected readonly int NumVert;
        public Graph(int numVertices)
        {
            NumVert = numVertices;
            GenerateEmptyMatrix(numVertices);
        }
        public void AddEdge(int v1, int v2, int weight = 1)
        {
            Matrix[v1, v2] = weight;
        }

        private void GenerateEmptyMatrix(int numVertices)
        {
            Matrix = new int[numVertices, numVertices];
            for (int row = 0; row < numVertices - 1; row++)   
            {
                for (int col = 0; col < numVertices - 1; col++)
                {
                    Matrix[row, col] = 0;
                }
            }
        }
        public List<int> GetAdjacentVertices(int v)
        {
            if (v < 0 || v >= NumVert) throw new ArgumentOutOfRangeException("Cannot access vertex");

            List<int> adjacentVertices = new List<int>();
            for (int i = 0; i < NumVert; i++)
            {
                if (Matrix[v, i] > 0)
                    adjacentVertices.Add(i);
            }
            return adjacentVertices;
        }

        public int GetEdgeWeight(int v1, int v2)
        {
            int weight = Matrix[v1, v2];
            if (weight == 0)
            {
                throw new ArgumentException("Route not found");
            }
            return weight;
        }

        public int FindLengthOfRoute(int[] route)
        {
            int length = 0;
            for (int i = 0; i < route.Count(); i++)
            {
                if (route.Count() > i+1)
                {
                    length += GetEdgeWeight(route[i], route[i+1]);
                }
                
            }
            return length;
        }

        public int FindNumberOfStops(int from, int to, int maxStop)
        {

            return 0;
        }

        public List<List<int>> FindAllPathsDepth(int source, int finish, int minDepth,int maxDepth)
        {
            List<List<int>> paths = new List<List<int>>();
            List<int> pathList = new List<int>();
            pathList.Add(source);

            var x = FindAllPathsDepthUtil(source,finish,pathList,true,minDepth,maxDepth,0);


            return x;
        }

        private List<List<int>> FindAllPathsDepthUtil(int source, int finish, List<int>localPathList,bool initial, int minDepth,int maxDepth, int depth)
        {
            List<List<int>> allPaths = new List<List<int>>();
            if (depth > maxDepth)
            {
                return allPaths;
            }

            if (source.Equals(finish) && !initial)
            {
                if (depth >= minDepth)
                {
                    //Console.WriteLine(string.Join(" ", localPathList));
                    allPaths.Add(new List<int>(localPathList));
                    return allPaths;
                }          
                
            }

            List<int> adjVerts = GetAdjacentVertices(source);

            foreach (var i in adjVerts)
            {
                localPathList.Add(i);
                depth++;
                allPaths.AddRange(FindAllPathsDepthUtil(i, finish, localPathList, false, minDepth, maxDepth, depth));                
                depth--;
                localPathList.Remove(i);

            }
            return allPaths;
        }

        public int FindShortestPath(int source, int finish)
        {
            List<List<int>> paths = new List<List<int>>();
            List<int> pathList = new List<int>();
            pathList.Add(source);
            var visited = new HashSet<int> { source };

            var x = FindShortestPathsUtil(source, finish, pathList,visited, true,0);


            return x.Item2;
        }

        private Tuple<List<int>, int> FindShortestPathsUtil(int source, int finish, List<int> localPathList, HashSet<int> visited, bool initial, int currentWeight)
        {
            List<int> shortestPath = new List<int>();
            int minPathWeight = int.MaxValue;

            if (source.Equals(finish) && !initial)
            {
                // Add a copy of the current path to the list of all paths
                if (currentWeight < minPathWeight) 
                {
                    minPathWeight = currentWeight;
                    shortestPath = new List<int>(localPathList);                    
                }
                return new Tuple<List<int>, int>(shortestPath, minPathWeight);
            }

            List<int> adjVerts = GetAdjacentVertices(source);

            foreach (var i in adjVerts)
            {

                // make sure that we do not return to an already visited node 
                if (visited.Contains(i) && i != finish)
                {
                    continue; // Skip if the node is already visited
                }

                int edgeWeight = GetEdgeWeight(source, i); // Assume this function returns the weight of the edge

                localPathList.Add(i);
                currentWeight += edgeWeight;
                visited.Add(i);
                // Recursively find all paths and add them to allPaths
                var result = FindShortestPathsUtil(i, finish, localPathList,visited, false, currentWeight);
                if (result != null && result.Item2 < minPathWeight)
                {
                    minPathWeight = result.Item2;
                    shortestPath = new List<int>(result.Item1);
                }
                currentWeight -= edgeWeight;
                localPathList.Remove(i);
                visited.Remove(i);

            }
            return new Tuple<List<int>, int>(shortestPath, minPathWeight);
        }

        public List<List<int>> FindAllPathsWeight(int source, int finish, int minWeight, int maxWeight)
        {
            List<List<int>> paths = new List<List<int>>();
            List<int> pathList = new List<int>();
            pathList.Add(source);

            var x = FindAllPathsWeightUtil(source, finish, pathList, true, minWeight, maxWeight, 0);


            return x;
        }


        //Not complete, this function needs to itterate back over nodes that lead to a path to find another path
        private List<List<int>> FindAllPathsWeightUtil(int source, int finish, List<int> localPathList, bool initial, int minWeight, int maxWeight, int currentWeight)
        {
            List<List<int>> allPaths = new List<List<int>>();
            if (currentWeight > maxWeight)
            {
                return allPaths;
            }

            if (source.Equals(finish) && !initial)
            {
                if (currentWeight >= minWeight)
                {
                    //Console.WriteLine(string.Join(" ", localPathList));
                    allPaths.Add(new List<int>(localPathList));
                    return allPaths;
                }

            }

            List<int> adjVerts = GetAdjacentVertices(source);

            foreach (var i in adjVerts)
            {
                int edgeWeight = GetEdgeWeight(source, i);

                localPathList.Add(i);
                currentWeight += edgeWeight;
                allPaths.AddRange(FindAllPathsWeightUtil(i, finish, localPathList, false, minWeight, maxWeight, currentWeight));
                currentWeight -= edgeWeight;
                localPathList.Remove(i);

            }
            return allPaths;
        }


    }

}
