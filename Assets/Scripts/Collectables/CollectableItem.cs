using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableItem : MonoBehaviour
{
    public string id;
    public GameObject mesh;
    public GameObject getItemObj;
    private ItemInfo itemInfo;

    private void Start()
    {
        itemInfo = GameManager.Instance.GetItemInfo(id);
        if (mesh)
            mesh.SetActive(false);
    }

    public bool SetActive(bool value)
    {
        bool isActive = mesh.activeSelf;
        GetIsActive(ref isActive);

        bool GetIsActive(ref bool isActive)
        {
            return isActive;
        }

        if (mesh)
            mesh.SetActive(value);
        return isActive;
    }

    public void PlayGetAnimation()
    {
        GameObject go = Instantiate(getItemObj, null);
        go.SetActive(true);
        go.transform.position = transform.position;
        go.transform.DOMove(transform.position + new Vector3(0, 10f, 0), 0.5f).SetEase(Ease.OutBack).OnComplete(() => WaitToHide(go)).Play();
        go.transform.DOScale(0.5f, 0.3f).Play();
    }

    private void WaitToHide(GameObject go)
    {
        go.transform.DOScale(0, 0.2f).SetDelay(2f).Play().OnComplete(() => go.SetActive(false));
    }
}
