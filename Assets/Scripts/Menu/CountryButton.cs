using System.Collections;
using System.Collections.Generic;
using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountryButton : MonoBehaviour
{
    [SerializeField] private SceneType sceneType;
    [SerializeField] private TextMeshProUGUI sceneCompletionStatusText;
    private Button button;

    private MinigamesStatus minigamesStatus;
    private bool isFinised;

    public SceneType SceneType
    {
        get { return sceneType; }
    }
    
    private void Awake()
    {
        minigamesStatus = FindObjectOfType<MenuManager>().MinigamesStatus;
        button = GetComponentInChildren<Button>();
        isFinised = minigamesStatus.GetStatusForScene(sceneType);
        UpdateSceneCompletionStatus();
    }
    
    public void OnCountryButtonClicked()
    {
        FindObjectOfType<SceneTransitionManager>().TransitionToScene(sceneType);
    }

    private void UpdateSceneCompletionStatus()
    {
        sceneCompletionStatusText.text = isFinised ? "Completed" : "Not completed";
    }

    public void MarkUnavailable()
    {
        button.interactable = false;
        Debug.Log("Unavailable");
    }


    public void MarkCompleted()
    {
        button.interactable = false;
        Debug.Log("Completed");

    }

    public void MarkNextTask()
    {
        button.interactable = true;
        Debug.Log("Next task");
    }
}
