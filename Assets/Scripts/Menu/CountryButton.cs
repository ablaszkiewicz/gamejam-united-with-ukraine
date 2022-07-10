using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    private MenuManager menuManager;
    private CountryType countryType;

    private SpriteRenderer spriteRenderer;

    public SceneType SceneType
    {
        get { return sceneType; }
    }
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        menuManager = FindObjectOfType<MenuManager>();
        minigamesStatus = FindObjectOfType<MenuManager>().MinigamesStatus;
        button = GetComponentInChildren<Button>();
    }
    
    public void OnCountryButtonClicked()
    {
        
    }

    public void MarkUnavailable()
    {
        countryType = CountryType.NOT_AVAILABLE;
        spriteRenderer.color = Color.gray;
    }


    public void MarkCompleted()
    {
        countryType = CountryType.FINISHED;
        
        spriteRenderer.color = Color.gray;
    }

    public void MarkNextTask()
    {
        countryType = CountryType.PENDING;
        spriteRenderer.color = Color.gray;
        spriteRenderer.DOColor(Color.yellow, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnMouseDrag()
    {
        if (countryType == CountryType.PENDING)
        {
            FindObjectOfType<SceneTransitionManager>().TransitionToScene(sceneType);
        }
    }

    private void OnMouseOver()
    {
        if (countryType == CountryType.PENDING)
        {
            spriteRenderer.DOKill();
            spriteRenderer.color = Color.green;
        }
    }
    
    private void OnMouseExit()
    {
        if (countryType == CountryType.PENDING)
        {
            MarkNextTask();
        }
    }
}

enum CountryType
{
    FINISHED,
    PENDING,
    NOT_AVAILABLE,
}
