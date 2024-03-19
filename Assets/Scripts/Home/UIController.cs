using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    protected UIScreen view;
    protected virtual void Awake()
    {
        Init();
        Debug.Log("awake : " + transform.name);
    }

    protected virtual void Init()
    {
        view = GetComponent<UIScreen>();
        view.SetBackButtonEvent(Hide);
        Debug.Log("view : " + view.name);
    }

    public virtual void Show()
    {
        Debug.Log("show : " + transform.name, this);
        Debug.Log("view : " + view, this);
        Init();
        view.Show();
    }

    public virtual void Hide()
    {
        if (view)
            view.Hide();
    }
}
