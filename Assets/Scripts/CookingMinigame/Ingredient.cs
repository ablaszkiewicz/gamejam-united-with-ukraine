using System;
using System.Collections;
using System.Collections.Generic;
using CookingMinigame;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private FoodType foodType;
    
    private float initialScale;
    private float scaleFactor = 1f;
    private bool isMouseDown = false;
    private DragDropManager dragDropManager;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        initialScale = transform.localScale.x;
        dragDropManager = FindObjectOfType<DragDropManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * initialScale * scaleFactor, 10 * Time.deltaTime);
    }

    private void OnMouseEnter()
    {
        scaleFactor = 1.5f;
        
    }

    private void OnMouseExit()
    {
        scaleFactor = 1f;

        if (isMouseDown)
        {
            dragDropManager.AttachToMouse(foodType);
        }
        
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
    }
}
