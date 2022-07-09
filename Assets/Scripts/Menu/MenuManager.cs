using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Menu;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private MinigamesStatus minigamesStatus;
    [SerializeField] private List<Dialogue> dialogues;
    
    private DialoguePanel dialoguePanel;
    private List<CountryButton> countryButtons;

    public MinigamesStatus MinigamesStatus
    {
        get { return minigamesStatus; }
    }

    private void Start()
    {
        dialoguePanel = FindObjectOfType<DialoguePanel>();
        countryButtons = FindObjectsOfType<CountryButton>().ToList();
        
        ChooseDialogForCurrentProgress();
        HighlightProperButtons();
    }

    private void ChooseDialogForCurrentProgress()
    {
        var progress = minigamesStatus.GetNumberOfCompletedScenes();
        dialoguePanel.LoadDialogue(dialogues[progress]);
        dialoguePanel.Show();
    }

    private void HighlightProperButtons()
    {
        foreach (var countryButton in countryButtons)
        {
            countryButton.MarkUnavailable();
        }

        var completedScenes = minigamesStatus.GetCompletedScenes();

        var completedScenesButtons = countryButtons.Where(button => completedScenes.Contains(button.SceneType)).ToList();
        foreach (var completedScenesButton in completedScenesButtons)
        {
            completedScenesButton.MarkCompleted();
        }

        var nextScene = minigamesStatus.GetFirstNotCompletedScene();
        var nextSceneButton = countryButtons.Where(button => button.SceneType == nextScene).FirstOrDefault();
        nextSceneButton.MarkNextTask();
    }
}
