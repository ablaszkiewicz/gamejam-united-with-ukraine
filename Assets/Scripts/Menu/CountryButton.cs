using System.Collections;
using System.Collections.Generic;
using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountryButton : MonoBehaviour
{
    [SerializeField] private SceneType sceneType;
    [SerializeField] private TextMeshProUGUI sceneCompletionStatusText;

    private MinigamesStatus minigamesStatus;
    private bool isFinised;

    private void Awake()
    {
        minigamesStatus = FindObjectOfType<MenuManager>().MinigamesStatus;
        isFinised = minigamesStatus.GetStatusForScene(sceneType);
        UpdateSceneCompletionStatus();
    }
    
    public void OnCountryButtonClicked()
    {
        SceneManager.LoadScene(sceneType.GetSceneName());
    }

    private void UpdateSceneCompletionStatus()
    {
        sceneCompletionStatusText.text = isFinised ? "Completed" : "Not completed";
    }
}
