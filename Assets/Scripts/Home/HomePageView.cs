using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.IO;

[Serializable]
public class DefaultButton
{
    public string name;
    public Sprite sprite;
}


[Serializable]
public class LocationItemList
{
    public LocationItem[] locationList;
}

[Serializable]
public class LocationItem
{
    public string id;
    public string name;
    public MenuItem[] subMenus;
}

[Serializable]
public class ImageUrl
{
    public string id;
    public string url;
}

[Serializable]
public class MenuItemList
{
    public MenuItem[] menuList;
    public ImageUrl[] imageUrlList;
    public string backButtonSpriteUrl;
    public TitleList[] titleList;
}

[Serializable]
public class MenuItem
{
    public string id;
    public string name;
    public string spriteUrl;
    public string functionName;
    public MenuItem[] subMenus;
    public bool backButton;


    public Sprite sprite;
}

[Serializable]
public class TitleList
{
    public string id;
    public string title;
}


[Serializable]
public class Header
{
    public Button backButton; 
    public TMP_Text titleText;
    public Image titleImage;

    public List<DefaultButton> defaultSpriteList;

    private List<MenuItem> menuList;

    public Sprite GetSprite(string spriteName)
    {
        Sprite sprite = defaultSpriteList.Where(x => x.name == spriteName).Select(x => x.sprite).FirstOrDefault();
        return sprite;
    }
}

public class HomePageView : UIScreen
{
    [SerializeField] private TaskPage task;
    [SerializeField] private LeaderboardPage leaderboard;
    [SerializeField] private PhotoStreamPage photostream;
    [SerializeField] private Profile profile;
    [SerializeField] private ScannerPage scanner;

    [SerializeField] private Toggle taskToggle;
    [SerializeField] private Toggle leaderboardToggle;
    [SerializeField] private Toggle photostreamToggle;
    [SerializeField] private Toggle profileToggle;

    public Header header;

    public MenuItem[] menus;
    public LocationItem[] locations;
    public Button huntEventButton;
    public GameObject huntPanelObj;

    private Dictionary<string, Sprite> itemSpriteDict = new Dictionary<string, Sprite>();
    private Dictionary<string, string> itemActionDict = new Dictionary<string, string>();

    public static HomePageView Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        LoadMenu();
        huntEventButton.onClick.AddListener(ShowHuntEvent);
    }

    private void ShowHuntEvent()
    {
        huntPanelObj.SetActive(true);
    }

    private void LoadMenu()
    {
        //LoadMenuJson();
        //LoadLocationJson();
    }

    //private void LoadMenuJson()
    //{
    //    API.GetMenuFromLocalJson<MenuItemList>("menu", x => StartCoroutine(OnSuccess(x)));
    //    IEnumerator OnSuccess(MenuItemList itemList)
    //    {
    //        menus = itemList.menuList;

    //        Dictionary<string, Toggle> toggleDict = new Dictionary<string, Toggle>();
    //        foreach (MenuItem item in menus)
    //        {
    //            Toggle toggle = Instantiate(togglePrefab, toggleParent, false);
    //            toggle.group = toggleParent.GetComponent<ToggleGroup>();
    //            toggle.onValueChanged.AddListener((toggle) => { if (toggle) Invoke(item.functionName, 0f); });
    //            int index = Array.FindIndex(menus, x => x == item);
    //            if (index == 0) toggle.isOn = true;
    //            else toggle.isOn = false;
    //            MenuItemUI itemUI = toggle.GetComponent<MenuItemUI>();
    //            itemUI?.Set(null, item.name);
    //            toggleDict.Add(item.id, toggle);
    //            Debug.Log("submenus : " + item.subMenus + " " + item.name);
    //            if (item.subMenus != null)
    //            {
    //                foreach (MenuItem subItem in item.subMenus)
    //                {
    //                    if (!itemActionDict.ContainsKey(subItem.id))
    //                    {
    //                        itemActionDict.Add(subItem.id, subItem.functionName);
    //                        Debug.Log("add function : " + subItem.id + " " + subItem.functionName);
    //                    }
    //                }
    //            }
    //        }

    //        foreach (ImageUrl imageUrl in itemList.imageUrlList)
    //        {
    //            yield return Utils.GetSprite(imageUrl.url, Consts.PICTURES_FOLDER_NAME + Consts.IMAGE_NAME, imageUrl.id, OnSuccess);
    //            void OnSuccess(Sprite sprite)
    //            {
    //                Debug.Log("success add : " + imageUrl.id);
    //                itemSpriteDict.Add(imageUrl.id, sprite);
    //            }
    //        }

    //        foreach (KeyValuePair<string, Toggle> kvp in toggleDict)
    //        {
    //            MenuItemUI itemUI = kvp.Value.GetComponent<MenuItemUI>();
    //            itemUI?.Set(itemSpriteDict[kvp.Key]);
    //        }
    //    }
    //}

    private void LoadLocationJson()
    {
        //API.GetMenuFromLocalJson<LocationItemList>("locations", x => StartCoroutine(OnSuccess(x)));
       // IEnumerator OnSuccess(LocationItemList locationList)
        {
            //locations = locationList.locationList;

            //foreach (LocationItem item in locations)
            //{
            //    if (item.subMenus != null)
            //    {
            //        foreach (MenuItem subItem in item.subMenus)
            //        {
            //            if (!itemActionDict.ContainsKey(subItem.id))
            //            {
            //                itemActionDict.Add(subItem.id, subItem.functionName);
            //                Debug.Log("add function : " + subItem.id + " " + subItem.functionName);
            //            }
            //        }
            //    }
            //}

            //foreach (ImageUrl imageUrl in itemList.imageUrlList)
            //{
            //    yield return Utils.GetSprite(imageUrl.url, Consts.PICTURES_FOLDER_NAME + Consts.IMAGE_NAME, imageUrl.id, OnSuccess);
            //    void OnSuccess(Sprite sprite)
            //    {
            //        Debug.Log("success add : " + imageUrl.id);
            //        itemSpriteDict.Add(imageUrl.id, sprite);
            //    }
            //}

            //foreach (KeyValuePair<string, Toggle> kvp in toggleDict)
            //{
            //    MenuItemUI itemUI = kvp.Value.GetComponent<MenuItemUI>();
            //    itemUI?.Set(itemSpriteDict[kvp.Key]);
            //}
        }
    }

    public void SetTaskToggle(Action<bool> action)
    {
        taskToggle.onValueChanged.AddListener(action.Invoke);
    }

    public void SetLeaderboardToggle(Action<bool> action)
    {
        leaderboardToggle.onValueChanged.AddListener(action.Invoke);
    }

    public void SetPhotostreamToggle(Action<bool> action)
    {
        photostreamToggle.onValueChanged.AddListener(action.Invoke);
    }

    public void SetProfileToggle(Action<bool> action)
    {
        profileToggle.onValueChanged.AddListener(action.Invoke);
    }


    #region Invoked By Backend
    //public void Show2DMap()
    //{
    //    Debug.Log("SHOW MAP");
    //    Show2DMap(true);
    //    ShowLibrary(false);
    //    ShowScanner(false);
    //    ShowProfile(false);
    //}

    //public void ShowLibrary()
    //{
    //    Debug.Log("SHOW LIBRARY");
    //    Show2DMap(false);
    //    ShowLibrary(true);
    //    ShowScanner(false);
    //    ShowProfile(false);
    //}

    //public void ShowScanner()
    //{
    //    Debug.Log("SHOW SCANNER");
    //    Show2DMap(false);
    //    ShowLibrary(false);
    //    ShowScanner(true);
    //    ShowProfile(false);
    //}

    //public void ShowProfile()
    //{
    //    Debug.Log("SHOW PROFILE");
    //    Show2DMap(false);
    //    ShowLibrary(false);
    //    ShowScanner(false);
    //    ShowProfile(true);
    //}

    #endregion

    public void ShowTask(bool value)
    {
        if (value)
        {
            task.Show();
            PageStateController.GoToPage(Page.PageState.TASK);
            ShowLeaderboard(false);
            ShowPhotostream(false);
            ShowProfile(false);
        }
        else
            task.Hide();
    }

    public void ShowLeaderboard(bool value)
    {
        if (value)
        {
            leaderboard.Show();
            PageStateController.GoToPage(Page.PageState.LEADERBOARD);
            ShowTask(false);
            ShowPhotostream(false);
            ShowProfile(false);
        }
        else
            leaderboard.Hide();
    }

    public void ShowPhotostream(bool value)
    {
        if (value)
        {
            photostream.Show();
            PageStateController.GoToPage(Page.PageState.PHOTOSTREAM);
            ShowTask(false);
            ShowLeaderboard(false);
            ShowProfile(false);
        }
        else
            photostream.Hide();
    }

    public void ShowProfile(bool value)
    {
        if (value)
        {
            profile.Show();
            PageStateController.GoToPage(Page.PageState.PROFILE);
            ShowTask(false);
            ShowLeaderboard(false);
            ShowPhotostream(false);
        }
        else
            profile.Hide();
    }

    public void SetHeader(string title, Sprite icon, Action onBackButtonClicked)
    {
        header.backButton.gameObject.SetActive(onBackButtonClicked != null);
        if (onBackButtonClicked != null)
        {
            header.backButton.onClick.RemoveAllListeners();
            header.backButton.onClick.AddListener(onBackButtonClicked.Invoke);
        }
        header.titleText.text = title;
        ((RectTransform)header.titleText.transform).anchoredPosition = new Vector2(0, 150f);
        ((RectTransform)header.titleText.transform).DOAnchorPosY(5.4f, 0.2f).SetEase(Ease.OutQuad).Play();
    }

    public Sprite GetSprite(string id)
    {
        if (itemSpriteDict.TryGetValue(id, out Sprite sprite))
        {
            return sprite;
        }
        return null;
    }

    public string GetFunctionName(string id)
    {
        if (itemActionDict.TryGetValue(id, out string functionName))
        {
            return functionName;
        }
        return null;
    }
}
