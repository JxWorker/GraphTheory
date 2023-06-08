using GraphTheory.src.api;
using GraphTheory.src.component;
using GraphTheory.src.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace GraphTheory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string input = "";
        private Route[] graphAIT = { new Route("A", "B", 5), new Route("B", "C", 4), new Route("C", "D", 8),
            new Route("D", "C", 8), new Route("D", "E", 6), new Route("A", "D", 5), new Route("C", "E", 2),
            new Route("E", "B", 3), new Route("A", "E", 7) };
        private Route[] graphTest = { new Route("A", "B", 2), new Route("B", "C", 1), new Route("B", "E", 3),
            new Route("C", "G", 3), new Route("G", "F", 7), new Route("F", "G", 7), new Route("E", "F", 4),
            new Route("E", "H", 9), new Route("E", "D", 7), new Route("D", "A", 5), new Route("H", "F", 6) };
        private Route[] graphCreated;
        private Route[] graph;

        private IGraphTheoryService graphTheoryService;

        public MainWindow()
        {
            InitializeComponent();

            graphTheoryService = new Algorithm();
        }

        void testClick(object sender, EventArgs e)
        {
            CalculateWindowControl test = new CalculateWindowControl(graphTheoryService, graphTest);
            ResultWindowControl test1 = new ResultWindowControl(graphTheoryService, graphAIT);

            windowContainer.Children.Add(test1);
            test1.Visibility = Visibility.Visible;
        }
    }
}
