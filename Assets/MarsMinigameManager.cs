using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsMinigameManager : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    [SerializeField]
    private BasicPanel gameOverPanel;
    
    private DialoguePanel dialoguePanel;
    

    private void Start()
    {
        dialoguePanel = FindObjectOfType<DialoguePanel>();
        
        dialoguePanel.LoadDialogue(dialogue);
        dialoguePanel.Show();
        dialoguePanel.OnDialogueFinished += gameOverPanel.Show;
    }
}
