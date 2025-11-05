using OPG_Mike_Loku_SYSM9_HT25.Manager;
using OPG_Mike_Loku_SYSM9_HT25.Models;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace OPG_Mike_Loku_SYSM9_HT25
{
    /// <summary>
    /// Interaction logic for RecipeListWindow.xaml
    /// </summary>
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
            InitializeComponent();

            userManager = (UserManager)Application.Current.Resources["UserManager"];
            recipeManager = (RecipeManager)Application.Current.Resources["RecipeManager"];

            DataContext = userManager.CurrentUser;
            CurrentUser = userManager.CurrentUser;

            // For admin, the manager's master list should already be populated at login.
            // Show manager's list for admins, otherwise show current user's personal recipes.
            if (userManager.CurrentUser.IsAdmin)
            {
                RecipeList.ItemsSource = recipeManager.Recipe; // bind admin view to manager's list
            }
            else
            {
                RecipeList.ItemsSource = userManager.CurrentUser.PersonalRecipes;
            }
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
                // Kontrollera om den inloggade användaren är skaparen eller admin
                if (userManager.CurrentUser.Username != selectedRecipe.CreatedBy && !userManager.CurrentUser.IsAdmin)
                {
                    MessageBox.Show("Endast skaparen eller en administratör kan ta bort detta recept.");
                    return;
                }

                var result = MessageBox.Show("Är du säker?", "Bekräfta borttagning", MessageBoxButton.YesNo);
                if (result != MessageBoxResult.Yes)
                    return;

                // Om admin, ta bort från huvudlistan och ägarens lista
                if (userManager.CurrentUser.IsAdmin)
                {
                    // Tar bort från huvudlistan
                    recipeManager.RemoveRecipe(selectedRecipe, userManager.CurrentUser);

                    // Tar bort från ägarens personliga receptlista
                    var owner = userManager.Users?.FirstOrDefault(u => u.Username == selectedRecipe.CreatedBy);
                    if (owner != null && owner.PersonalRecipes.Contains(selectedRecipe))
                    {
                        owner.PersonalRecipes.Remove(selectedRecipe);
                    }

                    // uppdatera listan
                    RecipeList.ItemsSource = recipeManager.Recipe;
                }
                else
                {
                    // Tar bort från den inloggade användarens personliga receptlista
                    if (userManager.CurrentUser.PersonalRecipes.Contains(selectedRecipe))
                    {
                        userManager.CurrentUser.PersonalRecipes.Remove(selectedRecipe);
                    }
                    recipeManager.RemoveRecipe(selectedRecipe, userManager.CurrentUser);

                    RecipeList.ItemsSource = userManager.CurrentUser.PersonalRecipes;
                }

                MessageBox.Show("Receptet har tagits bort.");
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

        // Info knapp
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Välkommen till CookMaster!\n" +
                "I denna app kan du skapa och spara recept eneklt\n" +
                "Välj ett recpt i listan och tryck på en av knapparna.\n" +
                "Du kan också lägga till dina egna recept.\n" +
                "CookMaster startades av amatörkockar som ville ha en plats att spara sina recept på.\n" +
                "Nu finns denna möjligheten tillgänglig för alla!\n" +
                "/ CookMaster familjen");
        }
    }
}
    