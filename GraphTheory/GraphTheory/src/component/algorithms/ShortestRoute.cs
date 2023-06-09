using GraphTheory.src.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.component.algorithms
{
    internal class ShortestRoute
    {
        /// <summary>
        /// Returns the shortestt distance of all possibleRoutes between a start and end point.
        /// </summary>
        /// <param name="possibleRoutes">A list of possible routes.</param>
        /// <returns name="distance">Shortestt distance of all possibleRoutes.</returns>
        public int ShortestDistance(List<List<Route>> possibleRoutes)
        {
            if (possibleRoutes.Count == 0)
            {
                return -1;
            }

            int distance = 0;
            int temp;

            foreach (List<Route> routes in possibleRoutes)
            {
                temp = CalculateDistance(routes);

                if (temp < distance || distance == 0)
                {
                    distance = temp;
                }
            }
            return distance;
        }

        /// <summary>
        /// Returns the sum of all distances from all routes.
        /// </summary>
        /// <param name="listOfRoutes">A list of routes from one point to another.</param>
        /// <returns name="distance">Sum of the distance from all routes.</returns>
        public int CalculateDistance(List<Route> listOfRoutes)
        {
            int distance = 0;

            foreach (Route route in listOfRoutes)
            {
                distance += route.Distance;
            }

            return distance;
        }
    }
}
