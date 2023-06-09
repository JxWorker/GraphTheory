using GraphTheory.src.api;
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

namespace GraphTheory.src.wpf
{
    /// <summary>
    /// Interaction logic for ExistingGraphOptionControl.xaml
    /// </summary>
    public partial class ExistingGraphOptionControl : UserControl
    {
        public event EventHandler CalculateButtonClicked;
        public event EventHandler TasksButtonClicked;
        public ExistingGraphOptionControl()
        {
            InitializeComponent();
        }

        private void calculate_button_Click(object sender, RoutedEventArgs e)
        {
            CalculateButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void tasks_button_Click(object sender, RoutedEventArgs e)
        {
            TasksButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
