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
    /// Interaction logic for RecipeDetailsWindow.xaml
    /// </summary>
    public partial class RecipeDetailsWindow : Window
    {
        // Referenser till RecipeManager, receptet och nuvarande användare
        // bool för att kontrollera redigering
        private readonly RecipeManager _recipeManager;
        private readonly RecipeModel _recipe;
        private readonly User _currentUser;
        private bool Editing = false;

        // Konstruktor
        public RecipeDetailsWindow(User currentUser, RecipeModel recipe, RecipeManager recipeManager)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _recipe = recipe;
            _recipeManager = recipeManager;
            DataContext = _recipe;
           
        }

        // Kod för redigera knappen
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // Kontrollera om användaren är skaparen eller en administratör
            if (_currentUser.Username != _recipe.CreatedBy && !_currentUser.IsAdmin)
            {
                MessageBox.Show("Endast skaparen eller en administratör kan redigera detta recept.");
                return;
            }
            else
            {
                Editing = true;
            }
            // Aktivera redigeringsläge
            CategoryBox.IsReadOnly = false;
            TitleBox.IsReadOnly = false;
            IngredientsBox.IsReadOnly = false;
            InstructionsBox.IsReadOnly = false;
            SaveEdits.IsEnabled = true;

            Edit.Visibility = Visibility.Collapsed;
            SaveEdits.IsEnabled = true;


        }

        private void SaveEdits_Click(object sender, RoutedEventArgs e)
        {
            // Kontrollera input
            if (string.IsNullOrWhiteSpace(TitleBox.Text) || string.IsNullOrWhiteSpace(IngredientsBox.Text)
                || string.IsNullOrWhiteSpace(CategoryBox.Text) || string.IsNullOrWhiteSpace(IngredientsBox.Text))
            {
                MessageBox.Show("Du måste ange Titel, Ingredienser, Instruktioner och Kategori");
                return;
            }

            // Spara ändringarna
            _recipe.Title = TitleBox.Text;
            _recipe.Ingredients = IngredientsBox.Text;
            _recipe.Instructions = InstructionsBox.Text;
            _recipe.Category = CategoryBox.Text;
            _recipe.Date = DateTime.Now;
            _recipeManager.UpdateRecipe(_recipe);

            MessageBox.Show("Receptet har uppdaterats");
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
