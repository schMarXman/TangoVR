using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRay : MonoBehaviour
{
    public static InteractionRay Instance;

    public RaycastHit hitInfo { get; private set; }

    public LineRenderer lineRenderer;

    private Camera camera;

    private bool previousInteractability;

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

        if (CheckForInteractable() && !previousInteractability)
        {
            CircleAnimation.Instance.Resize(true);
            previousInteractability = true;
        }

        else if (!CheckForInteractable() && previousInteractability)
        {
            CircleAnimation.Instance.Resize(false);
            previousInteractability = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
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

    private bool CheckForInteractable()
    {
        if (hitInfo.distance <= 0.5f && hitInfo.collider != null && hitInfo.collider.gameObject.GetComponent<Interactable>())
        {
            return true;
        }

        return false;
    }

    private void Interact()
    {
        if (CheckForInteractable())
        {
            hitInfo.collider.gameObject.GetComponent<Interactable>().TryInvokeOnInteraction();
        }
    }

    void OnDrawGizmos()
    {
        if (hitInfo.collider != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hitInfo.point, 0.01f);
        }
    }
}
