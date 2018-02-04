using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRay : MonoBehaviour
{
    public static InteractionRay Instance;

    public RaycastHit hitInfo { get; private set; }

    public LineRenderer lineRenderer;

    private Camera camera;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        camera = GetComponent<Camera>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hitInfo = hit;
        }
        else
        {
            hitInfo = new RaycastHit();
        }
    }

    void OnDrawGizmos()
    {
        if (hitInfo.collider!=null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hitInfo.point, 0.01f);
        }
    }
}
