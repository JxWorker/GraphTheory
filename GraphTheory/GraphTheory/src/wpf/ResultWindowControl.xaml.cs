using GraphTheory.src.api;
using GraphTheory.src.component;
using System;
using System.Collections;
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
using static System.Formats.Asn1.AsnWriter;

namespace GraphTheory.src.wpf
{
    /// <summary>
    /// Interaction logic for ResultWindowControl.xaml
    /// </summary>
    public partial class ResultWindowControl : UserControl
    {
        private readonly string[] tasks = {
            "Length of the route A-B-C:",
            "Length of route A-D:",
            "Length of Route A-D-C:",
            "Length of Route A-E-B-C-D:",
            "Length of route A-E-D:",
            "Number of routes that start at C and also end at C and have no more than 3 stops:",
            "Number of routes that start at A and end at C, with exactly 4 stops:",
            "Length of the shortest route from A to C:",
            "Length of the shortest route from B to B:",
            "Number of routes from C to C with length < 30:"};
        private string[] results = new string[10];

        private readonly Route[] graph;
        private readonly IGraphTheoryService graphTheoryService;

        public ResultWindowControl(IGraphTheoryService graphTheoryService, Route[] graph)
        {
            InitializeComponent();

            this.graphTheoryService = graphTheoryService;
            this.graph = graph;

            SetLabel(tasks, task_stackpanel.Children);
            CalculateResult();
            SetLabel(results, result_stackpanel.Children);
        }

        private void SetLabel(string[] text, UIElementCollection labels)
        {
            int i = 0;
            foreach (Label label in labels)
            {
                label.Content = text[i++];
            }
        }

        private void CalculateResult()
        {
            results[0] = graphTheoryService.DistanceOfRoutes(graph, new string[] { "A", "B", "C" });
            results[1] = graphTheoryService.DistanceOfRoutes(graph, new string[] { "A", "D" });
            results[2] = graphTheoryService.DistanceOfRoutes(graph, new string[] { "A", "D", "C" });
            results[3] = graphTheoryService.DistanceOfRoutes(graph, new string[] { "A", "E", "B", "C", "D" });
            results[4] = graphTheoryService.DistanceOfRoutes(graph, new string[] { "A", "E", "D" });
            results[5] = graphTheoryService.NumberOfRoutes(graph, "C", "C", 3, 4, 3, 0);
            results[6] = graphTheoryService.NumberOfRoutes(graph, "A", "C", 2, 4, 4, 0);
            results[7] = graphTheoryService.ShortesRoute(graph, "A", "C");
            results[8] = graphTheoryService.ShortesRoute(graph, "B", "B");
            results[9] = graphTheoryService.NumberOfRoutes(graph, "C", "C", 6, 10, 0, 30);
        }
    }
}
