using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using WpfBindingErrors;

namespace XMusCringleW
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (e.Args != null)
            {
                System.IO.FileInfo f = new System.IO.FileInfo(e.Args[0]);
                if (f.Exists)
                {
                    ViewModelLocator v = App.Current.Resources["Locator"] as ViewModelLocator;
                    v.Main.Menu.OpenFile(f.FullName);
                }
            }
            //WpfBindingErrors.BindingExceptionThrower.Attach();
        }
    }
}
