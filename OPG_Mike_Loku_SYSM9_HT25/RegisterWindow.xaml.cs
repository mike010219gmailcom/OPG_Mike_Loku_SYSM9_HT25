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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        // Kod för registreringsknappen
        private void BtnRegister(object sender, RoutedEventArgs e)
        {
            UserManager userManager = (UserManager)Application.Current.Resources["UserManager"];

            // Spara input
            string username = UsernameInput.Text;
            string password = PasswordInput.Text;
            string country = (Country.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Skapa ny användare
            User newUser = new User
            {
                Username = username,
                Password = password,
                Role = "User",
                DisplayName = username
            };

            // Registrera användaren
            bool NewUserSucces = userManager.RegisterUser(newUser);

            if (NewUserSucces)
            {
                MessageBox.Show($"Välkommen {username}!\nDu är nu registrerad.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Användarnamnet används redan, välj ett annat");
            }
                            


        }
    }
}
