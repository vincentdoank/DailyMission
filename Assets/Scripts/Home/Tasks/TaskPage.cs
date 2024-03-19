using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActiveTask
{
    public string taskId;
    public string taskName;
    public string actionName;
    public string taskDetail;
    public int score;
    public string detail;
}

[Serializable]
public class TaskIcon
{
    public string actionName;
    public string colorString;
    public Sprite sprite;
}


public class TaskPage : UIController
{
    public List<TaskIcon> taskIconList = new List<TaskIcon>();
    public List<TaskIcon> iconList = new List<TaskIcon>();
    public SelectedTask selectedTaskPage;
    public GameObject taskPrefab;
    public Transform taskParent;


    private TaskPageView taskPageView;

    private List<ActiveTask> taskList = new List<ActiveTask>();

    protected override void Awake()
    {
        base.Awake();
        taskPageView = (TaskPageView)view;
        SetIcon();
        SetTaskIcon();
        LoadTaskList();
    }

    public override void Show()
    {
        base.Show();
        //HomePage.Instance.SetHeader("Task", null, "schedule", "navigation");
    }

    public Sprite GetTaskActionSprite(string actionName)
    {
        TaskIcon result = taskIconList.Where(x => x.actionName == actionName).FirstOrDefault();
        if (result == null)
            return null;
        return result.sprite;
    }

    public Sprite GetIconSprite(string actionName)
    {
        TaskIcon result = iconList.Where(x => x.actionName == actionName).FirstOrDefault();
        if (result == null)
            return null;
        return result.sprite;
    }

    public string GetTaskColor(string actionName)
    {
        TaskIcon result = taskIconList.Where(x => x.actionName == actionName).FirstOrDefault();
        if (result == null)
            return null;
        return result.colorString;
    }

    private void LoadTaskList()
    {
        taskList.Add(new ActiveTask { taskId = "T001", taskName = "LOCATION", taskDetail = "Go to National Museum", score = 80, actionName = "GPS", detail = "{ \"longtitude\" : -6.2117639, \"latitude\" : 106.8206216, \"tolerance\" : 0.001 }" });
        taskList.Add(new ActiveTask { taskId = "T002", taskName = "SNAP A PHOTO", taskDetail = "Take a selfie with some friends", score = 80, actionName = "PhotoFace" });
        taskList.Add(new ActiveTask { taskId = "T003", taskName = "SNAP A PHOTO", taskDetail = "Take a selfie on National Monument", score = 100, actionName = "PhotoFace" });
        taskList.Add(new ActiveTask { taskId = "T004", taskName = "SCAN QR CODE", taskDetail = "Scan Transjakarta Shuttle QR event", score = 50, actionName = "ScanQR" });
        //taskList.Add(new ActiveTask { taskId = "T004", taskName = "Like this app on Facebook", actionName = "FB" });
        //taskList.Add(new ActiveTask { taskId = "T005", taskName = "Answer a quiz", actionName = "Quiz" });

        for (int i = 0; i < taskList.Count; i++)
        {
            GameObject item = Instantiate(taskPrefab, taskParent, false);
            TaskItem taskItem = item.GetComponent<TaskItem>();
            taskItem.Init(this, selectedTaskPage, taskList[i]);
        }
    }

    private void SetTaskIcon()
    {
        taskIconList.Add(new TaskIcon { actionName = "PhotoFace", colorString = "#FE5E48", sprite = Resources.Load<Sprite>("Textures/Icons/Camera Icon") });
        taskIconList.Add(new TaskIcon { actionName = "ScanQR", colorString = "#E5B044", sprite = Resources.Load<Sprite>("Textures/Icons/Barcode icon") });
        taskIconList.Add(new TaskIcon { actionName = "RecordVideo", colorString = "#64C9CF", sprite = Resources.Load<Sprite>("Textures/Icons/Record icon") });
        taskIconList.Add(new TaskIcon { actionName = "GPS", colorString = "#A85BC3", sprite = Resources.Load<Sprite>("Textures/Icons/Location icon") });
    }

    private void SetIcon()
    {
        iconList.Add(new TaskIcon { actionName = "PhotoFace", colorString = "#FE5E48", sprite = Resources.Load<Sprite>("Textures/Icons/camera") });
        iconList.Add(new TaskIcon { actionName = "ScanQR", colorString = "#E5B044", sprite = Resources.Load<Sprite>("Textures/Icons/qr code") });
        iconList.Add(new TaskIcon { actionName = "RecordVideo", colorString = "#64C9CF", sprite = Resources.Load<Sprite>("Textures/Icons/Record icon") });
        iconList.Add(new TaskIcon { actionName = "GPS", colorString = "#A85BC3", sprite = Resources.Load<Sprite>("Textures/Icons/gps") });
    }
}
