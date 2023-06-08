using GraphTheory.src.api;
using GraphTheory.src.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphTheory.src.wpf
{
    /// <summary>
    /// Interaction logic for CalculateWindowControl.xaml
    /// </summary>
    public partial class CalculateWindowControl : UserControl
    {
        Route[] graph;
        Algorithm algorithm;

        public CalculateWindowControl(Route[] graph)
        {
            InitializeComponent();

            algorithm = new Algorithm();
            this.graph = graph;
        }

        #region Distance
        void OnClickDistance(object sender, RoutedEventArgs e)
        {
            string input = distanceRoute_textbox.Text;
            string[] route;
            string result;

            Regex regex = new Regex("([A-Za-z]+(-[A-Za-z]+)+)", RegexOptions.IgnoreCase);
            
            if (regex.IsMatch(input))
            {
                input = Regex.Replace(input, "-", "");
                route = new string[input.Length];

                for(int i = 0; i < input.Length; i++)
                {
                    route[i] = input.Substring(i, 1).ToUpper();
                }

                result = algorithm.DistanceOfRoutes(graph, route);
            }
            else
            {
                result = "Please type in a valid route! eg. A-B-C-D";
            }

            distanceResult_textbox.Text = result;
        }
        #endregion

        #region Number
        void OnClickNumber(object sender, RoutedEventArgs e)
        {
            string start = numberStart_textbox.Text;
            string end = numberEnd_textbox.Text;
            string stopOrDistance = numberStopDistance_textbox.Text;
            string looptime = numberLooptime_texbox.Text;
            int countType = numberStopDistance_combobox.SelectedIndex;

            if(countType == -1)
            {
                numberResult_textbox.Text = "Please select a way to count the routes!";
                return;
            }

            if(!(algorithm.ExistInGraph(graph, start) && algorithm.ExistInGraph(graph, end)))
            {
                numberResult_textbox.Text = "Please type in a valid point!";
                return;
            }

            if(!(Regex.IsMatch(stopOrDistance, @"^\d+$") && Regex.IsMatch(looptime, @"^\d+$")))
            {
                numberResult_textbox.Text = "Please type in a valid value!";
                return;
            }

            int loop = int.Parse(looptime);
            int stops;
            int distance;

            if(countType < 5)
            {
                stops = int.Parse(stopOrDistance);
                distance = 0;
            }
            else
            {
                stops = 0;
                distance = int.Parse(stopOrDistance);
            }            

            numberResult_textbox.Text = algorithm.NumberOfRoutes(graph, start, end, countType, loop, stops, distance);
        }
        #endregion

        #region Shortes
        void OnClickShortes(object sender, RoutedEventArgs e)
        {
            string start = shortesStart_textbox.Text;
            string end = shortesEnd_textbox.Text;
            string result;

            if (algorithm.ExistInGraph(graph, start) && algorithm.ExistInGraph(graph, end))
            {
                result = algorithm.ShortesRoute(graph, start, end);
            }
            else
            {
                result = "Please type in a valid point!";
            }

            shortesResult_textbox.Text = result;
        }
        #endregion
    }
}
