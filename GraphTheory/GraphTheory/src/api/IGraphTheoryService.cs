using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.api
{
    internal interface IGraphTheoryService
    {
        public string DistanceOfRoutes(Route[] graph, string[] route);

        public string NumberOfRoutes(Route[] graph, string start, string end, int numberOfStopps, int countType, int loopLimit);

        public string ShortesRoute(Route[] graph, string start, string end);
    }
}
