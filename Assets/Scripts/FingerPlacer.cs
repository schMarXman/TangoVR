using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPlacer : MonoBehaviour
{
    public GameObject fingerPrefab;

    private GameObject placedFinger;

    private Vector3 fingerPlacementPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            DestroyFinger();
        }

        if (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))
        {
            InteractionRay.Instance.lineRenderer.enabled = true;
            DrawLine();
            TestFingerPlacement();
        }

        if (Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            InteractionRay.Instance.lineRenderer.enabled = false;
            PlaceFinger();
        }
    }

    void TestFingerPlacement()
    {
        var hit = InteractionRay.Instance.hitInfo;

        var lineRenderer = InteractionRay.Instance.lineRenderer;

        if (hit.collider != null && hit.collider.gameObject.tag == "JengaBlock")
        {
            fingerPlacementPosition = hit.point;

            lineRenderer.endColor = Color.green;
        }
        else
        {
            fingerPlacementPosition = Vector3.zero;

            lineRenderer.endColor = Color.red;
        }
    }

    void DrawLine()
    {
        var ray = InteractionRay.Instance;

        ray.lineRenderer.SetPositions(new[] { transform.position - new Vector3(0, 0.25f, 0), ray.hitInfo.point });
    }

    void PlaceFinger()
    {
        if (fingerPlacementPosition != Vector3.zero)
        {
            placedFinger = Instantiate(fingerPrefab, Vector3.zero, Quaternion.identity);
            placedFinger.transform.forward = InteractionRay.Instance.hitInfo.normal * -1;
            placedFinger.transform.position = InteractionRay.Instance.hitInfo.point -
                                              placedFinger.transform.forward * (placedFinger.transform.localScale.z * 0.5f);
        }
    }

    void DestroyFinger()
    {
        if (placedFinger)
        {
            Destroy(placedFinger);
        }
    }
}
