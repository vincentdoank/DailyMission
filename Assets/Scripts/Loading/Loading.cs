using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Loading : MonoBehaviour
{
    public TMP_Text loadingText;
    public TMP_Text progressText;
    public TMP_Text sizeText;
    public Slider loadingSlider;

    private float minValue;
    private float maxValue;
    private string progressFormat;
    private string progressSuffix;

    private long downloadSize = 0;

    public void ShowLoading(string text, float progress, float minValue = 0f, float maxValue = 1f)
    {
        progress = CheckProgressValue(progress);

        this.minValue = minValue;
        this.maxValue = maxValue;

        loadingText.text = text;
        loadingSlider.value = progress;
        progressText.gameObject.SetActive(true);
    }

    public void ShowLoading(string text, float progress, float minValue = 0f, float maxValue = 1f, string progressFormat = "0.0", string progressSuffix = "%")
    {
        ShowLoading(text, progress, minValue, maxValue);

        this.progressFormat = progressFormat;
        this.progressSuffix = progressSuffix;

        progressText.text = progress.ToString(progressFormat) + progressSuffix;
    }

    public void ShowLoading(string text, float progress, float minValue = 0f, float maxValue = 1f, long currentSize = 0, long size = 0)
    {
        ShowLoading(text, progress, minValue, maxValue);
        sizeText.text = Utils.GetSizeWithSuffix(currentSize) + "/" + Utils.GetSizeWithSuffix(size);
        downloadSize = size;
    }

    public void ShowLoading(string text, float progress, float minValue = 0f, float maxValue = 1f, string progressFormat = "0.0", string progressSuffix = "%", long currentSize = 0, long size = 0)
    {
        ShowLoading(text, progress, minValue, maxValue, currentSize, size);

        this.progressFormat = progressFormat;
        this.progressSuffix = progressSuffix;

        progressText.text = progress.ToString(progressFormat) + progressSuffix;
        downloadSize = size;
    }

    public void UpdateLoading(float progress)
    {
        progressText.text = (progress == maxValue ? progress * (progressSuffix == "%" ? 100 : 1) : (progress * (progressSuffix == "%" ? 100 : 1)).ToString(progressFormat)) + progressSuffix;
        if (sizeText) sizeText.text = Utils.GetSizeWithSuffix(System.Math.Round(downloadSize * (decimal)progress)) + "/" + Utils.GetSizeWithSuffix(downloadSize); 
        progress = CheckProgressValue(progress);
        loadingSlider.value = progress;
    }

    private float CheckProgressValue(float progress)
    {
        if (progress < minValue)
        {
            progress = minValue;
        }
        else if (progress > maxValue)
        {
            progress = maxValue;
        }
        return progress;
    }
}
