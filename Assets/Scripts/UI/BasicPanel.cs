using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BasicPanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    [SerializeField] private Transform modalToAnimateScaleAndPosition;

    private const float ANIMATION_DURATION = 0.2f;
    private bool isShown = true;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        canvasGroup.alpha = 0;
        modalToAnimateScaleAndPosition.localScale = Vector3.one * 0;
    }

    public void Show()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, ANIMATION_DURATION);
        modalToAnimateScaleAndPosition.DOScale(Vector3.one, ANIMATION_DURATION).SetEase(Ease.OutQuint);
    }

    public void Hide()
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.DOFade(0, ANIMATION_DURATION);
        modalToAnimateScaleAndPosition.DOScale(Vector3.one * 0.5f, ANIMATION_DURATION).SetEase(Ease.OutQuint);
    }

    // public void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.P))
    //     {
    //         if (isShown)
    //         {
    //             Debug.Log("HIDING");
    //             Hide();
    //         }
    //         else
    //         {
    //             Debug.Log("SHOWING");
    //             Show();
    //         }
    //
    //         isShown = !isShown;
    //     }
    // }
}
