using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraScanView : UIScreen
{
    [SerializeField] private CanvasGroup containerCanvasGroup;
    [SerializeField] private CanvasGroup introGuideCanvasGroup;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private TMP_Text guideText;
    [SerializeField] private Button routeButton;
    [SerializeField] private Button hideUIButton;

    public void SetRouteButtonEvent(Action action)
    {
        routeButton.onClick.AddListener(action.Invoke);
    }

    public void SetHideUIButtonEvent(Action action)
    {
        hideUIButton.onClick.AddListener(action.Invoke);
    }

    public void SetGuideText(string content)
    {
        guideText.text = content;
        guideText.transform.parent.gameObject.SetActive(true);
        guideText.transform.parent.localScale = Vector3.zero;
        guideText.transform.DOScale(1f, 0.2f).Play();
    }

    public void ShowContent()
    {
        Debug.Log("show content");
        containerCanvasGroup.alpha = 0f;
        introGuideCanvasGroup.alpha = 0f;
        containerCanvasGroup.gameObject.SetActive(true);
        ((RectTransform)containerCanvasGroup.transform).anchoredPosition = new Vector2(0f, -200f);
        ((RectTransform)containerCanvasGroup.transform).DOAnchorPosY(0f, 0.2f).SetEase(Ease.OutCirc).Play();
        containerCanvasGroup.DOFade(1f, 0.5f).SetDelay(0.1f).Play();
        introGuideCanvasGroup.DOFade(1f, 0.2f).SetDelay(0.3f).Play();
    }

    public void HideContent(Action onComplete)
    {
        Debug.Log("hide content");
        introGuideCanvasGroup.DOFade(0f, 0.2f).Play();
        containerCanvasGroup.DOFade(0f, 0.2f).SetDelay(0.1f).OnComplete(() => { onComplete?.Invoke(); containerCanvasGroup.gameObject.SetActive(false); }).Play();
    }
}
