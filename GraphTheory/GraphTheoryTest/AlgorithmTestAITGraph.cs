using GraphTheory.src.api;
using GraphTheory.src.component;

namespace GraphTheoryTest
{
    [TestClass]
    public class AlgorithmTestAITGraph
    {
        Algorithm algorithm = new Algorithm();
        Route[] graph = { new Route("A", "B", 5), new Route("B", "C", 4), new Route("C", "D", 8),
            new Route("D", "C", 8), new Route("D", "E", 6), new Route("A", "D", 5), new Route("C", "E", 2),
            new Route("E", "B", 3), new Route("A", "E", 7) };

        #region Test DisteanceOfRoutes
        [TestMethod]
        public void DistanceOfRoutes_A_D_C_Should_Return_13()
        {
            string[] route = { "A", "D", "C" };
            string actual = algorithm.DistanceOfRoutes(graph, route);
            Assert.AreEqual("13", actual);
        }

        [TestMethod]
        public void DistanceOfRoutes_A_E_D_Should_Return_NO_SUCH_ROUTE()
        {
            string[] route = { "A", "E", "D" };
            string actual = algorithm.DistanceOfRoutes(graph, route);
            Assert.AreEqual("NO SUCH ROUTE", actual);
        }
        #endregion

        #region Test NumberOfRoutes
        [TestMethod]
        public void NumberOfRoutes_H_A_Should_Return_NO_SUCH_ROUTE()
        {
            string actual = algorithm.NumberOfRoutes(graph, "H", "A", 0, 1, 0, 0);
            Assert.AreEqual("NO SUCH ROUTE", actual);

            string actual1 = algorithm.NumberOfRoutes(graph, "H", "A", 1, 1, 0, 0);
            Assert.AreEqual("NO SUCH ROUTE", actual1);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType1_A_E_Should_Return_14()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "E", 1, 1, 0, 0);
            Assert.AreEqual("14", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType2_A_C_Should_Return_3()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "C", 2, 5, 4, 0);
            Assert.AreEqual("3", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType3_C_C_Should_Return_2()
        {
            string actual = algorithm.NumberOfRoutes(graph, "C", "C", 3, 2, 3, 0);
            Assert.AreEqual("2", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType4_A_E_Should_Return_5()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "E", 4, 1, 3, 0);
            Assert.AreEqual("12", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType5_A_E_Should_Return_1()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "E", 5, 1, 0, 7);
            Assert.AreEqual("1", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType6_C_C_Should_Return_7()
        {
            string actual = algorithm.NumberOfRoutes(graph, "C", "C", 6, 3, 0, 30);
            Assert.AreEqual("7", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType7_A_E_Should_Return_4()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "E", 7, 1, 0, 11);
            Assert.AreEqual("11", actual);
        }
        #endregion

        #region Test ShortestRoute
        [TestMethod]
        public void ShortestRoute_A_C_Should_Return_9()
        {
            string actual = algorithm.ShortestRoute(graph, "A", "C");
            Assert.AreEqual("9", actual);
        }

        [TestMethod]
        public void ShortestRoute_E_A_Should_Return_NO_SUCH_ROUTE()
        {
            string actual = algorithm.ShortestRoute(graph, "E", "A");
            Assert.AreEqual("NO SUCH ROUTE", actual);
        }
        #endregion

        #region ExistInGraph
        [TestMethod]
        public void ExistInGraph_D_Should_Return_True()
        {
            bool actual = algorithm.ExistInGraph(graph, "D");
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ExistInGraph_Z_Should_Return_False()
        {
            bool actual = algorithm.ExistInGraph(graph, "Z");
            Assert.AreEqual(false, actual);
        }
        #endregion
    }
}
