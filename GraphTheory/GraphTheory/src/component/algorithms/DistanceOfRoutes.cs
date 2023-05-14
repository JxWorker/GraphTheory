using GraphTheory.src.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.component.algorithms
{
    internal class DistanceOfRoutes
    {
        public int DistanceOfRoute(Route[] graph, string[] route)
        {
            int distance = 0;

            for (int i = 0; i < route.Length; i++)
            {
                int index = SearchForRoute(graph, route[i], route[i + 1]);

                if (index == -1)
                {
                    return -1;
                }

                distance += index;
            }
            return distance;
        }

        private int SearchForRoute(Route[] graph, string start, string end)
        {
            for (int i = 0; i <= graph.Length; i++)
            {
                if (graph[i].Start.Equals(start) && graph[i].End.Equals(end))
                {
                    return graph[i].Distance;
                }
            }
            return -1;
        }
    }
}
