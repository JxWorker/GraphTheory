using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.api
{
    internal interface IGraphTheoryService
    {
        /// <summary>
        /// Returns the distance of a given route or "NO SUCH ROUTE" it it does not exist.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="route">A given route.</param>
        /// <returns>The distance of the route or "NO SUCH ROUTE" if the route does not exist.</returns>
        public string DistanceOfRoutes(Route[] graph, string[] route);

        /// <summary>
        /// Returns the number or routes under the given conditions or "NO SUCH ROUTE" if there does not exist a route with those conditions.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="start">The start point.</param>
        /// <param name="end">The end point.</param>
        /// <param name="numberOfStopps">The number of stops a route can have.</param>
        /// <param name="countType"></param>
        /// <param name="loopLimit">How many times the same route is allowed to show up.</param>
        /// <returns>The number of routes with the given conditions or "NO SUCH ROUTE" if there does not exist such a route.</returns>
        public string NumberOfRoutes(Route[] graph, string start, string end, int numberOfStopps, int countType, int loopLimit);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="start">The start point.</param>
        /// <param name="end">The end point.</param>
        /// <returns>The shortes distance between to points or "NO SUCH ROUTE" if the those points are not conected.</returns>
        public string ShortesRoute(Route[] graph, string start, string end);
    }
}
