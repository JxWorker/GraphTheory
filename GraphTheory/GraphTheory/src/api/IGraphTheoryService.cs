using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.api
{
    internal interface IGraphTheoryService
    {
        public int DistanceOfRoutes(Route[] graph, string[] route);

        public int NumberOfRoutes(Route[] graph, string start, string end);

        public int ShortesRoute(Route[] graph, string start, string end);
    }
}
