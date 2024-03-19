using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalablePadding : MonoBehaviour
{
    public int defWidth = 2960;
    public int defHeight = 1440;
    public RectOffset padding;

    private float defRatio;
    private LayoutGroup layoutGroup;

    private void Start()
    {
        layoutGroup = GetComponent<LayoutGroup>();
        defRatio = (float)defWidth / defHeight;

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
        layoutGroup.padding = new RectOffset(Mathf.RoundToInt(padding.left * scale), Mathf.RoundToInt(padding.right * scale),
            Mathf.RoundToInt(padding.top * scale), Mathf.RoundToInt(padding.bottom * scale));

    }
}
