using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SignInPageView : UIScreen
{
    [SerializeField] private Image image;
    [SerializeField] private Button facebookSignUpButton;
    [SerializeField] private Button appleSignUpButton;
    [SerializeField] private Button googleSignUpButton;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private Button forgotPasswordButton;
    [SerializeField] private Button signInButton;

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetFacebookSignUpButtonEvent(Action action)
    {
        facebookSignUpButton.onClick.AddListener(action.Invoke);
    }
    public void SetAppleSignUpButtonEvent(Action action)
    {
        appleSignUpButton.onClick.AddListener(action.Invoke);
    }

    public void SetGoogleSignUpButtonEvent(Action action)
    {
        googleSignUpButton.onClick.AddListener(action.Invoke);
    }

    public void SetForgotPasswordButtonEvent(Action action)
    {
        forgotPasswordButton.onClick.AddListener(action.Invoke);
    }

    public void SetSignInButtonEvent(Action action)
    {
        signInButton.onClick.AddListener(action.Invoke);
    }

    public string GetUsernameInput()
    {
        return usernameInputField.text;
    }

    public string GetPasswordInput()
    {
        return passwordInputField.text;
    }
}
