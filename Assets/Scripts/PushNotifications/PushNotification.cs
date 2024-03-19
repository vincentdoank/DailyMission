using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneSignalSDK;

public class PushNotification : MonoBehaviour
{
    private const string ONE_SIGNAL_APP_ID = "dcb11270-435b-4e28-b3fc-013cbfdcbd4e";

    private void Start()
    {
        OneSignal.Initialize(ONE_SIGNAL_APP_ID);
    }
}
