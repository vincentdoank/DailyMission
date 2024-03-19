using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    public Loading loading;
    public Loading bottomLoading;

    public static LoadingManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowLoading(string text, float progress, float minValue, float maxValue)
    {
        loading.gameObject.SetActive(true);
        loading.ShowLoading(text, progress, minValue, maxValue);
    }

    public void ShowLoading(string text, float progress, float minValue = 0f, float maxValue = 1f, string progressFormat = "0.0", string progressSuffix = "%")
    {
        loading.gameObject.SetActive(true);
        loading.ShowLoading(text, progress, minValue, maxValue, progressFormat, progressSuffix);
    }

    public void ShowLoading(string text, float progress, float minValue = 0f, float maxValue = 1f, long currentSize = 0, long size = 0)
    {
        loading.gameObject.SetActive(true);
        loading.ShowLoading(text, progress, minValue, maxValue, currentSize, size);
    }

    public void ShowLoading(string text, float progress, float minValue = 0f, float maxValue = 1f, string progressFormat = "0.0", string progressSuffix = "%", long currentSize = 0, long size = 0)
    {
        loading.gameObject.SetActive(true);
        loading.ShowLoading(text, progress, minValue, maxValue, progressFormat, progressSuffix, currentSize, size);
    }

    public void ShowBottomLoading(string text, float progress, float minValue, float maxValue)
    {
        bottomLoading.gameObject.SetActive(true);
        bottomLoading.ShowLoading(text, progress, minValue, maxValue);
    }

    public void ShowBottomLoading(string text, float progress, float minValue = 0f, float maxValue = 1f, string progressFormat = "0.0", string progressSuffix = "%")
    {
        bottomLoading.gameObject.SetActive(true);
        bottomLoading.ShowLoading(text, progress, minValue, maxValue, progressFormat, progressSuffix);
    }

    public void UpdateLoading(float progress)
    {
        loading.UpdateLoading(progress);
    }

    public void HideLoading()
    {
        loading.gameObject.SetActive(false);
    }

    public void UpdateBottomLoading(float progress)
    {
        bottomLoading.UpdateLoading(progress);
    }

    public void HideBottomLoading()
    {
        bottomLoading.gameObject.SetActive(false);
    }
}
