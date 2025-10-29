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

            new RecipeModel
            {
                Title = "Spaghetti & Köttfärssås",
                Ingredients = "Spaghetti, Köttfärs, tomatsås, vitlök, olja, salt, pepper",
                Instructions = "1. Koka Spaghetti.\n" +
                                   "2. Stek köttfärs med vitlök i olja.\n" +
                                   "3. Tillsätt tomatsås och kryddor.\n" +
                                   "4. Servera köttfärssås över Spaghetti.",
                Category = "Middag",
                Date = DateTime.Now,
            };
            new RecipeModel
            {
                Title = "Pankakor",
                Ingredients = " Mjöl, ägg, mjölk, smör, socker, salt",
                Instructions = "1. Blanda mjöl, ägg, mjölk, socker och salt.\n" +
                                   "2. Värm stekpanna med smör.\n" +
                                   "3. Häll i smet och stek.\n" +
                                   "4. Servera med sylt eller bär.",
                Category = "Frukost",
                Date = DateTime.Now,
            };
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
