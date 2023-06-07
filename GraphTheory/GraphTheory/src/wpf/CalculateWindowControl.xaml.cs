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
        Route[] graph = new Route[0];
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
