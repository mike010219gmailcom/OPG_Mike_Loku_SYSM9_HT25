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
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : Window
    {

        // props för att hålla nya detaljer
        private readonly UserManager _userManager;
        public User CurrentUser { get; set; }
        public string NewUsername { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; } 
        public string SelectedCountry { get; set; }

        // konstruktor
        public UserDetails(UserManager userManager)
        {
            InitializeComponent();

            _userManager = userManager;
            CurrentUser = _userManager.CurrentUser;
            DataContext = this;
            
        }

        private void UpdateDetails_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = _userManager.CurrentUser;

            //MessageBox.Show($"Inloggad: {currentUser.DisplayName}");

            // Kontrollera användarnamn
            if (string.IsNullOrWhiteSpace(NewUsername) || NewUsername.Length < 3)
            {
                MessageBox.Show("Användarnamnet måste vara minst 3 tecken");
                return;
            }

            // Kolla om namnet är taget
            if (_userManager.Users.Any(u => u.Username == NewUsername && u != currentUser))
            {
                MessageBox.Show("Användarnamnet är taget");
                return;
            }

            // Kontrollera lösenord
            if (string.IsNullOrWhiteSpace(NewPassword) || NewPassword.Length < 5)
            {
                MessageBox.Show("Lösenordet måste vara minst 5 tecken");
                return;
            }
            // Bekräfta lösenord
            if (NewPassword != ConfirmPassword)
            {
                MessageBox.Show("Lösenorden matchar inte");
                return;
            }

            // Spara valt land
            var selectedCountry = (Country.SelectedItem as ComboBoxItem)?.Content?.ToString();

            // Uppdatera
            currentUser.Username = NewUsername;
            currentUser.Password = NewPassword;
            currentUser.Country = selectedCountry ?? currentUser.Country;
            _userManager.CurrentUser.DisplayName = NewUsername;

            MessageBox.Show("Ändringar sparade");
            Close();
        }

        // Avbryt ändringar
        private void CancelUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ändringar avbrutet");
            this.Close();
        }
    }
}
