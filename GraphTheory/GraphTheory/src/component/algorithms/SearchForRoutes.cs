using GraphTheory.src.api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheory.src.component.algorithms
{
    internal class SearchForRoutes
    {
        private List<Route> possibleRoute = new List<Route>();
        private List<List<Route>> listOfPosssibleRoutes = new List<List<Route>>();
        private List<List<Route>> result = new List<List<Route>>();

        private int loopLimit = 0;
        private string end = "";
        private Route[] graph = new Route[0];

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
                this.loopLimit = loopLimit;
                this.end = end.ToUpper();
                this.graph = graph;

                possibleRoute = new List<Route>();
                listOfPosssibleRoutes = new List<List<Route>>();
                result = new List<List<Route>>();

                SearchForAllRoutes(start.ToUpper(), NumberOfPossibleRoutes(start.ToUpper()));
                return RemoveRoute();
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
        /// <param name="start">The start point of the routes.</param>
        /// <param name="count">The number of routes which start from the start point.</param>
        private void SearchForAllRoutes(string start, int count)
        {
            try
            {
                Route[] routes = GetAllRoutes(count, start);
                if (listOfPosssibleRoutes.Count == 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        possibleRoute.Add(routes[i]);
                        listOfPosssibleRoutes.Add(new List<Route>(possibleRoute));
                        possibleRoute = new List<Route>();
                    }
                    SearchForAllRoutes(listOfPosssibleRoutes.First().Last().End, NumberOfPossibleRoutes(listOfPosssibleRoutes.First().Last().End));
                }
                else
                {
                    possibleRoute = new List<Route>(listOfPosssibleRoutes.First());
                    for(int i = 0; i < count; i++)
                    {
                        AddRoute(routes[i]);
                        possibleRoute = new List<Route>(listOfPosssibleRoutes.First());
                    }
                    result.Add(new List<Route>(listOfPosssibleRoutes.First()));
                    listOfPosssibleRoutes.Remove(listOfPosssibleRoutes.First());

                    if(listOfPosssibleRoutes.Count > 0)
                    {
                        SearchForAllRoutes(listOfPosssibleRoutes.First().Last().End, NumberOfPossibleRoutes(listOfPosssibleRoutes.First().Last().End));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Returns the number of routes starting from the start point.
        /// </summary>
        /// <param name="start">The start point of the routes.</param>
        /// <returns>The number of routes which start from the start point.</returns>
        private int NumberOfPossibleRoutes(string start)
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
        /// <param name="count">The number of routes form the start point.</param>
        /// <param name="start">The start point of the routes.</param>
        /// <returns>All routes which start form the start point.</returns>
        private Route[] GetAllRoutes(int count, string start)
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
        private List<List<Route>> RemoveRoute()
        {
            List<List<Route>> temp = new List<List<Route>>();
            foreach (List<Route> route in result)
            {
                if (route.Last().End == end)
                {
                    temp.Add(new List<Route>(route));
                }
            }
            return temp;
        }

        /// <summary>
        /// Returns how many times a route exist in possibleRoute.
        /// </summary>
        /// <param name="route">The route to count.</param>
        /// <returns>How many times this route exist in possibleRoute.</returns>
        private int LoopCount(Route route)
        {
            int count = 0;
            foreach (Route route1 in possibleRoute)
            {
                if (route.Comparer(route1))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Adds the given route if it doesn't already exist to often.
        /// </summary>
        /// <param name="route">The route which should be added to possibleRoute.</param>
        private void AddRoute(Route route)
        {
            if(loopLimit > LoopCount(route))
            {
                possibleRoute.Add(route);
                listOfPosssibleRoutes.Add(new List<Route>(possibleRoute));
            }
        }
    }
}
