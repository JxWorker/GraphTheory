using GraphTheory.src.api;
using GraphTheory.src.component;

namespace GraphTheoryTest
{
    [TestClass]
    public class AlgorithmTest
    {
        Algorithm algorithm = new Algorithm();
        Route[] graph = { new Route("A", "B", 2), new Route("B", "C", 1), new Route("B", "E", 3),
            new Route("C", "G", 3), new Route("G", "F", 7), new Route("F", "G", 7), new Route("E", "F", 4),
            new Route("E", "H", 9), new Route("E", "D", 7), new Route("D", "A", 5), new Route("H", "F", 6) };

        #region Test DisteanceOfRoutes
        [TestMethod]
        public void DistanceOfRoutes_A_B_E_F_G_Should_Return_16()
        {
            string[] route = { "A", "B", "E", "F", "G" };
            string actual = algorithm.DistanceOfRoutes(graph, route);
            Assert.AreEqual("16", actual);
        }

        [TestMethod]
        public void DistanceOfRoutes_A_B_C_G_F_E_Should_Return_NO_SUCH_ROUTE()
        {
            string[] route = { "A", "B", "C", "G", "F", "E" };
            string actual = algorithm.DistanceOfRoutes(graph, route);
            Assert.AreEqual("NO SUCH ROUTE", actual);
        }
        #endregion

        #region Test NumberOfRoutes
        [TestMethod]
        public void NumberOfRoutes_CountType1_A_F_Should_Return_3()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "F", 1, 1, 0, 0);
            Assert.AreEqual("3", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_H_A_Should_Return_NO_SUCH_ROUTE()
        {
            string actual = algorithm.NumberOfRoutes(graph, "H", "A", 1, 1, 0, 0);
            Assert.AreEqual("NO SUCH ROUTE", actual);

            string actual1 = algorithm.NumberOfRoutes(graph, "H", "A", 0, 1, 0, 0);
            Assert.AreEqual("NO SUCH ROUTE", actual1);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType2_A_F_Should_Return_1()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "F", 2, 5, 2, 0);
            Assert.AreEqual("1", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType3_A_F_Should_Return_3()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "F", 3, 5, 4, 0);
            Assert.AreEqual("3", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType4_A_F_Should_Return_3()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "F", 4, 1, 2, 0);
            Assert.AreEqual("3", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType5_A_F_Should_Return_1()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "F", 5, 1, 0, 9);
            Assert.AreEqual("1", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType6_A_F_Should_Return_3()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "F", 6, 1, 0, 20);
            Assert.AreEqual("3", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_CountType7_A_F_Should_Return_2()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "F", 7, 1, 0, 11);
            Assert.AreEqual("2", actual);
        }
        #endregion

        #region Test ShortesRoute
        [TestMethod]
        public void ShortesRoute_A_F_Should_Return()
        {
            string actual = algorithm.ShortesRoute(graph, "A", "F");
            Assert.AreEqual("9", actual);
        }

        [TestMethod]
        public void ShortesRoute_H_A_Should_Return_NO_SUCH_ROUTE()
        {
            string actual = algorithm.ShortesRoute(graph, "H", "A");
            Assert.AreEqual("NO SUCH ROUTE", actual);
        }
        #endregion
    }
}
