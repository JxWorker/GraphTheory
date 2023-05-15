using GraphTheory.src.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.component.algorithms
{
    internal class DistanceOfRoutes
    {
        /// <summary>
        /// Returns the distance if the route exist and -1 if it does not exist.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="route">A given route.</param>
        /// <returns>The distance of a route or that this route does not exist.</returns>
        public int CalculateDistance(Route[] graph, string[] route)
        {
            int distance = 0;

            for (int i = 0; i < route.Length - 1; i++)
            {
                int index = SearchForRoute(graph, route[i], route[i + 1]);

                if (index == -1)
                {
                    return -1;
                }

                distance += index;
            }
            return distance;
        }

        /// <summary>
        /// Returns the distance if there is a route between two points and -1 if there does not exist a route between two points.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="start">The starting point.</param>
        /// <param name="end">The ending point.</param>
        /// <returns>The distance between two points or that no route exist between two points.</returns>
        private int SearchForRoute(Route[] graph, string start, string end)
        {
            try
            {
                for (int i = 0; i < graph.Length; i++)
                {
                    if (graph[i].Start.Equals(start) && graph[i].End.Equals(end))
                    {
                        return graph[i].Distance;
                    }
                }
                return -1;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}
