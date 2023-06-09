using GraphTheory.src.api;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphTheory.src.wpf
{
    /// <summary>
    /// Interaction logic for CalculateWindowControl.xaml
    /// </summary>
    public partial class CalculateWindowControl : UserControl
    {
        private readonly Route[] graph;
        private readonly IGraphTheoryService graphTheoryService;

        public CalculateWindowControl(IGraphTheoryService graphTheoryService, Route[] graph)
        {
            InitializeComponent();

            numberStopDistance_textbox.Visibility = Visibility.Hidden;

            this.graphTheoryService = graphTheoryService;
            this.graph = graph;
        }

        #region Distance
        private void OnClickDistance(object sender, RoutedEventArgs e)
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

                result = graphTheoryService.DistanceOfRoutes(graph, route);
                distanceResult_textbox.Background = Brushes.White;
            }
            else
            {
                result = "Please type in a valid route! eg. A-B-C-D";
                distanceResult_textbox.Background = Brushes.Red;
            }

            distanceResult_textbox.Text = result;
        }
        #endregion

        #region Number
        private void NumberStopDistanceComboboxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)numberStopDistance_combobox.SelectedItem;
            numberStopDistance_textbox.Visibility = Visibility.Visible;

            switch (comboBoxItem.Content.ToString())
            {
                case "Number of possible routes":
                    numberStopDistance_label.Content = " ";
                    numberStopDistance_textbox.Visibility = Visibility.Hidden;
                    break;
                case "Routes with exactly X stops":
                    numberStopDistance_label.Content = "Number of Stops:";
                    break;
                case "Rroutes with equal or less stops":
                    numberStopDistance_label.Content = "Number of Stops:";
                    break;
                case "Routes with equal or more stops":
                    numberStopDistance_label.Content = "Number of Stops:";
                    break;
                case "Routes with an exact distance":
                    numberStopDistance_label.Content = "Distance:";
                    break;
                case "Routes with smaller distance":
                    numberStopDistance_label.Content = "Distance:";
                    break;
                case "Routes with higher distance":
                    numberStopDistance_label.Content = "Distance:";
                    break;
            }
        }

        private void OnClickNumber(object sender, RoutedEventArgs e)
        {
            string start = numberStart_textbox.Text;
            string end = numberEnd_textbox.Text;
            string stopOrDistance = numberStopDistance_textbox.Text;
            string looptime = numberLoopTime_textbox.Text;
            int countType = numberStopDistance_combobox.SelectedIndex;

            if(countType == -1)
            {
                numberResult_textbox.Text = "Please select a way to count the routes!";
                numberResult_textbox.Background = Brushes.Red;
                return;
            }

            if(!(graphTheoryService.ExistInGraph(graph, start) && graphTheoryService.ExistInGraph(graph, end)))
            {
                numberResult_textbox.Text = "Please type in a valid point!";
                numberResult_textbox.Background = Brushes.Red;
                return;
            }

            if (!(Regex.IsMatch(stopOrDistance, @"^\d+$") && Regex.IsMatch(looptime, @"^\d+$")))
            {
                numberResult_textbox.Text = "Please type in a valid value!";
                numberResult_textbox.Background = Brushes.Red;
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

            numberResult_textbox.Text = graphTheoryService.NumberOfRoutes(graph, start, end, countType, loop, stops, distance);
            numberResult_textbox.Background = Brushes.White;
        }
        #endregion

        #region Shortes
        private void OnClickShortes(object sender, RoutedEventArgs e)
        {
            string start = shortesStart_textbox.Text;
            string end = shortesEnd_textbox.Text;
            string result;

            if (graphTheoryService.ExistInGraph(graph, start) && graphTheoryService.ExistInGraph(graph, end))
            {
                result = graphTheoryService.ShortesRoute(graph, start, end);
                shortesResult_textbox.Background = Brushes.White;
            }
            else
            {
                result = "Please type in a valid point!";
                shortesResult_textbox.Background = Brushes.Red;
            }

            shortesResult_textbox.Text = result;
        }
        #endregion
    }
}
