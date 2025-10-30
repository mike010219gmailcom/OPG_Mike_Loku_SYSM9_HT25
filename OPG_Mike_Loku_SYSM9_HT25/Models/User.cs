using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OPG_Mike_Loku_SYSM9_HT25.Models
{

    // Bas användarklass
    public class User : INotifyPropertyChanged
    {
        public bool IsAdmin { get; set; } = false;
        private string _username;

        // För några av propsen används OnPropertyChanged för att notifiera UI om ändringar
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Role { get; set; }

        private string _displayName;
        public string DisplayName
        {
            get => _displayName;
            set
            {
                _displayName = value;
                OnPropertyChanged(nameof(DisplayName));
            }
        }
        
        private string _country;
        public string Country
        {
            get => _country;
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }
        public string CurrentUser { get; set; }

        public ObservableCollection<RecipeModel> PersonalRecipes { get; set; } 

        public User()
        {
            PersonalRecipes = new ObservableCollection<RecipeModel>();

            PersonalRecipes.Add(new RecipeModel
            {
                Title = "Spaghetti & Köttfärssås",
                Ingredients = "Spaghetti, Köttfärs, tomatsås, vitlök, olja, salt, pepper",
                Instructions = "1. Koka Spaghetti.\n" +
                                   "2. Stek köttfärs med vitlök i olja.\n" +
                                   "3. Tillsätt tomatsås och kryddor.\n" +
                                   "4. Servera köttfärssås över Spaghetti.",
                Category = "Middag",
                CreatedBy = Username,
                Date = DateTime.Now,
            });
            PersonalRecipes.Add(new RecipeModel
            {
                Title = "Pankakor",
                Ingredients = " Mjöl, ägg, mjölk, smör, socker, salt",
                Instructions = "1. Blanda mjöl, ägg, mjölk, socker och salt.\n" +
                                   "2. Värm stekpanna med smör.\n" +
                                   "3. Häll i smet och stek.\n" +
                                   "4. Servera med sylt eller bär.",
                Category = "Frukost",
                CreatedBy = Username,
                Date = DateTime.Now,
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Admin klass som ärver från User
    public class Admin : User
    {
        public Admin()
        {
            IsAdmin = true;
        }
    }
}
