using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadManager : MonoBehaviour
{
    public HeaderInfo headerInfo;
    public FooterInfo footerInfo;

    private IEnumerator Start()
    {
        yield return GetRequest<HeaderInfo>(Consts.HEADER_URL, (info) => headerInfo = info);
        yield return GetRequest<FooterInfo>(Consts.FOOTER_URL, (info) => footerInfo = info);
    }

    private IEnumerator GetRequest<T>(string url, Action<T> onComplete)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        yield return uwr.SendWebRequest();
        if (uwr.result == UnityWebRequest.Result.ConnectionError)
            Debug.LogError(uwr.error);
        else
        {
            onComplete?.Invoke(JsonUtility.FromJson<T>(uwr.downloadHandler.text));
        }
    }

    public static IEnumerator DownloadTexture(string url, Action<float> onDownloading, Action<Texture2D> onDownloadCompleted)
    {
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
        UnityWebRequestAsyncOperation ao = uwr.SendWebRequest();
        while (!ao.isDone)
        {
            onDownloading?.Invoke(ao.progress);
            yield return null;
        }
        if (uwr.result == UnityWebRequest.Result.ConnectionError)
            Debug.LogError(uwr.error);
        else
        {
            onDownloadCompleted?.Invoke(DownloadHandlerTexture.GetContent(uwr));
            onDownloading?.Invoke(1f);
        }
        uwr.Dispose();
    }
}
