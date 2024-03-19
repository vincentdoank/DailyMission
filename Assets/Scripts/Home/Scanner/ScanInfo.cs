using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ScanInfo : MonoBehaviour
{
    public Image background;
    public CanvasGroup contentCanvasGroup;
    public Button closeButton;
    public Button goButton;
    public Image image;
    public TMP_Text titleText;
    public TMP_Text contentText;

    private ScanPlaceInfo info;

    private void Awake()
    {
        closeButton.onClick.AddListener(HideAnimation);
        goButton.onClick.AddListener(Go);
    }

    private void OnEnable()
    {
        ShowAnimation();
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }

    private void Go()
    {
        //kemana?
    }

    private void ShowAnimation()
    {
        ((RectTransform)transform).anchoredPosition = new Vector2(0, -2000);
        ((RectTransform)transform).DOAnchorPosY(0f, 0.2f).SetEase(Ease.OutBack).Play();
        Color color = closeButton.image.color;
        color.a = 0;
        closeButton.image.color = color;
        closeButton.image.DOFade(1f, 0.5f).SetDelay(0.2f).Play();
        Color bgColor = background.color;
        bgColor.a = 0;
        background.color = bgColor;
        background.DOFade(0.9f, 0.5f).SetDelay(0.2f).Play();
        contentCanvasGroup.alpha = 0;
        contentCanvasGroup.DOFade(1f, 0.5f).SetDelay(0.2f).Play();
    }

    private void HideAnimation()
    {
        Color color = closeButton.image.color;
        color.a = 0;
        closeButton.image.color = color;
        closeButton.image.DOFade(1f, 0.5f).SetDelay(0.2f).Play();
        Color bgColor = background.color;
        bgColor.a = 0;
        background.color = bgColor;
        ((RectTransform)transform).DOAnchorPosY(-2000f, 0.2f).OnComplete(Close).Play();
    }
}
