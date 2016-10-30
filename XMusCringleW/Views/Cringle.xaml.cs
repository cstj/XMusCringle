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
using System.Windows.Shapes;

namespace XMusCringleW.Views
{
    /// <summary>
    /// Interaction logic for Cringle.xaml
    /// </summary>
    public partial class Cringle : Window
    {
        public Cringle()
        {
            InitializeComponent();
        }

        private void butClose_Click(object sender, RoutedEventArgs e)
        {
            var d = DataContext as XMusCringleLib.Viewmodels.Cringle;
            d.CloseCommand.Execute(null);
            this.Close();
        }

        private void butNewCringle_Click(object sender, RoutedEventArgs e)
        {
            var d = DataContext as XMusCringleLib.Viewmodels.Cringle;
            d.NewCringleCommand.Execute(null);
            Views.NewCringle w = new NewCringle();
            w.ShowDialog();
        }
    }
}
