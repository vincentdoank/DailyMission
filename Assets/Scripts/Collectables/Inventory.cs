using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    public Transform parent;
    public Button closeButton;

    private List<ItemInfo> itemInfoList = new List<ItemInfo>();

    private void Start()
    {
        closeButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

    public List<ItemInfo> GetItemInfoList()
    {
        return itemInfoList;
    }

    public void AddItem(ItemInfo itemInfo)
    {
        itemInfoList.Add(itemInfo);
    }

    public void SetList(List<ItemInfo> itemInfoList)
    {
        this.itemInfoList = itemInfoList;
    }

    public void Refresh()
    {
        int childCount = parent.childCount;
        float parentLength = ((RectTransform)parent).rect.size.x;
        float totalLength = gridLayoutGroup.cellSize.x * childCount + gridLayoutGroup.spacing.x * (childCount - 1) + gridLayoutGroup.padding.left + gridLayoutGroup.padding.right;
        if (parentLength >= totalLength)
        {
            gridLayoutGroup.childAlignment = TextAnchor.UpperLeft;
        }
        else
        {
            gridLayoutGroup.childAlignment = TextAnchor.UpperCenter;
        }
    }
}
