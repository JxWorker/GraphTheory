using GraphTheory.src.api;
using System.Windows.Controls;

namespace GraphTheory.src.wpf
{
    /// <summary>
    /// Interaction logic for ResultWindowControl.xaml
    /// </summary>
    public partial class ResultWindowControl : UserControl
    {
        private readonly string[] tasks = {
            "1. Length of the route A-B-C:",
            "2. Length of route A-D:",
            "3. Length of Route A-D-C:",
            "4. Length of Route A-E-B-C-D:",
            "5. Length of route A-E-D:",
            "6. Number of routes that start at C and also end at C and have no more than 3 stops:",
            "7. Number of routes that start at A and end at C, with exactly 4 stops:",
            "8. Length of the shortestt route from A to C:",
            "9. Length of the shortestt route from B to B:",
            "10. Number of routes from C to C with length < 30:"};
        private string[] results = new string[10];

        private readonly Route[] graph;
        private readonly IGraphTheoryService graphTheoryService;

        public ResultWindowControl(IGraphTheoryService graphTheoryService, Route[] graph)
        {
            InitializeComponent();

            this.graphTheoryService = graphTheoryService;
            this.graph = graph;

            CalculateResult();
            ConcatResult();
            SetLabel(results, task_stackpanel.Children);
        }

        private void SetLabel(string[] text, UIElementCollection uIElementCollection)
        {
            string graphList = "Graph: ";
            foreach (Route route in graph)
            {
                graphList = graphList + route.ToString() + ", ";
            }
            graphList = graphList.Substring(0, graphList.Length-2);

            int i = 0;
            foreach (TextBlock element in uIElementCollection)
            {
                if (element.Name == "task_textBlock0")
                {
                    element.Text = graphList;
                }
                else
                {
                    element.Text = text[i++];
                }
            }
        }

        private void CalculateResult()
        {
            results[0] = graphTheoryService.DistanceOfRoutes(graph, new string[] { "A", "B", "C" });
            results[1] = graphTheoryService.DistanceOfRoutes(graph, new string[] { "A", "D" });
            results[2] = graphTheoryService.DistanceOfRoutes(graph, new string[] { "A", "D", "C" });
            results[3] = graphTheoryService.DistanceOfRoutes(graph, new string[] { "A", "E", "B", "C", "D" });
            results[4] = graphTheoryService.DistanceOfRoutes(graph, new string[] { "A", "E", "D" });
            results[5] = graphTheoryService.NumberOfRoutes(graph, "C", "C", 3, 3, 3, 0);
            results[6] = graphTheoryService.NumberOfRoutes(graph, "A", "C", 2, 3, 4, 0);
            results[7] = graphTheoryService.ShortestRoute(graph, "A", "C");
            results[8] = graphTheoryService.ShortestRoute(graph, "B", "B");
            results[9] = graphTheoryService.NumberOfRoutes(graph, "C", "C", 6, 3, 0, 30);
        }

        private void ConcatResult()
        {
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = tasks[i] + " " + results[i];
            }
        }
    }
}
