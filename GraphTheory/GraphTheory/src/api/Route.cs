using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.api
{
    public class Route
    {
        public string Start { get; }
        public string End { get; }
        public int Distance { get; }

        public Route(string start, string end, int distance)
        {
            Start = start;
            End = end;
            Distance = distance;
        }

        public bool Comparer(Route route)
        {
            try
            {
                if (this.Start.Equals(route.Start)
                    && this.End.Equals(route.End)
                    && this.Distance == route.Distance)
                {
                    return true;
                }
                return false;
            }
            catch (NullReferenceException e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
