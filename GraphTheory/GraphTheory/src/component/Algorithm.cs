using GraphTheory.src.api;
using GraphTheory.src.component.algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.component
{
    internal class Algorithm : IGraphTheoryService
    {
        DistanceOfRoutes distanceOfRoutes = new DistanceOfRoutes();
        NumberOfRoutes numberOfRoutes = new NumberOfRoutes();
        ShortesRoute shortesRoute = new ShortesRoute();
        public int DistanceOfRoutes(Route[] graph, string[] route)
        {
           return distanceOfRoutes.CalculateDistance(graph, route);
        }

        public int NumberOfRoutes(Route[] graph, string start, string end)
        {
            numberOfRoutes.SearchForRoutes(graph, start);
            numberOfRoutes.RemoveRoute(end);
            return numberOfRoutes.GetCountOfRoutes();
        }

        public int ShortesRoute(Route[] graph, string start, string end)
        {
            throw new NotImplementedException();
        }
    }
}
