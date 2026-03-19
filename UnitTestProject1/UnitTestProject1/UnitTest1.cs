using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void TestDijkstraSimpleGraph()
        {
           
            double[,] simpleGraph = new double[,]
            {
                {0, 1, 4},
                {1, 0, 2},
                {4, 2, 0}
            };

          
            double[] shortestDistances = Graph.Dijkstra(simpleGraph, 0);

            
            double[] expectedDistances = new double[] { 0, 1, 3 };

           
            CollectionAssert.AreEqual(expectedDistances, shortestDistances);
        }
    }
}