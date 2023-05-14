using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.api
{
    internal class Route
    {
        public string Start { get; }
        public string End { get; }
        public int Distance { get; }

        public Route(string pStart, string pEnd, int pDistance)
        {
            Start = pStart;
            End = pEnd;
            Distance = pDistance;
        }
    }
}
