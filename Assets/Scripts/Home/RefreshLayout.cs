using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshLayout : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(WaitToRefresh());
    }

    private IEnumerator WaitToRefresh()
    {
        yield return null;
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
    }
}
