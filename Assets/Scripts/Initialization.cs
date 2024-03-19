using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    public IEnumerator Start()
    {
        yield return AddressableManager.Instance.Clear("scene");
        yield return AddressableManager.Instance.GetDownloadSizeAsync("scene", (size) => LoadingManager.Instance.ShowLoading("Loading", 0, 0, 1, "0.0", "%", 0, size));
        yield return AddressableManager.Instance.DownloadAddressableAsync("scene", (progress) => { LoadingManager.Instance.UpdateLoading(progress);  }, null);
        yield return AddressableManager.Instance.LoadSceneAsync("scene", (x) => x.ActivateAsync());
        LoadingManager.Instance.HideLoading();
    }
}
