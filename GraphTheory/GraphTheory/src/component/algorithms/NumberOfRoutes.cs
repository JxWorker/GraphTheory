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
        public int GetCountOfRoutes(List<List<Route>> listOfPosssibleRoutes)
        {
            return listOfPosssibleRoutes.Count;
        }

        public int GetCountOfRoutesWithExactStopps(List<List<Route>> listOfPosssibleRoutes, int numberOfStopps)
        {
            foreach (List<Route> route in listOfPosssibleRoutes)
            {
                if (route.Count - 2 != numberOfStopps)
                {
                    listOfPosssibleRoutes.Remove(route);
                }
            }

            return listOfPosssibleRoutes.Count;
        }

        public int GetCountOfRoutesWithEqualOrLessStopps(List<List<Route>> listOfPosssibleRoutes, int numberOfStopps)
        {
            foreach (List<Route> route in listOfPosssibleRoutes)
            {
                if (route.Count - 2 > numberOfStopps)
                {
                    listOfPosssibleRoutes.Remove(route);
                }
            }

            return listOfPosssibleRoutes.Count;
        }

        public int GetCountOfRoutesEqualOrMoreStopps(List<List<Route>> listOfPosssibleRoutes, int numberOfStopps)
        {
            foreach (List<Route> route in listOfPosssibleRoutes)
            {
                if (route.Count - 2 < numberOfStopps)
                {
                    listOfPosssibleRoutes.Remove(route);
                }
            }

            return listOfPosssibleRoutes.Count;
        }
    }
}
