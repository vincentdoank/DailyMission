using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedTaskView : UIScreen
{
    public TMP_Text scoreText;
    public Image taskPanelImage;
    public TMP_Text actionNameText;
    public TMP_Text taskDetailText;

    public Image outerActionImage;
    public Image innerActionImage;
    public Image iconImage;
    public Button checkTaskButton;

    public void Init(TaskPage controller, ActiveTask task)
    {
        scoreText.text = task.score.ToString();
        ColorUtility.TryParseHtmlString(controller.GetTaskColor(task.actionName), out Color color);
        taskPanelImage.color = outerActionImage.color = innerActionImage.color = color;
        actionNameText.text = task.actionName;
        taskDetailText.text = task.taskDetail;
        iconImage.sprite = controller.GetIconSprite(task.actionName);
    }

    public void SetCheckTaskButton(System.Action action)
    {
        checkTaskButton.onClick.AddListener(action.Invoke);        
    }
}
