using OPG_Mike_Loku_SYSM9_HT25.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace OPG_Mike_Loku_SYSM9_HT25.Manager
{
    // Hanterar recept
    public class RecipeManager : INotifyPropertyChanged
    {
        // Privat lista över recept
        private ObservableCollection<RecipeModel> _recipe = new ObservableCollection<RecipeModel>();
        // Offentlig egenskap för att komma åt receptlistan
        public ObservableCollection<RecipeModel> Recipe
        {
            get => _recipe;
            set
            {
                _recipe = value;
                OnPropertyChanged(nameof(Recipe));
            }
        }

        // Hämta recept från alla användare om admin, annars bara för inloggad användare
        public ObservableCollection<RecipeModel> GetREcipesAllUsers(User user, List<User> allUsers)
        {
            if (user.IsAdmin)
            {
                var allRecipes = new ObservableCollection<RecipeModel>();
                foreach (var u in allUsers)
                {
                    foreach (var r in u.PersonalRecipes)
                    {
                        allRecipes.Add(r);
                    }
                }
                return allRecipes;
            }
            else
            {
                return user.PersonalRecipes;
            }
        }
            
            

        public RecipeManager()
        {
            //Hämta usermanager/currentuser 
            //currentUser.recipelist = Recipe
        }

        // Metoder för att lägga till, ta bort och uppdatera recept
        public void AddRecipe(RecipeModel recipe)
        {
            Recipe.Add(recipe);

            OnPropertyChanged(nameof(Recipe));
        }

        public void RemoveRecipe(RecipeModel recipe, User currentUser)
        {
            if (currentUser.IsAdmin || recipe.CreatedBy == currentUser.Username)
            {
                Recipe.Remove(recipe);
                OnPropertyChanged(nameof(Recipe));
            }
            else
            {
                MessageBox.Show("Endast skaparen eller admin kan ta bort receptet.");
            }
        }

        public void UpdateRecipe(RecipeModel recipe)
        {
            // Hitta det befintliga receptet baserat på titeln. DVS om titeln redan finns, uppdatera det receptet.
            var existingRecipe = Recipe.FirstOrDefault(r => r.Title == recipe.Title);

            // Om receptet finns, uppdatera dess egenskaper
            if (existingRecipe != null)
            {
                existingRecipe.Ingredients = recipe.Ingredients;
                existingRecipe.Instructions = recipe.Instructions;
                existingRecipe.Category = recipe.Category;
                existingRecipe.Date = recipe.Date;
                existingRecipe.CreatedBy = recipe.CreatedBy;
                OnPropertyChanged(nameof(Recipe));
            }
        }

        // Hämta recept baserat på användarroll
        public ObservableCollection<RecipeModel> GetRecipes(User user)
        {
            if (user.IsAdmin)
            {
                return Recipe;
            }
            else
            {
                var userRecipes = new ObservableCollection<RecipeModel>(Recipe.Where(r => r.CreatedBy == user.Username));
                return userRecipes;
            }
        }




        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
