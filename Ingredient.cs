using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        private int alcohol;
        private int quantity;
        private string name;
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

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
        public int Alcohol 
        {
            get 
            {
                return this.alcohol;
            }

            private set 
            {
                if (value < 0)
                {
                    return;  
                }

                this.alcohol = value;
            }
        }
        public int Quantity 
        { 
            get => this.quantity;
            private set 
            {
                if (value < 0)
                {
                    return;
                }

                this.quantity = value;
            }        
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Ingredient: {this.Name}")
                .AppendLine($"Quantity: {this.Quantity}")
                .AppendLine($"Alcohol : {this.Alcohol}");
            return sb.ToString().TrimEnd();
                 
        }
    }
}
