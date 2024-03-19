using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScannerPageView : UIScreen
{
    [SerializeField] private GameObject loadingObj;
    [SerializeField] private LocationSelection locationSelection;
    [SerializeField] private CameraScan cameraScan;

    public void ShowLoading(bool value)
    {
        loadingObj.SetActive(value);
    }

    public void ShowLocationSelection(bool value)
    {
        //if (value)
        //    locationSelection.Show();
        //else
        //    locationSelection.Hide();
    }

    public void ShowCameraScan(bool value)
    {
        if (cameraScan)
        {
            if (value)
                cameraScan.Show();
            else
                cameraScan.Hide();
        }
    }
}
