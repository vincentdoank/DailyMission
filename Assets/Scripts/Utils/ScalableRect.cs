using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalableRect : MonoBehaviour
{
    public int defWidth = 1440;
    public int defHeight = 2960;
    public RectTransform layoutRoot;

    private float defRatio;

    private Vector2 defRectSize;

    private void Start()
    {
        defRatio = (float)defWidth / defHeight;
        defRectSize = ((RectTransform)transform).sizeDelta;

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
        ((RectTransform)transform).sizeDelta = new Vector2(defRectSize.x * scale, defRectSize.y * scale);
        yield return new WaitForEndOfFrame();
        LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot);
    }
}
