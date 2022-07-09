using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CookingMinigame;
using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CookingMinigameManager : MonoBehaviour
{
    [SerializeField] private MinigamesStatus minigamesStatus;
    [SerializeField] private List<FoodTypeSprite> foodTypeSpriteMap;
    [SerializeField] private BasicPanel recipePanel;
    [SerializeField] private BasicPanel gameOverScreen;

    [SerializeField] private TextMeshProUGUI dishDescription;
    [SerializeField] private Image food1;
    [SerializeField] private Image food2;
    [SerializeField] private Image food3;
    [SerializeField] private Image food4;

    [SerializeField] private Dialogue welcomeDialogue;
    private DialoguePanel dialoguePanel;
    private Pot pot;

    private void Start()
    {
        dialoguePanel = FindObjectOfType<DialoguePanel>();
        pot = FindObjectOfType<Pot>();
        
        dialoguePanel.LoadDialogue(welcomeDialogue);
        
        dialoguePanel.OnDialogueFinished += () =>
        {
            pot.InitializeNextDish();
        };
        
        dialoguePanel.Show();
    }
    
    public void CompleteMinigameAndExit()
    {
        minigamesStatus.CompleteMinigame(SceneType.CookingMinigame);
        SceneManager.LoadScene(SceneType.MainMenu.GetSceneName());
    }

    public Sprite GetSpriteForFoodType(FoodType foodType)
    {
        return foodTypeSpriteMap.Where(pair => pair.foodType == foodType).FirstOrDefault().sprite;
    }

    public void ShowRecipe(Dish dish)
    {
        recipePanel.Show();
        var ingredients = dish.GetIngredients();

        dishDescription.text = dish.GetDescription();
        food1.sprite = GetSpriteForFoodType(ingredients[0]);
        food2.sprite = GetSpriteForFoodType(ingredients[1]);
        food3.sprite = GetSpriteForFoodType(ingredients[2]);
        food4.sprite = GetSpriteForFoodType(ingredients[3]);
    }

    public void HideRecipe()
    {
        recipePanel.Hide();
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.Show();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneType.CookingMinigame.GetSceneName());
    }
}

[Serializable]
public class FoodTypeSprite
{
    public FoodType foodType;
    public Sprite sprite;
}
