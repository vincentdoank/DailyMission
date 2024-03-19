using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class API
{
    public static void GetMenuFromLocalJson<T>(string fileName, Action<T> result)
    {
        TextAsset json = Resources.Load<TextAsset>("JSON/" + fileName);
        var obj = JsonUtility.FromJson<T>(json.text);
        result?.Invoke(obj);
    }

    public static IEnumerator RequestMenu(string url, Action<MenuItemList> onSuccess, Action<string> onFailed)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        yield return uwr.SendWebRequest();
        if (string.IsNullOrEmpty(uwr.error))
        {
            onSuccess?.Invoke(JsonUtility.FromJson<MenuItemList>(uwr.downloadHandler.text));
        }
        else
        {
            onFailed?.Invoke(uwr.error);
        }
    }
}
