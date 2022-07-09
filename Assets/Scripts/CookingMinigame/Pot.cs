using System;
using System.Collections;
using System.Collections.Generic;
using CookingMinigame;
using DG.Tweening;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField]
    private List<Dish> dishes;
    
    private Dish currentDish;
    private CookingMinigameManager cookingMinigameManager;


    private const float ANIMATION_STRENGTH = 0.2f;
    private const float ANIMATION_DURATION = 0.5f;

    private void Awake()
    {
        cookingMinigameManager = FindObjectOfType<CookingMinigameManager>();
    }
    

    public void InitializeNextDish()
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
        

        transform.DOPunchScale(Vector3.one * ANIMATION_STRENGTH, ANIMATION_DURATION);

        if (currentDish.IsDishFinished())
        {
            InitializeNextDish();
        }
    }
}
