using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class ItemInfo
{
    public string id;
    public string itemName;
    public string imageUrl;
    public string imagePath;
}

[Serializable]
public class InventoryData
{
    public List<ItemInfo> itemList;
}

public class InventoryItem : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text itemNameText;
    public ItemInfo info;

    public void Init(ItemInfo info)
    {
        this.info = info;
        itemImage.sprite = Resources.Load<Sprite>(info.imagePath);
        itemNameText.text = info.itemName;
    }
}
