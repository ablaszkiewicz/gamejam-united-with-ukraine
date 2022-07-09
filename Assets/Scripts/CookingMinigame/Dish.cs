using System;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMinigame
{
    public class Dish : MonoBehaviour
    {
        [SerializeField] private List<FoodType> ingredients;

        [SerializeField] private string description;
        

        public bool IsThisIngredientCorrect(FoodType foodType)
        {
            var expectedIngredient = ingredients[0];

            if (foodType == expectedIngredient)
            {
                ingredients.RemoveAt(0);
                return true;
            }

            return false;
        }

        public bool IsDishFinished()
        {
            return ingredients.Count == 0;
        }

        public List<FoodType> GetIngredients()
        {
            return ingredients;
        }

        public string GetDescription()
        {
            return description;
        }
    }
}