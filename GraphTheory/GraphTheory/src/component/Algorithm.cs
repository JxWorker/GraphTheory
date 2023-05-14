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
        DistanceOfRoutes distanceOfRoutes = new DistanceOfRoutes();
        NumberOfRoutes numberOfRoutes = new NumberOfRoutes();
        ShortesRoute shortesRoute = new ShortesRoute();
        public string DistanceOfRoutes(Route[] graph, string[] route)
        {
            int distacne = distanceOfRoutes.CalculateDistance(graph, route);

            if (distacne == -1)
            {
                return "NO SUCH ROUTE";
            }
            else
            {
                return distacne.ToString();
            }
            
        }

        public string NumberOfRoutes(Route[] graph, string start, string end)
        {
            numberOfRoutes.SearchForRoutes(graph, start);
            numberOfRoutes.RemoveRoute(end);
            int count = numberOfRoutes.GetCountOfRoutes();
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
            throw new NotImplementedException();
        }
    }
}
