using GraphTheory.src.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.src.component.algorithms
{
    internal class NumberOfRoutes
    {
        private ShortesRoute shortesRoute = new ShortesRoute();

        /// <summary>
        /// Returns the number of possible routes between a start and end point.
        /// </summary>
        /// <param name="listOfPosssibleRoutes">List of all possible and valied routes between a start and end point.</param>
        /// <returns>The number of possible routes between a start and end point.</returns>
        public int CountOfRoutes(List<List<Route>> listOfPosssibleRoutes)
        {
            return listOfPosssibleRoutes.Count;
        }

        /// <summary>
        /// Returns the number of possible routes between a start and end point with an exact number of stops.
        /// </summary>
        /// <param name="listOfPosssibleRoutes">List of all possible and valied routes between a start and end point.</param>
        /// <param name="numberOfStopps">How many stops a route can have.</param>
        /// <returns>The number of possible routes between a start and end point with an exact number of stops.</returns>
        public int CountOfRoutesWithExactStopps(List<List<Route>> listOfPosssibleRoutes, int numberOfStopps)
        {
            List<List<Route>> temp = new List<List<Route>>();
            foreach (List<Route> route in listOfPosssibleRoutes)
            {
                if (route.Count == numberOfStopps)
                {
                    temp.Add(new List<Route>(route));
                }
            }

            return temp.Count;
        }

        /// <summary>
        /// Returns the number of possible routes between a start and end point with exact or less number of stops.
        /// </summary>
        /// <param name="listOfPosssibleRoutes">List of all possible and valied routes between a start and end point.</param>
        /// <param name="numberOfStopps">How many stops a route can have.</param>
        /// <returns>The number of possible routes between a start and end point with exact or less number of stops.</returns>
        public int CountOfRoutesWithEqualOrLessStopps(List<List<Route>> listOfPosssibleRoutes, int numberOfStopps)
        {
            List<List<Route>> temp = new List<List<Route>>();
            foreach (List<Route> route in listOfPosssibleRoutes)
            {
                if (route.Count <= numberOfStopps)
                {
                    temp.Add(new List<Route>(route));
                }
            }

            return temp.Count;
        }

        /// <summary>
        /// Returns the number of possible routes between a start and end point with exact or higher number of stops.
        /// </summary>
        /// <param name="listOfPosssibleRoutes">List of all possible and valied routes between a start and end point.</param>
        /// <param name="numberOfStopps">How many stops a route can have.</param>
        /// <returns>The number of possible routes between a start and end point with exact or higher number of stops.</returns>
        public int CountOfRoutesWithEqualOrMoreStopps(List<List<Route>> listOfPosssibleRoutes, int numberOfStopps)
        {
            List<List<Route>> temp = new List<List<Route>>();
            foreach (List<Route> route in listOfPosssibleRoutes)
            {
                if (route.Count >= numberOfStopps)
                {
                    temp.Add(new List<Route>(route));
                }
            }

            return temp.Count;
        }

        /// <summary>
        /// Returns the number of routes with the exact distance between the start and end point.
        /// </summary>
        /// <param name="listOfPosssibleRoutes">List of all possible and valied routes between a start and end point.</param>
        /// <param name="distanceLimit">What distance can be between the start and end point.</param>
        /// <returns>The number of routes with the exact distance between the start and end point.</returns>
        public int CountOfRoutesWithExactDistance(List<List<Route>> listOfPosssibleRoutes, int distanceLimit)
        {
            int count = 0;
            foreach (List<Route> route in listOfPosssibleRoutes)
            {
                if(distanceLimit == shortesRoute.CalculateDistance(route))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the number of routes with an equal or shorter distance between the start and end point.
        /// </summary>
        /// <param name="listOfPosssibleRoutes">List of all possible and valied routes between a start and end point.</param>
        /// <param name="distanceLimit">What distance can be between the start and end point.</param>
        /// <returns>The number of routes with an equal or shorter distance between the start and end point</returns>
        public int CountOfRoutesWithEqualOrShorterDistance(List<List<Route>> listOfPosssibleRoutes, int distanceLimit)
        {
            int count = 0;
            foreach (List<Route> route in listOfPosssibleRoutes)
            {
                if (distanceLimit >= shortesRoute.CalculateDistance(route))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the number of routes with an equal or longer distance between the start and end point.
        /// </summary>
        /// <param name="listOfPosssibleRoutes">List of all possible and valied routes between a start and end point.</param>
        /// <param name="distanceLimit">What distance can be between the start and end point.</param>
        /// <returns>The number of routes with an equal or longer distance between the start and end point.</returns>
        public int CountOfRoutesWithEqualOrLongerDistance(List<List<Route>> listOfPosssibleRoutes, int distanceLimit)
        {
            int count = 0;
            foreach (List<Route> route in listOfPosssibleRoutes)
            {
                if (distanceLimit <= shortesRoute.CalculateDistance(route))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
