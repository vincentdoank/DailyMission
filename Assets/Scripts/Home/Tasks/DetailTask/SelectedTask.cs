using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class TargetLocation
{
    public float latitude;
    public float longtitude;
    public float tolerance = 0.001f;
}

public class SelectedTask : UIController
{
    private SelectedTaskView selectedTaskPageView;

    private ActiveTask task;

    protected override void Awake()
    {
        base.Awake();
        selectedTaskPageView = (SelectedTaskView)view;
        if (!Input.location.isEnabledByUser)
            Debug.Log("Location not enabled on device or app does not have permission to access location");

    }

    public void ShowTask(TaskPage taskPage, ActiveTask task)
    {
        this.task = task;
        selectedTaskPageView.Init(taskPage, task);
        view.Show();
        selectedTaskPageView.SetCheckTaskButton(CheckTask);
    }

    public void CheckTask()
    {
        if (task.actionName == "GPS")
        {
            TargetLocation location = JsonUtility.FromJson<TargetLocation>(task.detail);
            StartCoroutine(CheckLocation(location));
        }
    }

    public IEnumerator CheckLocation(TargetLocation location)
    {
        int maxWait = 20;
        Input.location.Start();
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Unable to determine device location");
            yield break;
        }
        else
        {

            Vector2 targetPos = new Vector2(location.longtitude, location.latitude);
            Vector2 currentPos = new Vector2(Input.location.lastData.longitude, Input.location.lastData.latitude);

            if (Vector2.Distance(currentPos, targetPos) <= location.tolerance)
            {
                Success();
            }

            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            
        }

        // Stops the location service if there is no need to query location updates continuously.
        Input.location.Stop();
    }

    private void Success()
    {
        
    }
}
