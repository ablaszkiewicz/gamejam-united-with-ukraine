using System.Collections;
using System.Collections.Generic;
using CookingMinigame;
using UnityEngine;

public class AttachedIngredient : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    private CookingMinigameManager cookingMinigameManager;
    private FoodType foodType;

    private void Awake()
    {
        cookingMinigameManager = FindObjectOfType<CookingMinigameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Initialize(FoodType foodType)
    {
        spriteRenderer.sprite = cookingMinigameManager.GetSpriteForFoodType(foodType);
        this.foodType = foodType;
    }

    public FoodType GetFoodType()
    {
        return foodType;
    }
}
