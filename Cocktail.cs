using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private int capacity;
        private int maxAlcoholLevel;
        private string name;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Ingredients = new HashSet<Ingredient>();
            this.Name = name;
            this.Capacity = capacity; //maximum allowed number of ingredients in the cocktail
            this.MaxAlcoholLevel = maxAlcoholLevel;//maximum allowed amount of alcohol 
        }

        public HashSet<Ingredient> Ingredients { get; private set; }
        public string Name 
        {
            get => this.name;
            private set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    return;
                }

                this.name = value;
            }
        
        }
        public int Capacity 
        {
            get => this.capacity;
            private set 
            {
                if (value < 0)
                {
                    return;
                }

                this.capacity = value;
            }
        }
        public int MaxAlcoholLevel 
        {
            get => this.maxAlcoholLevel;


            private set 
            {
                if (value < 0)
                {
                    return;
                }

                this.maxAlcoholLevel = value;
            }             
        }

        public void Add(Ingredient ingredient) 
        {
            if (!Ingredients.Any(ing =>ing.Name == ingredient.Name))
            {
                if (ingredient.Alcohol + CurrentAlcoholLevel <= MaxAlcoholLevel 
                    && Ingredients.Count <= Capacity)
                {
                    Ingredients.Add(ingredient);
                }
            }                     
        }

        public bool Remove(string name) 
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(ing => ing.Name == name);

            if (ingredient != null)
            {
                Ingredients.Remove(ingredient);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(ing => ing.Name == name);

            if (ingredient == null )
            {
                return null;
            }

            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient() 
        {
            Ingredient ingredient = Ingredients.OrderByDescending(ing => ing.Alcohol).FirstOrDefault();

            if (Ingredients.Count == 0)
            {
                return null;
            }

            if (ingredient != null)
            {
                return ingredient;
            }

            return null;
        }



        public int CurrentAlcoholLevel => CurrAlcoholLevel(Ingredients);
           
        public int CurrAlcoholLevel(HashSet<Ingredient> Ingredients) 
        {
            int sum = 0;

            if (Ingredients.Count == 0)
            {
                return 0;
            }

            foreach (var ingrOject in Ingredients)
            {
                sum += ingrOject.Alcohol;
            }

            return sum;
        }

        public string Report() 
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ing in Ingredients)
            {
                sb.AppendLine(ing.ToString());
            }

             return sb.ToString();
        }
    }
}
