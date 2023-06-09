﻿using GraphTheory.src.api;
using GraphTheory.src.component.algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.component
{
    public class Algorithm : IGraphTheoryService
    {
        SearchForRoutes searchForRoutes = new SearchForRoutes();
        DistanceOfRoutes distanceOfRoutes = new DistanceOfRoutes();
        NumberOfRoutes numberOfRoutes = new NumberOfRoutes();
        ShortestRoute shortestRoute = new ShortestRoute();

        public string DistanceOfRoutes(Route[] graph, string[] route)
        {
            int distance = distanceOfRoutes.CalculateDistance(graph, route);

            if (distance == -1)
            {
                return "NO SUCH ROUTE";
            }
            else
            {
                return distance.ToString();
            }
        }

        public string NumberOfRoutes(Route[] graph, string start, string end, int countType, int loopLimit, int numberOfStopps, int distanceLimit)
        {
            int count = 0;
            List<List<Route>> list = searchForRoutes.SearchForRoute(graph, start, end, loopLimit);

            switch (countType)
            {
                case 1:
                    count = numberOfRoutes.CountOfRoutes(list);
                    break;
                case 2:
                    count = numberOfRoutes.CountOfRoutesWithExactStopps(list, numberOfStopps);
                    break;
                case 3:
                    count = numberOfRoutes.CountOfRoutesWithEqualOrLessStopps(list, numberOfStopps);
                    break;
                case 4:
                    count = numberOfRoutes.CountOfRoutesWithEqualOrMoreStopps(list, numberOfStopps);
                    break;
                case 5:
                    count = numberOfRoutes.CountOfRoutesWithExactDistance(list, distanceLimit);
                    break;
                case 6:
                    count = numberOfRoutes.CountOfRoutesWithEqualOrShorterDistance(list, distanceLimit);
                    break;
                case 7:
                    count = numberOfRoutes.CountOfRoutesWithEqualOrLongerDistance(list, distanceLimit);
                    break;
                default: 
                    count = 0;
                    break;
            }

            if (count == 0)
            {
                return "NO SUCH ROUTE";
            }
            else
            {
                return count.ToString();
            }
        }

        public string ShortestRoute(Route[] graph, string start, string end)
        {
            int distance = shortestRoute.ShortestDistance(searchForRoutes.SearchForRoute(graph, start, end, 1));

            if (distance == -1)
            {
                return "NO SUCH ROUTE";
            }
            else
            {
                return distance.ToString();
            }
        }

        public bool ExistInGraph(Route[] graph, string point)
        {
            HashSet<string> existingPoints = new HashSet<string>();

            foreach (Route route in graph)
            {
                existingPoints.Add(route.Start);
                existingPoints.Add(route.End);
            }

            foreach (string str in existingPoints)
            {
                if(point.ToUpper() == str)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
