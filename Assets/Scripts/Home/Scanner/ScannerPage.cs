using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class ScannerPage : UIController
{
    private ScannerPageView scannerPageView;
    public static ScannerPage Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Init()
    {
        base.Init();
        scannerPageView = (ScannerPageView)view;
    }

    private void Start()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        //ShowLoading(true);
        ShowLocationSelection(false);
        ShowCameraScan(false);
    }

    public void ShowLoading(bool value)
    {
        scannerPageView.ShowLoading(value);
    }

    public void ShowLocationSelection(bool value)
    {
        scannerPageView.ShowLocationSelection(value);
    }

    public void ShowCameraScan(bool value)
    {
        scannerPageView.ShowCameraScan(value);
    }
}
