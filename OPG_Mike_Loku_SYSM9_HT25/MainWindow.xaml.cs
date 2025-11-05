using OPG_Mike_Loku_SYSM9_HT25.Manager;
using OPG_Mike_Loku_SYSM9_HT25.Models;
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

        // Metod för att hantera inloggning
        private void LoginMainWindow(object sender, RoutedEventArgs e)
        {
            UserManager userManager = (UserManager)Application.Current.Resources["UserManager"];

            // Hämta användarnamn och lösenord från inmatningsfält
            bool loginSuccess = userManager.Login();

            if (loginSuccess)
            {

                RecipeManager recipeManager = (RecipeManager)Application.Current.Resources["RecipeManager"];
                if (userManager.CurrentUser.IsAdmin)
                {
                    // Skapa listan
                    recipeManager.LoadAllUserRecipes(userManager.Users);
                }

                MessageBox.Show($"Välkommen {userManager.CurrentUser.DisplayName}!");
                RecipeListWindow recipeListWindow = new RecipeListWindow();
                recipeListWindow.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Fel användarnamn eller lösenord.");
            }

        }

        // Öppna registreringsfönstret
        private void Register(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("funkar");
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }
    }
}