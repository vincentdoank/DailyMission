using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Extensions;
using Facebook.Unity;
using System;
using System.Threading.Tasks;
using Firebase.Database;

[Serializable]
public class User
{
    public string id;
    public string name;
    public string email;
}

[Serializable]
public class Location
{
    public string id;
    public string name;
    public float longtitude;
    public float latitude;
    public float height;
    public Event[] events;
}

[Serializable]
public class Event
{
    public string id;
    public string title;
    public string subtitle;
    public string image;
    public string video;
    public string audio;
    public string asset;
    public int credit;
    public string expDate;
}

[Serializable]
public class LocationList
{
    public List<Location> locations;
}

[Serializable]
public class EventList
{
    public List<Event> eventList;
}

[Serializable]
public class UserList
{
    public List<User> data;
}

[Serializable]
public class UserDict
{
    public Dictionary<int, User> customers;
}

public class SignInPage : UIController
{
    private SignInPageView signInPageView;
    private FirebaseAuth auth;

    private bool fetchingToken = false;

    private void Start()
    {
        //DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        signInPageView.SetFacebookSignUpButtonEvent(FacebookSignUp);
        signInPageView.SetAppleSignUpButtonEvent(AppleSignUp);
        signInPageView.SetGoogleSignUpButtonEvent(GoogleSignUp);
        signInPageView.SetSignInButtonEvent(SignIn);
        signInPageView.SetForgotPasswordButtonEvent(ForgotPassword);
        auth = FirebaseAuth.DefaultInstance;

        GetUser(); 
    }

    private void GetUser()
    {
        FirebaseDatabase.DefaultInstance.GetReference("customers").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.LogError("err : " + task.Status);

                

            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.LogError("res : " + task.Result.GetRawJsonValue());
                UserList userList = JsonUtility.FromJson<UserList>(task.Result.GetRawJsonValue());
                foreach (User user in userList.data)
                {
                    Debug.LogError("user : " + user.name);
                }
                
                CheckUser(userList, "IniTest", "AkuSiapa", "siapa@gmail.com");
                // Do something with snapshot...
            }
        });
    }

    private void CheckUser(UserList userList, string userId, string name, string email)
    {
        Debug.LogError("WriteNewUser");
        List<User> users = new List<User>() { new User { id = userId, email = email, name = name } };
        UserDict list = new UserDict { customers = new Dictionary<int, User> { { 0, users[0] } } };
        string json = JsonUtility.ToJson(list);

        Debug.LogError("get customers ref : " + FirebaseDatabase.DefaultInstance.GetReference("customers").GetValueAsync().ContinueWithOnMainThread(task => {
            Debug.LogError("get res : " + task.Result.GetRawJsonValue());
            if (string.IsNullOrEmpty(task.Result.GetRawJsonValue()))
            {

                
            }
            else
            {
                //AddUser(userList, userId, name, email);
            }
        }));
    }

    //private void AddUser(UserList userList, string userId, string name, string email)
    //{
    //    userList.data.Add(new User { id = userId, name = name, email = email });
    //    string json = JsonUtility.ToJson(userList);
    //    FirebaseDatabase.DefaultInstance.GetReference("customers").SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
    //    {
    //        Debug.LogError("writing new user");
    //        if (task.IsFaulted)
    //        {
    //            // Handle the error...
    //            Debug.LogError("err : " + task.Status);
    //        }
    //        else if (task.IsCompleted)
    //        {
    //            Debug.LogError(task.AsyncState.ToString());

    //            // Do something with snapshot...
    //        }
    //    });
    //}

    //private void CreateNewUser(string userId, string name, string email)
    //{
    //    Debug.LogError("WriteNewUser");
    //    List<User> users = new List<User>() { new User { id = userId, email = email, name = name } };
    //    UserList list = new UserList { data = users };
    //    string json = JsonUtility.ToJson(list);
    //    FirebaseDatabase.DefaultInstance.RootReference.SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
    //    {
    //        Debug.LogError("writing new user");
    //        if (task.IsFaulted)
    //        {
    //            // Handle the error...
    //            Debug.LogError("err : " + task.Status);
    //        }
    //        else if (task.IsCompleted)
    //        {
    //            Debug.LogError(task.AsyncState.ToString());

    //            // Do something with snapshot...
    //        }
    //    });
    //}

    protected override void Awake()
    {
        base.Awake();
        PageStateController.RegisterPage(Page.PageState.LOGIN, null, null);
    }

    protected override void Init()  
    {
        base.Init();
        signInPageView = (SignInPageView)view;
        FB.Init();
    }

    public void GetUserToken()
    {
        if (auth.CurrentUser == null)
        {
            Debug.Log("Not signed in, unable to get token.");
            SignInWithEmailPassword();
            return;
        }
        Debug.Log("Fetching user token");
        fetchingToken = true;
        auth.CurrentUser.TokenAsync(false).ContinueWithOnMainThread(task => {
            fetchingToken = false;
            if (LogTaskCompletion(task, "User token fetch"))
            {
                Debug.Log("Token = " + task.Result);
                SignInWithToken(task.Result);
            }
        });
    }

    private void SignInWithToken(string token)
    {
        auth.SignInWithCustomTokenAsync(token).ContinueWith(task => {
            if (task.IsCanceled)
            {
                return;
            }
            if (task.IsFaulted)
            {
                return;
            }
            AuthResult result = task.Result;
            Debug.Log("signed in : " + result.User.UserId);
        });
    }

    private void SignInWithEmailPassword()
    {
        string username = signInPageView.GetUsernameInput();
        string password = signInPageView.GetPasswordInput();

        auth.SignInWithEmailAndPasswordAsync(username, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });
    }

    public void SignIn()
    {
        GetUserToken();
    }

    public void FacebookSignUp()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(FacebookSignUp);
            return;
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            FB.Android.RetrieveLoginStatus(LoginStatusCallback);
        }
        else
        {
            NewFacebookLogin();
        }
    }

    private void LoginStatusCallback(ILoginStatusResult result)
    {
        if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Error: " + result.Error);
            NewFacebookLogin();
        }
        else if (result.Failed)
        {
            Debug.Log("Failure: Access Token could not be retrieved");
            NewFacebookLogin();
        }
        else
        {
            // Successfully logged user in
            // A popup notification will appear that says "Logged in as <User Name>"
            Debug.Log("Success: " + result.AccessToken.UserId);
        }
    }

    private void NewFacebookLogin()
    {
        List<string> scopes = new List<string>();
        scopes.Add("public_profile");
        scopes.Add("user_birthday");
        scopes.Add("user_location");
        scopes.Add("user_gender");

        FB.LogInWithReadPermissions(scopes, OnFacebookLoginSucceeded);
    }

    private void OnFacebookLoginSucceeded(ILoginResult result)
    {
        Debug.Log("OnFacebookLoginSucceeded " + result.Error);
        if (result.Cancelled)
        {
            Debug.Log("cancelled");
            return;
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("err : " + result.Error);
            return;
        }
        Debug.Log("check");
        Credential credential = FacebookAuthProvider.GetCredential(AccessToken.CurrentAccessToken.TokenString);
        auth.SignInAndRetrieveDataWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAndRetrieveDataWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInAndRetrieveDataWithCredentialAsync encountered an error: " + task.Exception);
                return;
            }
            if (FB.IsLoggedIn)
            {
                AuthResult result = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})", result.User.DisplayName, result.User.UserId);
            }
        });
    }

    public void AppleSignUp()
    {
        
    }

    public void GoogleSignUp()
    {
        //GoogleSignIn.Configuration = configuration;
        //GoogleSignIn.Configuration.UseGameSignIn = false;
        //GoogleSignIn.Configuration.RequestIdToken = true;
        //Debug.Log("Calling SignIn");

        //GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
        //  OnAuthenticationFinished);
    }

    //internal void OnAuthenticationFinished(Task<GoogleSignInUser> task)
    //{
    //    if (task.IsFaulted)
    //    {
    //        using (IEnumerator<System.Exception> enumerator =
    //                task.Exception.InnerExceptions.GetEnumerator())
    //        {
    //            if (enumerator.MoveNext())
    //            {
    //                GoogleSignIn.SignInException error =
    //                        (GoogleSignIn.SignInException)enumerator.Current;
    //                Debug.LogError("Got Error: " + error.Status + " " + error.Message);
    //            }
    //            else
    //            {
    //                Debug.LogError("Got Unexpected Exception?!?" + task.Exception);
    //            }
    //        }
    //    }
    //    else if (task.IsCanceled)
    //    {
    //        Debug.LogError("Canceled");
    //    }
    //    else
    //    {
    //        Debug.Log("Welcome: " + task.Result.DisplayName + "!");
    //        string googleIdToken = task.Result.IdToken;
    //        string googleAccessToken = task.Result.AuthCode;
    //        Credential credential = GoogleAuthProvider.GetCredential(googleIdToken, googleAccessToken);
    //        auth.SignInAndRetrieveDataWithCredentialAsync(credential).ContinueWith(task =>
    //        {
    //            if (task.IsCanceled)
    //            {
    //                Debug.LogError("SignInAndRetrieveDataWithCredentialAsync was canceled.");
    //                return;
    //            }
    //            if (task.IsFaulted)
    //            {
    //                Debug.LogError("SignInAndRetrieveDataWithCredentialAsync encountered an error: " + task.Exception);
    //                return;
    //            }

    //            AuthResult result = task.Result;
    //            Debug.LogFormat("User signed in successfully: {0} ({1})",
    //                result.User.DisplayName, result.User.UserId);
    //        });
    //    }
    //}

    public void ForgotPassword()
    {
        
    }

    protected bool LogTaskCompletion(Task task, string operation)
    {
        bool complete = false;
        if (task.IsCanceled)
        {
            Debug.Log(operation + " canceled.");
        }
        else if (task.IsFaulted)
        {
            Debug.Log(operation + " encounted an error.");
            foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
            {
                string authErrorCode = "";
                Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                if (firebaseEx != null)
                {
                    authErrorCode = string.Format("AuthError.{0}: ",
                      ((AuthError)firebaseEx.ErrorCode).ToString());
                }
                Debug.Log(authErrorCode + exception.ToString());
            }
        }
        else if (task.IsCompleted)
        {
            Debug.Log(operation + " completed");
            complete = true;
        }
        return complete;
    }
}
