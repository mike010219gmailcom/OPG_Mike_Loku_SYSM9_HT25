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

        public RecipeModel NewRecipe { get; set; } = new RecipeModel();

        public AddRecipeWindow()
        {
            InitializeComponent();
        }

        private void SaveNewRecipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Skapande av recept avbruten.");
            this.Close();
        }
    }
}
