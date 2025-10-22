using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPG_Mike_Loku_SYSM9_HT25.Models;

namespace OPG_Mike_Loku_SYSM9_HT25.Manager
{
    internal class RecipeManager : INotifyPropertyChanged
    {
        private ObservableCollection<RecipeModel> _recipe = new ObservableCollection<RecipeModel>();
        public ObservableCollection<RecipeModel> Recipe
        {
            get => _recipe;
            set
            {
                _recipe = value;
                OnPropertyChanged(nameof(Recipe));
            }
        }

        public void AddRecipe(RecipeModel recipe)
        {
            Recipe.Add(recipe);
        }

        public void RemoveRecipe (RecipeModel recipe)
        {
            Recipe.Remove(recipe);
        }

        public void UpdateRecipe (RecipeModel recipe)
        {
            var existingRecipe = Recipe.FirstOrDefault(r => r.Title == recipe.Title);
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


        public ObservableCollection <RecipeModel> GetRecipes ()
        {
            return Recipe;
        }

        



        private void OnPropertyChanged(string v)
        {
            
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
