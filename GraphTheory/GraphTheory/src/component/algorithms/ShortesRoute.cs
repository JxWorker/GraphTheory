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
        public ShortesRoute() { }

        public int DistanceOfRoute(Route[] graph, string start,string end)
        {
            nextPossibleRoute = new();
            possibleRoutes = new();

            SearchForAllRoutes(graph, start);
            RemoveWrongRoutes(end);

            return ShortestDistance();
        }

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

        private List<Route> AddPossibleRoutes(Route[] graph, Route route)
        {
            if (nextPossibleRoute.Count == 0 || (nextPossibleRoute.Last().End == route.Start && !nextPossibleRoute.Contains(route)))
            {
                nextPossibleRoute
                    .Add(route);
                SearchForAllRoutes(graph, route.End);
            }
            return nextPossibleRoute;
        }

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

        private int ShortestDistance()
        {
            int distance = 0;
            int temp = 0;

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

        private int CalculateDistance(List<Route> routes)
        {
            int distance = 0;

            foreach (Route graph in routes)
            {
                distance += graph.Distance;
            }

            return distance;
        }
    }
}
