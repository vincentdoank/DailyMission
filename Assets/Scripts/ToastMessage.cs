using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class ToastMessage : MonoBehaviour
{
    public float displayDuration = 3f;
    public CanvasGroup panelContainer;
    public TMP_Text targetMessageText;

    private RectTransform rectTransform;
    private bool isShowing = false;
    public static ToastMessage Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public void ShowMessage(string content)
    {
        if (!isShowing)
        {
            isShowing = true;
            targetMessageText.text = content;
            panelContainer.gameObject.SetActive(true);
            panelContainer.alpha = 0f;
            panelContainer.DOFade(1f, 0.2f).Play();
            if (!rectTransform) rectTransform = (RectTransform)panelContainer.transform;
            rectTransform.anchoredPosition = new Vector2(0, -600);
            rectTransform.DOAnchorPosY(-350, 0.2f).Play();
            StartCoroutine(WaitToHide());
        }
    }

    private IEnumerator WaitToHide()
    {
        yield return new WaitForSeconds(displayDuration);
        panelContainer.DOFade(0f, 0.3f).OnComplete(HideMessage).Play();
    }

    public void HideMessage()
    {
        panelContainer.gameObject.SetActive(false);
        isShowing = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowMessage("Ini test message");
        }
    }
}
