using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalableGrid : MonoBehaviour
{
    private GridLayoutGroup gridLayoutGroup;

    public int defWidth = 1440;
    public int defHeight = 2960;
    public int size;
    public int spacing;
    public RectOffset padding;

    private float defRatio;

    private void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
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

        gridLayoutGroup.cellSize = new Vector2(size * scale, size * scale);
        gridLayoutGroup.spacing = new Vector2(spacing * scale, spacing * scale);
        gridLayoutGroup.padding = new RectOffset(Mathf.RoundToInt(padding.left * scale), Mathf.RoundToInt(padding.right * scale),
            Mathf.RoundToInt(padding.top * scale), Mathf.RoundToInt(padding.bottom * scale));

    }
}
