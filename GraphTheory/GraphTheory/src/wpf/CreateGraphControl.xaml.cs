using GraphTheory.src.api;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphTheory.src.wpf
{
    /// <summary>
    /// Interaction logic for CreateGraphControl.xaml
    /// </summary>
    public partial class CreateGraphControl : UserControl
    {
        public event EventHandler<Route[]> CalculateButtonClicked;
        public event EventHandler<Route[]> TasksButtonClicked;

        public Route[] graph = new Route[0];

        public CreateGraphControl()
        {
            InitializeComponent();
        }

        private void NumberComboboxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            container_grid.Children.Clear();
            ComboBoxItem comboBoxItem = (ComboBoxItem)number_combobox.SelectedItem;

            switch (comboBoxItem.Content.ToString())
            {
                case "3":
                    CreateTextBox(3);
                    break;
                case "4":
                    CreateTextBox(4);
                    break;
                case "5":
                    CreateTextBox(5);
                    break;
                case "6":
                    CreateTextBox(6);
                    break;
                case "7":
                    CreateTextBox(7);
                    break;
                case "8":
                    CreateTextBox(8);
                    break;
                case "9":
                    CreateTextBox(9);
                    break;
                case "10":
                    CreateTextBox(10);
                    break;
            }
        }

        private void CreateTextBox(int number)
        {
            for (int i = 0; i < number; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Margin = new Thickness(10, 5, 10, 5);
                container_grid.Children.Add(textBox);
            }
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)number_combobox.SelectedItem;

            if(comboBoxItem == null)
            {
                return;
            }

            int numberOfRoutes = int.Parse(comboBoxItem.Content.ToString());
            graph = new Route[numberOfRoutes];

            Regex regex = new Regex("([A-Za-z]+(-[A-Za-z]+(-[0-9])))", RegexOptions.IgnoreCase);

            int i = 0;
            foreach (TextBox textBox in container_grid.Children)
            {
                if (regex.IsMatch(textBox.Text))
                {
                    textBox.Background = Brushes.White;
                    string start = textBox.Text.Split('-')[0];
                    string end = textBox.Text.Split('-')[1];
                    int distance = int.Parse(textBox.Text.Split('-')[2]);
                    graph[i++] = new Route(start, end, distance);
                }
                else
                {
                    textBox.Text = textBox.Text + " | Please typ in a vaild route!";
                    textBox.Background = Brushes.Red;
                }
            }

            save_button.Content = "Saved: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm");
        }

        private void CalculateButtonClick(object sender, RoutedEventArgs e)
        {
            CalculateButtonClicked?.Invoke(this, graph);
        }

        private void TasksButtonClick(object sender, RoutedEventArgs e)
        {
            TasksButtonClicked?.Invoke(this, graph);
        }
    }
}
