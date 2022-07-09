using System;
using System.Collections;
using System.Collections.Generic;
using CookingMinigame;
using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    // [SerializeField]
    // private SpriteRenderer attachedIngredient;

    private CookingMinigameManager cookingMinigameManager;
    private bool isAttached = false;
    
    [SerializeField]
    private GameObject attachedIngredientPrefab;
    private GameObject currentlyAttachedIngridient;
    
    private void Awake()
    {
        cookingMinigameManager = FindObjectOfType<CookingMinigameManager>();
    }

    public void AttachToMouse(FoodType foodType)
    {
        currentlyAttachedIngridient = Instantiate(attachedIngredientPrefab);
        currentlyAttachedIngridient.GetComponent<AttachedIngredient>().Initialize(foodType);
        isAttached = true;
        FindObjectOfType<CookingMinigameSoundPlayer>().PlayPickUpSound();
    }

    private void Update()
    {
        StickIngredientToMouse();

        if (Input.GetMouseButtonUp(0))
        {
            isAttached = false;
        }
    }

    private void StickIngredientToMouse()
    {
        if (!isAttached)
        {
            return;
        }
        
        
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = Camera.main.nearClipPlane;
        currentlyAttachedIngridient.transform.position = position;
    }

    public void Detach()
    {
        isAttached = false;
    }
}
