using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class HomePage : UIController, IPointerDownHandler, IPointerUpHandler
{
    private HomePageView homePageView;

    private Tween slideTween;
    private Vector2 firstTouchPos;
    private RectTransform homeRectTransform;
    private bool isShowMenu;

    public float menuSlideTolerance = 5f;

    public static HomePage Instance { get; private set; }

    protected override void Awake()
    {
        Instance = this;
        base.Awake();
        homePageView = (HomePageView)view;

        homePageView.SetTaskToggle(ShowTask);
        homePageView.SetLeaderboardToggle(ShowLeaderboard);
        homePageView.SetPhotostreamToggle(ShowPhotostream);
        homePageView.SetProfileToggle(ShowProfile);

        homeRectTransform = (RectTransform)transform;

        //homePageView.SetMap2dToggle(Show2DMap);
        //homePageView.SetLibraryToggle(ShowLibrary);
        //homePageView.SetScannerToggle(ShowScanCamera);
        //homePageView.SetProfileToggle(ShowProfile);
    }

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        //LoadingManager.Instance.HideBottomLoading();
    }

    //public void DoAction(string functionName)
    //{
    //    Invoke(functionName, 0f);
    //}

    private void Update()
    {
        
    }

    private void SlideLeft()
    {
        Debug.Log("move left");
        homeRectTransform.DOAnchorPosX(0, 0.2f).Play();
        isShowMenu = false;
    }

    private void SlideRight()
    {
        Debug.Log("move right");
        homeRectTransform.DOAnchorPosX(500, 0.2f).Play();
        isShowMenu = true;
    }

    public void ToggleShowMenu()
    {
        if (isShowMenu)
        {
            SlideLeft();
        }
        else
        {
            SlideRight();
        }
    }

    public void ShowTask(bool value)
    {
        homePageView.ShowTask(value);
    }

    public void ShowLeaderboard(bool value)
    {
        homePageView.ShowLeaderboard(value);
    }

    public void ShowPhotostream(bool value)
    {
        homePageView.ShowPhotostream(value);
    }

    public void ShowProfile(bool value)
    {
        homePageView.ShowProfile(value);
    }

    //public void SetHeader(string title, Action onBackButtonClicked, ButtonInfo buttonInfo1, ButtonInfo buttonInfo2)
    //{
    //    homePageView.SetHeader(title, onBackButtonClicked, buttonInfo1, buttonInfo2);
    //}

    public void SetHeader(string title, Sprite icon, Action onBackButtonClicked)
    {
       // homePageView.SetHeader(title, onBackButtonClicked);
    }

    public Header GetHeader()
    {
        return homePageView.header;
    }

    public void OpenNotification()
    {
        
    }

    public void OpenSearch()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("release : " + eventData.position);

        if (eventData.position.x > firstTouchPos.x + menuSlideTolerance)
        {
            SlideRight();
        }
        else if (eventData.position.x < firstTouchPos.x - menuSlideTolerance)
        {
            SlideLeft();
        }
    }

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    Debug.Log("release : " + eventData.position);

    //    if (eventData.position.x > firstTouchPos.x + menuSlideTolerance)
    //    {
    //        SlideRight();
    //    }
    //    else if (eventData.position.x < firstTouchPos.x - menuSlideTolerance)
    //    {
    //        SlideLeft();
    //    }
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("touch : " + eventData.position);
        firstTouchPos = eventData.position;
    }
}
