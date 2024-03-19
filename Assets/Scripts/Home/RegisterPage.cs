using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RegisterPage : UIController
{
    private const int FULL_NAME_MIN = 3;
    private const int FULL_NAME_MAX = 20;
    private const int USERNAME_MIN = 8;
    private const int USERNAME_MAX = 20;
    private const int PASSWORD_MIN = 8;
    private const int PASSWORD_MAX = 30;

    private RegisterPageView registerPageView;

    private string password;

    protected override void Awake()
    {
        base.Awake();
        registerPageView = (RegisterPageView)view;
        registerPageView.SetFullNameValueChangeEvent(OnFullNameInputValueChanged);
        registerPageView.SetEmailValueChangeEvent(OnEmailInputValueChanged);
        registerPageView.SetUsernameValueChangeEvent(OnUsernameInputValueChanged);
        registerPageView.SetPasswordValueChangeEvent(OnPasswordInputValueChanged);
        registerPageView.SetConfPasswordValueChangeEvent(OnConfPasswordinputValueChanged);
    }


    public void OnFullNameInputValueChanged(string value)
    {
        if (value.Length < FULL_NAME_MIN)
        {

        }
        else if (value.Length > FULL_NAME_MAX)
        {
            
        }
    }

    public void OnEmailInputValueChanged(string value)
    {
        
    }

    public void OnUsernameInputValueChanged(string value)
    {
        if (value.Length < FULL_NAME_MIN)
        {

        }
        else if (value.Length > FULL_NAME_MAX)
        {

        }
    }

    public void OnPasswordInputValueChanged(string value)
    {
        password = value;
        if (value.Length < PASSWORD_MIN)
        {

        }
        else if (value.Length > PASSWORD_MAX)
        {

        }
    }

    public void OnConfPasswordinputValueChanged(string value)
    {
        if (password != value)
        {
            
        }
    }

    private void Validate()
    {
        
    }
}
