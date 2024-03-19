using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomePage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("inventory"))
        {
            if (PlayerPrefs.GetString("inventory") == "")
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        Debug.Log("has inventory : " + PlayerPrefs.HasKey("inventory"));
    }
}
