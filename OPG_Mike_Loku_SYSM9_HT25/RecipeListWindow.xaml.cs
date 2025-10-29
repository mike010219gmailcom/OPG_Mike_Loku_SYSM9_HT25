using OPG_Mike_Loku_SYSM9_HT25.Manager;
using OPG_Mike_Loku_SYSM9_HT25.Models;
using System.ComponentModel;
using System.Windows;

namespace OPG_Mike_Loku_SYSM9_HT25
{
    /// <summary>
    /// Interaction logic for RecipeListWindow.xaml
    /// </summary>
    /// 

    // Huvudfönstret som visar receptlistan och hanterar användarinteraktioner
    public partial class RecipeListWindow : Window, INotifyPropertyChanged
    {
        // Referenser till UserManager och RecipeManager
        public UserManager userManager { get; set; }
        public RecipeManager recipeManager { get; set; }

        public User CurrentUser
        {
            get => userManager.CurrentUser;
            set
            {
                userManager.CurrentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public RecipeListWindow()
        {
            // Hämta manager-instanser från applikationsresurser
            InitializeComponent();
            userManager = (UserManager)Application.Current.Resources["UserManager"];
            recipeManager = (RecipeManager)Application.Current.Resources["RecipeManager"];
            DataContext = this;


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
            // Kontrollera om ett recept är valt
            if (RecipeList.SelectedItem is RecipeModel selectedRecipe)
            {
                // Kontrollera om användaren är skaparen eller admin
                if (userManager.CurrentUser.Username != selectedRecipe.CreatedBy && !userManager.CurrentUser.IsAdmin)
                {
                    MessageBox.Show("Endast skaparen eller en administratör kan ta bort detta recept.");
                    return;
                }
                // Bekräfta borttagning
                var result = MessageBox.Show("Är du säker?", "Bekräfta borttagning", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    recipeManager.RemoveRecipe(selectedRecipe, userManager.CurrentUser);
                    MessageBox.Show("Receptet har tagits bort.");
                }
            }
            else
            {
                MessageBox.Show("Fel, välj ett recept från listan.");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
