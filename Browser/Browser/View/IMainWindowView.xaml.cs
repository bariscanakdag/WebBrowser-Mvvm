using Browser.ViewModel;
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

namespace Browser.View
{
    /// <summary>
    /// Interaction logic for IMainWindowView.xaml
    /// </summary>
    public partial class IMainWindowView : Window
    {
        public IMainWindowView()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
           
        }

     
    }
}
