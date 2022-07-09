using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    
    private void Start()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, 0.5f);
    }

    public void TransitionToScene(SceneType sceneType)
    {
        canvasGroup.DOFade(1, 0.5f).OnComplete(() => SceneManager.LoadScene(sceneType.GetSceneName()));
    }
}
