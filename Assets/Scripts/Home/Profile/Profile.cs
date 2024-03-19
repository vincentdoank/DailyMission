using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : UIController
{
    [SerializeField] private string pageName;
    private ProfileView profileView;

    protected override void Awake()
    {
        base.Awake();
        PageStateController.RegisterPage(Page.PageState.PROFILE, null, null);
    }

    protected override void Init()
    {
        base.Init();
        profileView = (ProfileView)view;
    }

    public override void Show()
    {
        Debug.Log("Show Profile");
        base.Show();
       // HomePage.Instance.SetHeader(pageName, null, "schedule", "navigation");
        //HomePage.Instance.SetHeader(pageName, null,
        //    new ButtonInfo { buttonSprite = HomePage.Instance.GetHeader().GetSprite(Consts.NOTIF), onButtonClicked = HomePage.Instance.OpenNotification },
        //    new ButtonInfo { buttonSprite = HomePage.Instance.GetHeader().GetSprite(Consts.SEARCH), onButtonClicked = HomePage.Instance.OpenSearch });
    }
}
