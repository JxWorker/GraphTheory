using GraphTheory.src.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.component.algorithms
{
    internal class ShortesRoute
    {
        private List<Route> nextPossibleRoute = new();
        private List<List<Route>> possibleRoutes = new();

        /// <summary>
        /// Returns the shortest distance between the start and end point.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="start">The start point.</param>
        /// <param name="end">The end point.</param>
        /// <returns>The shortes distance between a staring and an ending point.</returns>
        public int DistanceOfRoute(Route[] graph, string start, string end)
        {
            nextPossibleRoute = new();
            possibleRoutes = new();

            SearchForAllRoutes(graph, start);
            RemoveWrongRoutes(end);

            return ShortestDistance();
        }

        /// <summary>
        /// Searches for all possible routes from a starting point.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="start">The starting point of the route.</param>
        private void SearchForAllRoutes(Route[] graph, string start)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                if (graph[i].Start.Equals(start))
                {
                    possibleRoutes.Add(AddPossibleRoutes(graph, graph[i]));
                    nextPossibleRoute = new List<Route>();
                }
            }
        }

        /// <summary>
        /// Returns a list possible routes from a start point until an already visited point or an end point.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="route">A route which will be followed.</param>
        /// <returns name="nextPossibleRoute">The route from a start point to an end point or until an already visited point.</returns>
        private List<Route> AddPossibleRoutes(Route[] graph, Route route)
        {
            if (nextPossibleRoute.Count == 0 || (nextPossibleRoute.Last().End == route.Start && !nextPossibleRoute.Contains(route)))
            {
                nextPossibleRoute.Add(route);
                SearchForAllRoutes(graph, route.End);
            }
            return nextPossibleRoute;
        }

        /// <summary>
        /// Removes all routes from possibleRoutes which do not end at the right point.
        /// </summary>
        /// <param name="end">The Point were a route should end.</param>
        private void RemoveWrongRoutes(string end)
        {
            foreach (List<Route> routes in possibleRoutes)
            {
                if (routes.Last().End != end)
                {
                    possibleRoutes.Remove(routes);
                }
            }
        }

        /// <summary>
        /// Returns the shortest distance of all possibleRoutes between a start and end point.
        /// </summary>
        /// <returns name="distance">Shortest distance of all possibleRoutes.</returns>
        private int ShortestDistance()
        {
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
        private int CalculateDistance(List<Route> listOfRoutes)
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
