using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class UserData : MonoBehaviour
{
    public void LoadUserData()
    {
        
    }

    private IEnumerator RequestUserData(string url, Action onRequestSucceed, Action<string> onRequestFailed)
    {
        //http request
        UnityWebRequest uwr = new UnityWebRequest(url);
        yield return uwr.SendWebRequest();
        try
        {
            if (uwr.isDone)
            {

            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
            
        }
    }
}
