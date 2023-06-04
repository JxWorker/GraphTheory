using GraphTheory.src.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.component.algorithms
{
    internal class SearchForRoutes
    {
        private List<Route> nextPossibleRoute = new List<Route>();
        private List<List<Route>> listOfPosssibleRoutes = new List<List<Route>>();

        /// <summary>
        /// Returns a list of different routes between the start and end point.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="start">The start point of the routes.</param>
        /// <param name="end">The end point of the routes.</param>
        /// <param name="loopLimit">How many times a route is allowed to repeat.</param>
        /// <returns>A list of different routes between the start and end point.</returns>
        public List<List<Route>> SearchForRoute(Route[] graph, string start, string end, int loopLimit)
        {
            try
            {
                nextPossibleRoute = new List<Route>();
                listOfPosssibleRoutes = new List<List<Route>>();
                int count = NumberOfPossibleRoutes(graph, start);
                Route[] routes = GetAllRoutes(graph, count, start);
                for (int i = 0; i < count; i++)
                {
                    nextPossibleRoute.Add(routes[i]);
                    SearchForAllRoutes(graph, routes[i].End, end, NumberOfPossibleRoutes(graph, routes[i].End), loopLimit);
                    //listOfPosssibleRoutes.Add(nextPossibleRoute);
                    nextPossibleRoute = new List<Route>();
                }
                //RemoveRoute(end);
                return listOfPosssibleRoutes;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return listOfPosssibleRoutes;
            }

        }

        /// <summary>
        /// Searches for all routes starting from the start point until the end point or an already crossed point.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="start">The start point of the routes.</param>
        /// <param name="count">The number of routes which start from the start point.</param>
        /// <param name="loopLimit">How many times a route is allowed to repeat.</param>
        private void SearchForAllRoutes(Route[] graph, string start, string end, int count, int loopLimit)
        {
            try
            {
                Route[] routes = GetAllRoutes(graph, count, start);
                List<List<Route>> temp = new List<List<Route>>();
                temp.Add(new List<Route>(nextPossibleRoute));
                for (int i = 0; i < count; i++)
                {
                    if (loopLimit > LoopCount(routes[i]))
                    {
                        nextPossibleRoute.Add(routes[i]);

                        if (routes[i].End != end)
                        {
                            SearchForAllRoutes(graph, routes[i].End, end, NumberOfPossibleRoutes(graph, routes[i].End), loopLimit);
                        }
                    }
                    if(routes[i].End == end)
                    {
                        listOfPosssibleRoutes.Add(new List<Route>(nextPossibleRoute));
                    }
                    nextPossibleRoute = temp.Last();
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Returns the number of routes starting from the start point.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="start">The start point of the routes.</param>
        /// <returns>The number of routes which start from the start point.</returns>
        private int NumberOfPossibleRoutes(Route[] graph, string start)
        {
            int count = 0;
            foreach (Route route in graph)
            {
                if (route.Start == start)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns all routes which are start from the start point.
        /// </summary>
        /// <param name="graph">All the routes which create a graph.</param>
        /// <param name="count">The number of routes form the start point.</param>
        /// <param name="start">The start point of the routes.</param>
        /// <returns>All routes which start form the start point.</returns>
        private Route[] GetAllRoutes(Route[] graph, int count, string start)
        {
            try
            {
                Route[] routes = new Route[count];
                for (int i = 0; i < graph.Length && count != 0; i++)
                {
                    if (graph[i].Start.Equals(start))
                    {
                        routes[--count] = graph[i];
                    }
                }
                return routes;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return Array.Empty<Route>();
            }
        }

        /// <summary>
        /// Removes all routes which do not stop at the end point.
        /// </summary>
        /// <param name="end">The point were the route should end.</param>
        private void RemoveRoute(string end)
        {
            foreach (List<Route> route in listOfPosssibleRoutes)
            {
                if (route.Last().End != end)
                {
                    listOfPosssibleRoutes.Remove(route);
                }
            }
        }

        /// <summary>
        /// Returns how many times a route exist in nextPossibleRoute.
        /// </summary>
        /// <param name="route">The route to count.</param>
        /// <returns>How many times this route exist in nextPossibleRoute.</returns>
        private int LoopCount(Route route)
        {
            int count = 0;
            foreach (Route route1 in nextPossibleRoute)
            {
                if (route.Comparer(route1))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
