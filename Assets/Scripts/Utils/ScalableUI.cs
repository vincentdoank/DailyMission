using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalableUI : MonoBehaviour
{
    public int defWidth = 1440;
    public int defHeight = 2960;

    private float defRatio;

    private Vector3 defScale;

    private void Start()
    {
        defRatio = (float)defWidth / defHeight;
        defScale = transform.localScale;

        StartCoroutine(CheckScale());
    }

    private IEnumerator CheckScale()
    {
        yield return new WaitForEndOfFrame();
        int curWidth = Screen.width;
        int curHeight = Screen.height;

        float curRatio = (float)curWidth / curHeight;
        Debug.Log("curRatio : " + curRatio + " " + defRatio);


        float scale = curRatio / defRatio;
        transform.localScale = new Vector3(defScale.x * scale, defScale.y * scale, defScale.z * scale);

    }
}
