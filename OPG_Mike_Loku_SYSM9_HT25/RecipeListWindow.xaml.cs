using OPG_Mike_Loku_SYSM9_HT25.Manager;
using OPG_Mike_Loku_SYSM9_HT25.Models;
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

namespace OPG_Mike_Loku_SYSM9_HT25
{
    /// <summary>
    /// Interaction logic for RecipeListWindow.xaml
    /// </summary>
    /// 

    // Huvudfönstret som visar receptlistan och hanterar användarinteraktioner
    public partial class RecipeListWindow : Window
    {
        // Referenser till UserManager och RecipeManager
        public UserManager userManager { get; set; }
        public RecipeManager recipeManager { get; set; }
        public RecipeListWindow()
        {
            // Hämta manager-instanser från applikationsresurser
            InitializeComponent();
            userManager = (UserManager)Application.Current.Resources["UserManager"];
            recipeManager = (RecipeManager)Application.Current.Resources["RecipeManager"];
            DataContext = userManager;
        }

        // Hantera klick på knapparna
        private void UserDetails_Click(object sender, RoutedEventArgs e)
        {
            UserDetails userDetails = new UserDetails(userManager);
            userDetails.Show();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(recipeManager, userManager.CurrentUser);
            addRecipeWindow.Show();
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeList.SelectedItem is RecipeModel selectedRecipe)
            {
                RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(userManager.CurrentUser, selectedRecipe, recipeManager);
                recipeDetailsWindow.Show();
            }
            else
            {
                MessageBox.Show("Fel, välj ett recept från listan.");
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
