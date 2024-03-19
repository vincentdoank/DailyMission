using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Page
{
    public enum PageState
    {
        REGISTER,
        LOGIN,
        TASK,
        LEADERBOARD,
        PHOTOSTREAM,
        PROFILE,
        SCAN
    }

    public PageState state;
    public Action onPageOpened;
    public Action onPageClosed;
}

public class PageStateController : MonoBehaviour
{
    private static Page currentPage;
    private static Dictionary<string, Page> pageDict = new Dictionary<string, Page>();

    public static void RegisterPage(Page.PageState state, Action onPageOpened, Action onPageClosed)
    {
        if (!pageDict.ContainsKey(state.ToString()))
            pageDict.Add(state.ToString(), new Page { state = state, onPageClosed = onPageClosed, onPageOpened = onPageOpened });
        else
        {
            pageDict[state.ToString()].onPageOpened += onPageOpened;
            pageDict[state.ToString()].onPageClosed += onPageClosed;
        }
    }

    public static void SetDefaultPage(Page.PageState state)
    {
        currentPage = pageDict[state.ToString()];
    }

    public static void GoToPage(Page.PageState toPage)
    {
        //currentPage = pageDict[toPage.ToString()];
        //currentPage.onPageOpened?.Invoke();
    }

    public static void GoPrevPage()
    {
        //if (currentPage != null)
        //{
        //    currentPage.onPageClosed?.Invoke();
        //    currentPage = pageDict[currentPage.state.ToString()];
        //    currentPage.onPageOpened?.Invoke();
        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PopupManager.Instance.popupList.Count > 0)
            {
                PopupManager.Instance.RemovePopup();
            }
            else
            {
                GoPrevPage();
            }
        }
    }
}
