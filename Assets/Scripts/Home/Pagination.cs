using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pagination : MonoBehaviour
{
    public GameObject pagination;
    public GameObject loginPage;
    public Toggle[] paginationToggles;
    private int index = 0;

    private void Start()
    {
        index = 0;
    }

    public void ShowLoginPage(bool value)
    {
        pagination.SetActive(!value);
        loginPage.SetActive(value);
    }

    public void NextPage()
    {
        if (index < paginationToggles.Length)
        {
            index += 1;
            paginationToggles[index].isOn = true;
        }
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }
}
