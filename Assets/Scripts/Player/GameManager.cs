using Google.XR.ARCoreExtensions.GeospatialCreator.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LayerMask collectableItemLayerMask;
    public Canvas targetCanvas;
    public Transform targetInventory;
    public ParticleSystem hitParticle;

    public List<ItemInfo> itemInfoList;

    public GameObject inventoryContainer;
    public Transform inventoryParent;
    public GameObject inventoryPrefab;
    public Inventory inventory;
    public Button inventoryButton;

    public static GameManager Instance { get; private set; }

    private IEnumerator Start()
    {
        //PlayerPrefs.DeleteAll();
        Instance = this;
        inventoryButton.onClick.AddListener(() => inventory.gameObject.SetActive(true));
        yield return null;
        LoadInventory();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, 250f, collectableItemLayerMask))
                {
                    AddItem(hitInfo.collider.GetComponent<CollectableItem>());
                    Debug.Log("add item : " + hitInfo.collider.name);
                    hitParticle.transform.position = hitInfo.point;
                    hitParticle.Play(true);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteKey("inventory");
        }
    }

    private void AddItem(CollectableItem item)
    {
        if (inventory.GetItemInfoList().Where(x => x.id == item.id).FirstOrDefault() == null)
        {
            item.PlayGetAnimation();
            AddInventoryList(item.id);
        }
        else
        {
            ToastMessage.Instance.ShowMessage("Collected");
        }
    }

    public ItemInfo GetItemInfo(string id)
    {
        return itemInfoList.Where(x => x.id == id).FirstOrDefault();
    }

    public void ShowInventory(bool value)
    {
        inventoryContainer.SetActive(value);
    }

    private void SetInventoryList()
    {
        List<ItemInfo> list = inventory.GetItemInfoList();
        for (int i = 0; i < list.Count; i++)
        {
            AddInventoryList(list[i]);
        }
    }

    private void LoadInventory()
    {
        if (PlayerPrefs.HasKey("inventory"))
        {
            string inventoryjson = PlayerPrefs.GetString("inventory");
            InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(inventoryjson);
            if (inventoryData != null)
            {
                inventory.SetList(inventoryData.itemList);
                SetInventoryList();
            }
        }
        else
        {
            PlayerPrefs.SetString("inventory", "");
        }
    }

    private void AddInventoryList(ItemInfo info)
    {
        GameObject item = Instantiate(inventoryPrefab, inventoryParent);
        InventoryItem inventoryItem = item.GetComponent<InventoryItem>();
        inventoryItem.Init(info);
        inventory.Refresh();
        //itemInfoList.Add(info);
        //InventoryData data = new InventoryData { itemList = itemInfoList };
        //string json = JsonUtility.ToJson(data);
        //PlayerPrefs.SetString("inventory", json);
        //PlayerPrefs.Save();
    }

    private void AddInventoryList(string id)
    {
        GameObject item = Instantiate(inventoryPrefab, inventoryParent);
        InventoryItem inventoryItem = item.GetComponent<InventoryItem>();
        ItemInfo info = GetItemInfo(id);
        inventoryItem.Init(info);
        inventory.AddItem(info);
        inventory.Refresh();

        InventoryData data = new InventoryData { itemList = inventory.GetItemInfoList() };
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("inventory", json);
        PlayerPrefs.Save();
    }
}
