using System;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#elif UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class LocalNotification
{
    private static Dictionary<string, int> androidNotifDict = new Dictionary<string, int>();

    public static void SendNotification(string id, string title, string message, TimeSpan timeSpan)
    {
#if UNITY_ANDROID
        SendAndroidNotification(id, title, message, timeSpan);
#elif UNITY_IOS
        SendIosNotification(id, title, message, timeSpan);
#endif
    }

    public static void UpdateNotification(string id, string title, string message, TimeSpan timeSpan)
    {
#if UNITY_ANDROID
        UpdateAndroidNotification(id, title, message, timeSpan);
#elif UNITY_IOS
        CancelIosNotification(id);
        SendIosNotification(id, title, message, timeSpan);
#endif
    }

    public static void CancelNotification(string id)
    {
#if UNITY_ANDROID
        CancelAndroidNotification(id);
#elif UNITY_IOS
        CancelIosNotification(id);
#endif
    }


    private static void SendAndroidNotification(string id, string title, string message, TimeSpan timeSpan)
    {
#if UNITY_ANDROID
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = message;
        notification.FireTime = DateTime.Now.Add(timeSpan);
        int notifId = AndroidNotificationCenter.SendNotification(notification, "");
        if (!androidNotifDict.ContainsKey(id))
            androidNotifDict.Add(id, notifId);
#endif
    }

    private static void UpdateAndroidNotification(string id, string title, string message, TimeSpan timeSpan)
    {
#if UNITY_ANDROID
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = message;
        notification.FireTime = DateTime.Now.Add(timeSpan);
        if (androidNotifDict.ContainsKey(id))
        {
            int notifId = androidNotifDict[id];
            AndroidNotificationCenter.UpdateScheduledNotification(notifId, notification, "channel_id");
        }
#endif
    }

    private static void CancelAndroidNotification(string id)
    {
#if UNITY_ANDROID
        if (androidNotifDict.ContainsKey(id))
        {
            int notifId = androidNotifDict[id];
            AndroidNotificationCenter.CancelScheduledNotification(notifId);
        }
#endif
    }

#if UNITY_IOS
    private static void SendIosNotification(string id, string title, string message, TimeSpan timeSpan)
    {
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = timeSpan,
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            // You can specify a custom identifier which can be used to manage the notification later.
            // If you don't provide one, a unique string will be generated automatically.
            Title = title,
            Body = message,
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger,
        };

        iOSNotificationCenter.ScheduleNotification(notification);
    }

    private static void CancelIosNotification(string id)
    {
        iOSNotificationCenter.RemoveScheduledNotification(id);
    }
#endif
}
