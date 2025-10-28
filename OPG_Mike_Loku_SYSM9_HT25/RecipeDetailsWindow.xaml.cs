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
        private readonly RecipeManager _recipeManager;
        private readonly RecipeModel _recipe;
        private readonly User _currentUser;
        private bool Editing = false;
        public RecipeDetailsWindow(User currentUser, RecipeModel recipe, RecipeManager recipeManager)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _recipe = recipe;
            _recipeManager = recipeManager;
            DataContext = _recipe;
           
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            if (_currentUser.Username != _recipe.CreatedBy && !_currentUser.IsAdmin)

                CategoryBox.IsReadOnly = false;
            TitleBox.IsReadOnly = false;
            IngredientsBox.IsReadOnly = false;
            InstructionsBox.IsReadOnly = false;
            SaveEdits.IsEnabled = true;
            

        }

        private void SaveEdits_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
