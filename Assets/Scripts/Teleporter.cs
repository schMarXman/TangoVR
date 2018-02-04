using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public float maxTeleporationDistance = 3f;

    private bool teleportationPossible = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TestForTeleport();
            InteractionRay.Instance.lineRenderer.enabled = true;
            ShowLine(teleportationPossible);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
           InteractionRay.Instance.lineRenderer.enabled = false;
            Teleport();
        }
    }

    private void TestForTeleport()
    {
        var hit = InteractionRay.Instance.hitInfo;

        float angle = Vector3.Angle(Vector3.up, hit.normal);

        teleportationPossible = angle <= 30 && hit.distance <= maxTeleporationDistance;
    }

    private void ShowLine(bool teleportPossible)
    {
        var hit = InteractionRay.Instance.hitInfo;

        var lineRenderer = InteractionRay.Instance.lineRenderer;

        if (hit.collider != null)
        {
            lineRenderer.SetPositions(new[] { transform.position - new Vector3(0, 0.25f, 0), hit.point });

            if (teleportPossible)
            {
                lineRenderer.endColor = Color.green;
            }
            else
            {
                lineRenderer.endColor = Color.red;
            }
        }
        else
        {
            lineRenderer.SetPositions(new[] { Vector3.zero, Vector3.zero });
        }
    }

    private void Teleport()
    {
        if (teleportationPossible)
        {
            var point = InteractionRay.Instance.hitInfo.point;

            transform.position = new Vector3(point.x, transform.position.y, point.z);
        }
    }
}
