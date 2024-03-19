using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHeader : MonoBehaviour
{
    public Button menuButton;
    public Button searchButton;
    public HomePage homePage;

    private void Start()
    {
        menuButton.onClick.AddListener(ToggleShowMenu);
    }

    private void ToggleShowMenu()
    {
        homePage.ToggleShowMenu();
    }


}
