using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    public Action OnDialogueFinished;

    private CanvasGroup canvasGroup;
    [SerializeField] private Transform modalToAnimateScaleAndPosition;

    [SerializeField] private Transform button;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private Text sentence;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Image personImage;

    private List<SingleDialogue> dialogues;
    private const float ANIMATION_DURATION = 0.2f;
    private Tween currentTextTween;
    
    [SerializeField] private RectTransform rectTransform;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        
        canvasGroup.alpha = 0;
        modalToAnimateScaleAndPosition.localScale = Vector3.one * 0;
    }

    public void LoadDialogue(Dialogue dialogue)
    {
        dialogues = dialogue.GetDialogues();
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        button.localScale = Vector3.one * 0;
        if (dialogues.Count == 0)
        {
            FinishDialogue();
            return;
        }
        
        var currentDialogue = dialogues[0];
        dialogues.RemoveAt(0);
        
        name.text = currentDialogue.name;
        personImage.sprite = currentDialogue.image;
        buttonText.text = currentDialogue.buttonText;
        
        sentence.text = "";
        currentTextTween.Kill();
        currentTextTween = sentence.DOText(currentDialogue.sentence, currentDialogue.sentence.Length / 32.0f).SetEase(Ease.Linear);
        currentTextTween.onComplete = () => button.DOScale(Vector3.one, ANIMATION_DURATION).SetEase(Ease.OutQuint);
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }

    private void FinishDialogue()
    {
        if (OnDialogueFinished != null && OnDialogueFinished.GetInvocationList().Length != 0)
        {
            OnDialogueFinished.Invoke();
        }
        
        Hide();
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
}