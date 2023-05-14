using GraphTheory.src.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.component.algorithms
{
    internal class NumberOfRoutes
    {
        List<Route> nextPossibleRoute = new List<Route>();
        List<List<Route>> listOfPosssibleRoutes = new List<List<Route>>();

        public int Count(Route[] graph, string start, string end)
        {
            nextPossibleRoute = new List<Route>();
            listOfPosssibleRoutes = new List<List<Route>>();

            SearchForRoutes(graph, start);
            RemoveRoute(end);

            return listOfPosssibleRoutes.Count;
        }

        private void SearchForRoutes(Route[] graph, string start)
        {
            int count = NumberOfPossibleRoutes(graph, start);
            Route[] routes = GetAllRoutes(graph, count, start);
            for (int i = 0; i < count; i++)
            {
                nextPossibleRoute.Add(routes[i]);
                SearchForAllRoutes(graph, routes[i].End, NumberOfPossibleRoutes(graph, routes[i].End));
                listOfPosssibleRoutes.Add(nextPossibleRoute);
                nextPossibleRoute = new List<Route>();
            }
        }

        private void SearchForAllRoutes(Route[] graph, string start, int count)
        {
            Route[] routes = GetAllRoutes(graph, count, start);
            if (count == 1 && !nextPossibleRoute.Contains(routes[0]))
            {
                nextPossibleRoute.Add(routes[0]);
                SearchForAllRoutes(graph, routes[0].End, NumberOfPossibleRoutes(graph, routes[0].End));
            }
            else if (count > 1)
            {
                List<List<Route>> temp = new List<List<Route>>();
                temp.Add(nextPossibleRoute);
                for (int i = 0; i < count; i++)
                {
                    if (!nextPossibleRoute.Contains(routes[i]))
                    {
                        nextPossibleRoute.Add(routes[i]);
                        SearchForAllRoutes(graph, routes[0].End, NumberOfPossibleRoutes(graph, routes[0].End));
                    }
                    nextPossibleRoute = temp.Last();
                }
            }
        }

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

        private Route[] GetAllRoutes(Route[] graph, int count, string start)
        {
            try
            {
                Route[] routes = new Route[count];
                foreach (Route route in graph)
                {
                    if (route.Start.Equals(start))
                    {
                        routes[count--] = route;
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

        private void AddNextRoute(Route route)
        {
            if (nextPossibleRoute.Last().End == route.Start && !nextPossibleRoute.Contains(route))
            {
                nextPossibleRoute.Add(route);
            }
        }

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
    }
}
