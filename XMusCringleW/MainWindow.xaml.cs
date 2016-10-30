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

namespace XMusCringleW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void butPeople_Click(object sender, RoutedEventArgs e)
        {
            var d = this.DataContext as XMusCringleLib.Viewmodels.Menu;
            d.PeopleCommand.Execute(null);
            XMusCringleW.Views.People p = new Views.People();
            p.ShowDialog();
        }

        private void butCringle_Click(object sender, RoutedEventArgs e)
        {
            var d = this.DataContext as XMusCringleLib.Viewmodels.Menu;
            d.RunCringleCommand.Execute(null);
            XMusCringleW.Views.Cringle p = new Views.Cringle();
            p.ShowDialog();
        }
    }
}
