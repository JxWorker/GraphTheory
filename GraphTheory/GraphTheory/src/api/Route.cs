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
            Start = start.ToUpper();
            End = end.ToUpper();
            Distance = distance;
        }

        /// <summary>
        /// Returns true if route and this.route are equal and false if not.
        /// </summary>
        /// <param name="route">The route to compare this.route with.</param>
        /// <returns>True if this.route and route have the same start, end and distance. Flase if they are not equal.</returns>
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
