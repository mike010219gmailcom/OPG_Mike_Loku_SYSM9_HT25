using OPG_Mike_Loku_SYSM9_HT25.Manager;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OPG_Mike_Loku_SYSM9_HT25
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            UserManager userManager = (UserManager)Application.Current.Resources["UserManager"];
            DataContext = userManager;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void LoginMainWindow(object sender, RoutedEventArgs e)
        {
            UserManager userManager = (UserManager)Application.Current.Resources["UserManager"];
            bool loginSuccess = userManager.Login(Username, Password);

        }

        private void Register(object sender, RoutedEventArgs e)
        {

        }
    }
}