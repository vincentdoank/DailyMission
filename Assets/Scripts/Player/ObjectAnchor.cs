using Google.XR.ARCoreExtensions;
using Google.XR.ARCoreExtensions.GeospatialCreator;
using UnityEngine;

public class ObjectAnchor : MonoBehaviour
{
    private ARGeospatialCreatorAnchor anchor;
    [SerializeField] private AREarthManager earthManager;

    //private void Start()
    //{
    //    StartCoroutine(Init());
    //}

    //public IEnumerator Init()
    //{
    //    anchor = GetComponent<ARGeospatialCreatorAnchor>();
    //    var vpsAvailabilityPromise = AREarthManager.CheckVpsAvailabilityAsync(anchor.Latitude, anchor.Longitude);
    //    Debug.LogWarning("promis : " + vpsAvailabilityPromise);
    //    yield return vpsAvailabilityPromise;
    //    Debug.LogWarning("result : " +  vpsAvailabilityPromise.Result);
    //    Debug.LogWarning(vpsAvailabilityPromise.Result.ToString());
    //    //location.latitude, location.longitude, vpsAvailabilityPromise.Result);
    //}
}
