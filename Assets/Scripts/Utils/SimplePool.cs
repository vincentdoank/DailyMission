using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool
{
    public string poolName;
    public int count = 10;
    public bool expandable = true;
    public GameObject prefab;
    public Transform parent;
}

public class SimplePool : MonoBehaviour
{
    [SerializeField] private Pool pool;
    private List<GameObject> objList = new List<GameObject>();

    protected void SpawnInitialObjects()
    {
        for (int j = 0; j < pool.count; j++)
        {
            SpawnObject();
        }
    }

    protected GameObject SpawnObject()
    {
        GameObject go = Instantiate(pool.prefab, pool.parent, false);
        go.transform.position = Vector3.zero;
        go.transform.localEulerAngles = Vector3.zero;
        go.SetActive(false);
        objList.Add(go);
        return go;
    }

    public GameObject GetItem()
    {
        for (int i = 0; i < objList.Count; i++)
        {
            if (!objList[i].activeSelf)
            {
                objList[i].SetActive(true);
                return objList[i];
            }
        }

        if (pool.expandable)
        {
            return SpawnObject();
        }

        return null;
    }

    public T GetItem<T>() where T : class
    {
        try
        {
            for (int i = 0; i < objList.Count; i++)
            {
                if (!objList[i].activeSelf)
                {
                    return objList[i].GetComponent<T>();
                }
            }

            if (pool.expandable)
                return SpawnObject().GetComponent<T>();
        }
        catch
        {
            return null;
        }
        return null;
    }
}
