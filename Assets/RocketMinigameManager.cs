using System.Collections;
using System.Collections.Generic;
using Menu;
using UnityEngine;

public class RocketMinigameManager : MonoBehaviour
{
    [SerializeField] private MinigamesStatus minigamesStatus;
    [SerializeField] private Dialogue welcomeDialogue;
    [SerializeField] private BasicPanel gameOverPanel;
    [SerializeField] private BasicPanel gameWinPanel;
    
    private DialoguePanel dialoguePanel;
    private void Start()
    {
        dialoguePanel = FindObjectOfType<DialoguePanel>();
        
        if (minigamesStatus.GetVisitStatus(SceneType.RocketMinigame))
        {
            StartGame();
        }
        else
        {
            dialoguePanel.LoadDialogue(welcomeDialogue);
        
            dialoguePanel.OnDialogueFinished += () =>
            {
                StartGame();
            };
        
            dialoguePanel.Show();
        }

        minigamesStatus.VisitMinigame(SceneType.RocketMinigame);
        minigamesStatus.CompleteMinigame(SceneType.RocketMinigame);
    }

    private void StartGame()
    {
        foreach (var constantMove in FindObjectsOfType<ConstantMove>())
        {
            constantMove.StartMoving();
        }
    }

    public void StopGame()
    {
        foreach (var constantMove in FindObjectsOfType<ConstantMove>())
        {
            constantMove.StopMoving();
        }
        
        gameOverPanel.Show();
    }

    public void RestartGame()
    {
        FindObjectOfType<SceneTransitionManager>().TransitionToScene(SceneType.RocketMinigame);
    }

    public void WinGame()
    {
        gameWinPanel.Show();
    }
}
