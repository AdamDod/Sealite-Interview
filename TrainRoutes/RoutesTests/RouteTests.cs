using ConsoleApp.Models.Graph;

namespace RoutesTests
{
    public class RoutesTests
    {
        [Theory]
        [InlineData(new int[]{ 0, 1, 2 },9)]
        [InlineData(new int[] { 0, 3 }, 5)]
        [InlineData(new int[] { 0, 3, 2 }, 13)]
        [InlineData(new int[] { 0, 4, 1, 2, 3 }, 22)]
        public void Distance(int[] route,int expected)
        {
            Graph graph = CreateGraph();

            Assert.Equal(expected, graph.FindLengthOfRoute(route));
        }

        [Theory]
        [InlineData(new int[] { 0, 4, 3 }, 22)]
        public void DistanceFailed(int[] route, int expected)
        {
            Graph graph = CreateGraph();

            Assert.Throws<ArgumentException>(() => graph.FindLengthOfRoute(route));
        }

        [Theory]
        [InlineData(2, 2, 0, 3, 2)]
        [InlineData(0, 2, 4, 4, 3)]
        public void TripNumber(int start, int end, int minDepth, int maxDepth,int expected)
        {
            Graph graph = CreateGraph();

            Assert.Equal(expected, graph.FindAllPathsDepth(start, end, minDepth, maxDepth).Count());
        }

        [Theory]
        [InlineData(0, 2, 9)]
        [InlineData(1, 1, 9)]
        public void ShortestTrip(int start, int end, int expected)
        {
            Graph graph = CreateGraph();

            Assert.Equal(expected, graph.FindShortestPath(start, end));
        }

        public Graph CreateGraph()
        {
            var adjMatrixGraph = new Graph(5);

            adjMatrixGraph.AddEdge(0, 1, 5);
            adjMatrixGraph.AddEdge(1, 2, 4);
            adjMatrixGraph.AddEdge(2, 3, 8);
            adjMatrixGraph.AddEdge(3, 2, 8);
            adjMatrixGraph.AddEdge(3, 4, 6);
            adjMatrixGraph.AddEdge(0, 3, 5);
            adjMatrixGraph.AddEdge(2, 4, 2);
            adjMatrixGraph.AddEdge(4, 1, 3);
            adjMatrixGraph.AddEdge(0, 4, 7);

            return adjMatrixGraph;
        }
    }
}