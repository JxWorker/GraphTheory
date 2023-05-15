using GraphTheory.src.api;
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
        ShortesRoute shortesRoute = new ShortesRoute();

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

        public string NumberOfRoutes(Route[] graph, string start, string end, int numberOfStopps, int countType, int loopLimit)
        {
            int count = 0;
            List<List<Route>> list = searchForRoutes.SearchForRoute(graph, start, end, loopLimit);

            switch (countType)
            {
                case 1:
                    count = numberOfRoutes.GetCountOfRoutes(list);
                    break;
                case 2:
                    count = numberOfRoutes.GetCountOfRoutesWithExactStopps(list, numberOfStopps);
                    break;
                case 3:
                    count = numberOfRoutes.GetCountOfRoutesWithEqualOrLessStopps(list, numberOfStopps);
                    break;
                case 4:
                    count = numberOfRoutes.GetCountOfRoutesEqualOrMoreStopps(list, numberOfStopps);
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

        public string ShortesRoute(Route[] graph, string start, string end)
        {
            int distance = shortesRoute.ShortestDistance(searchForRoutes.SearchForRoute(graph, start, end, 1));
            if (distance == -1)
            {
                return "NO SUCH ROUTE";
            }
            else
            {
                return distance.ToString();
            }
        }
    }
}
