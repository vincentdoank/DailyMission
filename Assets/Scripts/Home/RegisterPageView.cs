using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class RegisterPageView : UIScreen
{
    [SerializeField] private Button facebookLoginButton;
    [SerializeField] private Button appleLoginButton;
    [SerializeField] private Button googleLoginButton;
    [SerializeField] private TMP_InputField fullNameInputField;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TMP_InputField confirmPasswordInputField;
    [SerializeField] private Toggle agreeTncToggle;
    [SerializeField] private Button signUpButton;
    [SerializeField] private Button signInButton;

    public void SetFullNameValueChangeEvent(Action<string> action)
    {
        fullNameInputField.onValueChanged.AddListener(action.Invoke);
    }

    public void SetEmailValueChangeEvent(Action<string> action)
    {
        emailInputField.onValueChanged.AddListener(action.Invoke);
    }

    public void SetUsernameValueChangeEvent(Action<string> action)
    {
        usernameInputField.onValueChanged.AddListener(action.Invoke);
    }

    public void SetPasswordValueChangeEvent(Action<string> action)
    {
        passwordInputField.onValueChanged.AddListener(action.Invoke);
    }

    public void SetConfPasswordValueChangeEvent(Action<string> action)
    {
        confirmPasswordInputField.onValueChanged.AddListener(action.Invoke);
    }

    public void SetOnAgreeTnCToggle(Action<bool> action)
    {
        agreeTncToggle.onValueChanged.AddListener(action.Invoke);
    }

    public void OnSignUpButtonClicked(Action action)
    {
        signUpButton.onClick.AddListener(action.Invoke);
    }

    public void OnSignInButtonClicked(Action action)
    {
        signInButton.onClick.AddListener(action.Invoke);
    }

    public void UpdateUserNameInputText(string value)
    {
        usernameInputField.text = value;
    }
}
