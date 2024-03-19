using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomePageView : MonoBehaviour
{
    private float width;
    public SimpleScrollSnap scrollSnap;
    public Transform pageParent;
    public List<RectTransform> panels = new List<RectTransform>();

    void Start()
    {
        width = ((RectTransform)transform).rect.size.x;
        Debug.Log("height : " + ((RectTransform)pageParent).rect.size.y);
        foreach (Transform child in pageParent)
        {
            panels.Add((RectTransform)child);
            ((RectTransform)child).sizeDelta = new Vector2(width, ((RectTransform)pageParent).rect.size.y);
        }
        scrollSnap.Size = new Vector2(width, ((RectTransform)pageParent).rect.y);
        //scrollSnap.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
