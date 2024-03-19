using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScanPlaceInfo
{
    public string spriteUrl;
    public string placeName;
}

public class CameraScan : UIController
{
    public CameraScanView cameraScanView;

    protected override void Awake()
    {
        base.Awake();
        PageStateController.RegisterPage(Page.PageState.SCAN, null, null);
    }

    private void OnEnable()
    {
        Show();
    }

    protected override void Init()
    {
        base.Init();
        cameraScanView = (CameraScanView)view;
        cameraScanView.SetHideUIButtonEvent(HideUI);
    }

    public override void Show()
    {
        base.Show();
        cameraScanView.ShowContent();
    }

    private void HideUI()
    {
        Debug.Log("hide ui");
        cameraScanView.HideContent(null);
    }

    public void SetGuideText(string content)
    {
        cameraScanView.SetGuideText(content);
    }
}
