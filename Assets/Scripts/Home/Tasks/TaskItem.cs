using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskItem : MonoBehaviour
{
    public TMP_Text taskScoreText;
    public TMP_Text taskNameText;
    public Image iconImage;
    public Button actionButton;

    private ActiveTask info;
    private TaskPage taskPage;
    private SelectedTask selectedTaskPage;

    public void Init(TaskPage taskPage, SelectedTask selectedTaskPage, ActiveTask info)
    {
        this.taskPage = taskPage;
        this.info = info;
        this.selectedTaskPage = selectedTaskPage;
        taskScoreText.text = info.score.ToString();
        taskNameText.text = info.taskDetail;
        iconImage.sprite = taskPage.GetTaskActionSprite(info.actionName);
        ColorUtility.TryParseHtmlString(taskPage.GetTaskColor(info.actionName), out Color color);
        actionButton.onClick.AddListener(OnActionButtonClicked);
    }

    private void OnActionButtonClicked()
    {
        selectedTaskPage.ShowTask(taskPage, info);
    }
}
