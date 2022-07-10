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


        if (minigamesStatus.GetVisitStatus(SceneType.CookingMinigame))
        {
            pot.InitializeNextDish();
        }
        else
        {
            dialoguePanel.LoadDialogue(welcomeDialogue);
        
            dialoguePanel.OnDialogueFinished += () =>
            {
                pot.InitializeNextDish();
            };
        
            dialoguePanel.Show();
        }
        
        minigamesStatus.VisitMinigame(SceneType.CookingMinigame);
        minigamesStatus.CompleteMinigame(SceneType.CookingMinigame);
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
        food1.sprite = ingredients.Count > 0 ? GetSpriteForFoodType(ingredients[0]) : null;
        food2.sprite = ingredients.Count > 1 ? GetSpriteForFoodType(ingredients[1]) : null;
        food3.sprite = ingredients.Count > 2 ? GetSpriteForFoodType(ingredients[2]) : null;
        food4.sprite = ingredients.Count > 3 ? GetSpriteForFoodType(ingredients[3]) : null;
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
