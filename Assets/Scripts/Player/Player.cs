using Google.XR.ARCoreExtensions;
using Google.XR.ARCoreExtensions.GeospatialCreator;
using Google.XR.ARCoreExtensions.GeospatialCreator.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider distanceSlider;
    public TMP_Text slideValueText;

    private Coroutine repositionCoroutine;

    private void Start()
    {
        distanceSlider.value = 0.5f;
        distanceSlider.onValueChanged.AddListener((value) => slideValueText.text = Mathf.Round(value * 200).ToString());
    }

    private IEnumerator WaitForReposition(ARGeospatialCreatorAnchor anchor)
    {
        if (Application.platform != RuntimePlatform.WindowsEditor && Application.platform != RuntimePlatform.OSXEditor)
        {
            var vpsAvailabilityPromise = AREarthManager.CheckVpsAvailabilityAsync(anchor.Latitude, anchor.Longitude);
            Debug.LogWarning("promise : " + vpsAvailabilityPromise);
            yield return vpsAvailabilityPromise;
            Debug.LogWarning("result : " + vpsAvailabilityPromise.Result);
            Debug.LogWarning(vpsAvailabilityPromise.Result.ToString());
        }
        else
        {
            yield break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(repositionCoroutine == null)
        repositionCoroutine = StartCoroutine(CheckDistance());
        //CheckDistance();
    }

    private IEnumerator CheckDistance()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanceSlider.value * 200, GameManager.Instance.collectableItemLayerMask);
        Collider[] outColliders = Physics.OverlapSphere(transform.position, distanceSlider.value * 220, GameManager.Instance.collectableItemLayerMask);

        Collider[] exceptions = outColliders.Except(colliders).ToArray();
        //foreach (ARGeospatialCreatorAnchor anchor in GameManager.Instance.anchorList)
        //{
        //    if (Vector3.Distance(anchor.transform.position, transform.position) < distanceSlider.value * 200)
        //    {
        //        if (anchor.transform.GetChild(0).name == "monas")
        //        {
        //            Debug.LogWarning("dist : " + Vector3.Distance(anchor.transform.position, transform.position));
        //        }
        //        if (!anchor.gameObject.activeSelf)
        //        {
        //            anchor.gameObject.SetActive(true);
        //            yield return WaitForReposition(anchor);
        //        }
        //    }
        //    else
        //    {
        //        anchor.gameObject.SetActive(false);
        //    }
        //}

        foreach (Collider col in colliders)
        {
            CollectableItem item = col.GetComponent<CollectableItem>();
            if (!item.SetActive(true))
            {
                yield return WaitForReposition(col.GetComponent<ARGeospatialCreatorAnchor>());
            }
        }

        foreach (Collider col in exceptions)
        {
            CollectableItem item = col.GetComponent<CollectableItem>();
            item.SetActive(false);
        }


        repositionCoroutine = null;
    }
}
