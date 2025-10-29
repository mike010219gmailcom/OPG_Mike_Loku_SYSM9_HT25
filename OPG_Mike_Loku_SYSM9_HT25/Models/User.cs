using System.Collections.ObjectModel;

namespace OPG_Mike_Loku_SYSM9_HT25.Models
{

    // Bas användarklass
    public class User
    {
        public bool IsAdmin { get; set; } = false;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string DisplayName { get; set; }
        public string Country { get; set; }
        public string CurrentUser { get; set; }

        public ObservableCollection<RecipeModel> PersonalRecipes { get; set; } 

        public User()
        {
            PersonalRecipes = new ObservableCollection<RecipeModel>();
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
