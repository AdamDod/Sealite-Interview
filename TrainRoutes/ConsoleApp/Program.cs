using ConsoleApp.Models.Graph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var adjMatrixGraph = new Graph(5);
            try
            {
                // create blank matrix


                // add edges to matrix 
                adjMatrixGraph.AddEdge(0, 1, 5);
                adjMatrixGraph.AddEdge(1, 2, 4);
                adjMatrixGraph.AddEdge(2, 3, 8);
                adjMatrixGraph.AddEdge(3, 2, 8);
                adjMatrixGraph.AddEdge(3, 4, 6);
                adjMatrixGraph.AddEdge(0, 3, 5);
                adjMatrixGraph.AddEdge(2, 4, 2);
                adjMatrixGraph.AddEdge(4, 1, 3);
                adjMatrixGraph.AddEdge(0, 4, 7);

                int[] route1 = { 0, 1, 2 };
                Console.Write("A=>B=>C is ");
                Console.WriteLine(adjMatrixGraph.FindLengthOfRoute(route1));

                int[] route2 = { 0, 3 };
                Console.Write("A=>D is ");
                Console.WriteLine(adjMatrixGraph.FindLengthOfRoute(route2));

                int[] route3 = { 0, 3, 2 };
                Console.Write("A=>D=>C is ");
                Console.WriteLine(adjMatrixGraph.FindLengthOfRoute(route3));

                int[] route4 = { 0, 4, 1, 2, 3 };
                Console.Write("A=>E=>B=>C=>D is ");
                Console.WriteLine(adjMatrixGraph.FindLengthOfRoute(route4));

                int[] route_NotFound = { 1, 4, 3 };
                Console.Write("A=>E=>D is ");
                Console.WriteLine(adjMatrixGraph.FindLengthOfRoute(route_NotFound));

                Console.WriteLine("C=>C with max 3 stops");
                Console.WriteLine("# of possible routes = " + adjMatrixGraph.FindAllPathsDepth(2, 2, 0, 3).Count());

                Console.WriteLine("A=>C with exactly 4 stops");
                Console.WriteLine("# of possible routes = " + adjMatrixGraph.FindAllPathsDepth(0, 2, 4, 4).Count());


                Console.WriteLine("Shortest route between A and C");
                Console.WriteLine("Length of route =  " + adjMatrixGraph.FindShortestPath(0, 2));

                Console.WriteLine("Shortest route between B and B");
                Console.WriteLine("Length of route = " + adjMatrixGraph.FindShortestPath(1, 1));

                Console.WriteLine("Shortest route between B and B");
                Console.WriteLine("Length of route = " + adjMatrixGraph.FindShortestPath(1, 1));

                Console.WriteLine("Find routes between C and C with distance less than 30");
                Console.WriteLine("# of routes " + adjMatrixGraph.FindAllPathsWeight(2, 2, 0,30).Count());

            }
            catch (Exception e) 
                {
                    Console.WriteLine();
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.ReadLine();
                }

        }
    }
}
