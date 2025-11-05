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
using OPG_Mike_Loku_SYSM9_HT25.Manager;
using OPG_Mike_Loku_SYSM9_HT25.Models;

namespace OPG_Mike_Loku_SYSM9_HT25
{
    /// <summary>
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        // Attribut för att hålla det nya receptet
        public RecipeModel NewRecipe { get; set; } = new RecipeModel();

        // Referenser till RecipeManager och nuvarande användare
        private readonly RecipeManager _recipeManager;
        private readonly User _currentUser;

        // Konstruktor
        public AddRecipeWindow(RecipeManager recipeManager, User currentUser)
        {
            InitializeComponent();
            _recipeManager = recipeManager;
            _currentUser = currentUser;

            DataContext = this;
        }

        // Kod för knappen
        private void SaveNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Validering av inmatning
            if (string.IsNullOrWhiteSpace(NewRecipe.Title) || string.IsNullOrWhiteSpace(NewRecipe.Ingredients)
                || string.IsNullOrWhiteSpace(NewRecipe.Category))
            {
                MessageBox.Show("Du måste ange Titel, Ingredienser och Kategori");
            }
            else
            {
                // Lägg till det nya receptet
                NewRecipe.CreatedBy = _currentUser.Username;
                NewRecipe.Date = DateTime.Now;
                _currentUser.PersonalRecipes.Add(NewRecipe);
                MessageBox.Show("Nytt recept tillagt!");
                this.Close();
            }
        }

        // Kod för avbryt knappen
        private void CancelAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Skapande av recept avbruten.");
            this.Close();
        }
    }
}
