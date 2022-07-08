using System;
using System.Collections;
using System.Collections.Generic;
using CookingMinigame;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField]
    private List<Dish> dishes;
    
    private Dish currentDish;
    private CookingMinigameManager cookingMinigameManager;

    private void Awake()
    {
        cookingMinigameManager = FindObjectOfType<CookingMinigameManager>();
        InitializeNextDish();
    }

    private void InitializeNextDish()
    {
        Debug.Log("Initializing next dish");
        
        if (dishes.Count == 0)
        {
            cookingMinigameManager.CompleteMinigameAndExit();
            return;
        }
        currentDish = dishes[0];
        cookingMinigameManager.ShowRecipe(currentDish);
        dishes.RemoveAt(0);
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var ingredient = col.gameObject.GetComponent<AttachedIngredient>().GetFoodType();
        if (!currentDish.IsThisIngredientCorrect(ingredient))
        {
            cookingMinigameManager.ShowGameOverScreen();
        }

        if (currentDish.IsDishFinished())
        {
            InitializeNextDish();
        }
    }
}
