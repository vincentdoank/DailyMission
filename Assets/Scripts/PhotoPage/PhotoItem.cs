using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotoItem : MonoBehaviour
{
    public TMP_Text ownerText;
    public TMP_Text scoreValueText;
    public Image photoImage;
    public TMP_Text taskNameText;
    public TMP_Text likesText;
    public GameObject likesPanelObj;

    public Button likeButton;
    public Button commentButton;
    public Button infoButton;

    private void Start()
    {
        likeButton.onClick.AddListener(OnLikeButtonClicked);
        commentButton.onClick.AddListener(OnCommentPhotoClicked);
        infoButton.onClick.AddListener(OnInfoButtonClicked);
    }

    private void OnLikeButtonClicked()
    {
        
    }

    private void OnCommentPhotoClicked()
    {
        
    }

    private void OnInfoButtonClicked()
    {
        
    }
}
