using GraphTheory.src.api;
using GraphTheory.src.component;

namespace GraphTheoryTest
{
    [TestClass]
    internal class AlgorithmTest
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
        public void NumberOfRoutes_A_F_Should_Return_3()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "F", 0, 1, 1);
            Assert.AreEqual("3", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_H_A_Should_Return_NO_SUCH_ROUTE()
        {
            string actual = algorithm.NumberOfRoutes(graph, "H", "A", 0, 0, 1);
            Assert.AreEqual("NO SUCH ROUTE", actual);

            string actual1 = algorithm.NumberOfRoutes(graph, "H", "A", 0, 1, 1);
            Assert.AreEqual("NO SUCH ROUTE", actual1);
        }

        [TestMethod]
        public void NumberOfRoutes_A_F_Should_Return_3()
        {
            string actual = algorithm.NumberOfRoutes(graph, "A", "F");
            Assert.AreEqual("3", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_H_A_Should_Return_NO_SUCH_ROUTE()
        {
            string actual = algorithm.NumberOfRoutes(graph, "H", "A");
            Assert.AreEqual("NO SUCH ROUTE", actual);
        }

        [TestMethod]
        public void NumberOfRoutes_H_A_Should_Return_NO_SUCH_ROUTE()
        {
            string actual = algorithm.NumberOfRoutes(graph, "H", "A");
            Assert.AreEqual("NO SUCH ROUTE", actual);
        }
        #endregion

        #region Test ShortesRoute
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ShortesRoute_A_F_Should_Return()
        {
            string actual = algorithm.ShortesRoute(graph, "A", "F");
            Assert.AreEqual("9", actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ShortesRoute_H_A_Should_Return_NO_SUCH_ROUTE()
        {
            string actual = algorithm.ShortesRoute(graph, "H", "A");
            Assert.AreEqual("NO SUCH ROUTE", actual);
        }
        #endregion
    }
}
