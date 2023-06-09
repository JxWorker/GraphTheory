using GraphTheory.src.api;
using GraphTheory.src.component;
using GraphTheory.src.wpf;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GraphTheory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExistingGraphOptionControl existingGraphOptionControl;
        private CreateGraphControl createGraphControl;
        private CalculateWindowControl calculateWindowControl;
        private ResultWindowControl resultWindowControl;

        private IGraphTheoryService graphTheoryService;

        private Route[] graphAIT = { new Route("A", "B", 5), new Route("B", "C", 4), new Route("C", "D", 8),
            new Route("D", "C", 8), new Route("D", "E", 6), new Route("A", "D", 5), new Route("C", "E", 2),
            new Route("E", "B", 3), new Route("A", "E", 7) };
        private Route[] graphTest = { new Route("A", "B", 2), new Route("B", "C", 1), new Route("B", "E", 3),
            new Route("C", "G", 3), new Route("G", "F", 7), new Route("F", "G", 7), new Route("E", "F", 4),
            new Route("E", "H", 9), new Route("E", "D", 7), new Route("D", "A", 5), new Route("H", "F", 6) };

        public MainWindow()
        {
            InitializeComponent();

            graphTheoryService = new Algorithm();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectContainer_grid.Children.Clear();
            windowContainer_grid.Children.Clear();
            ComboBoxItem comboBoxItem = (ComboBoxItem)graph_combobox.SelectedItem;

            switch(comboBoxItem.Content.ToString())
            {
                case "Create graph":
                    createGraphControl = new CreateGraphControl();
                    createGraphControl.CalculateButtonClicked += CreatedGraph_CalculateButtonClicked;
                    createGraphControl.TasksButtonClicked += CreatedGraph_TasksButtonClicked;
                    selectContainer_grid.Children.Add(createGraphControl);
                    createGraphControl.Visibility = Visibility.Visible;
                    break;
                case "AIT gragh":
                    existingGraphOptionControl = new ExistingGraphOptionControl();
                    existingGraphOptionControl.CalculateButtonClicked += AITGraph_CalculateButtonClicked;
                    existingGraphOptionControl.TasksButtonClicked += AITGraph_TasksButtonClicked;
                    selectContainer_grid.Children.Add(existingGraphOptionControl);
                    existingGraphOptionControl.Visibility = Visibility.Visible;
                    break;
                case "Test graph":
                    existingGraphOptionControl = new ExistingGraphOptionControl();
                    existingGraphOptionControl.CalculateButtonClicked += TestGraph_CalculateButtonClicked;
                    existingGraphOptionControl.TasksButtonClicked += TestGraph_TasksButtonClicked;
                    selectContainer_grid.Children.Add(existingGraphOptionControl);
                    existingGraphOptionControl.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void AITGraph_CalculateButtonClicked(object sender, EventArgs e)
        {
            windowContainer_grid.Children.Clear();
            calculateWindowControl = new CalculateWindowControl(graphTheoryService, graphAIT);
            windowContainer_grid.Children.Add(calculateWindowControl);
            calculateWindowControl.Visibility = Visibility.Visible;
        }

        private void AITGraph_TasksButtonClicked(object sender, EventArgs e)
        {
            windowContainer_grid.Children.Clear();
            resultWindowControl = new ResultWindowControl(graphTheoryService, graphAIT);
            windowContainer_grid.Children.Add(resultWindowControl);
            resultWindowControl.Visibility = Visibility.Visible;
        }

        private void TestGraph_CalculateButtonClicked(object sender, EventArgs e)
        {
            windowContainer_grid.Children.Clear();
            calculateWindowControl = new CalculateWindowControl(graphTheoryService, graphTest);
            windowContainer_grid.Children.Add(calculateWindowControl);
            calculateWindowControl.Visibility = Visibility.Visible;
        }

        private void TestGraph_TasksButtonClicked(object sender, EventArgs e)
        {
            windowContainer_grid.Children.Clear();
            resultWindowControl = new ResultWindowControl(graphTheoryService, graphTest);
            windowContainer_grid.Children.Add(resultWindowControl);
            resultWindowControl.Visibility = Visibility.Visible;
        }

        private void CreatedGraph_CalculateButtonClicked(object sender, Route[] graph)
        {
            windowContainer_grid.Children.Clear();
            calculateWindowControl = new CalculateWindowControl(graphTheoryService, graph);
            windowContainer_grid.Children.Add(calculateWindowControl);
            calculateWindowControl.Visibility = Visibility.Visible;
        }

        private void CreatedGraph_TasksButtonClicked(object sender, Route[] graph)
        {
            windowContainer_grid.Children.Clear();
            resultWindowControl = new ResultWindowControl(graphTheoryService, graph);
            windowContainer_grid.Children.Add(resultWindowControl);
            resultWindowControl.Visibility = Visibility.Visible;
        }
    }
}
