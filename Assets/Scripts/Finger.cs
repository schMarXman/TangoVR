using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour
{
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        float verticalValue = Input.GetAxis("Vertical");

        if (verticalValue > 0 || verticalValue < 0)
        {
            transform.Translate(Vector3.forward * speed * verticalValue);
        }

        float horizonatlValue = Input.GetAxis("Horizontal");

        if (horizonatlValue > 0 || horizonatlValue < 0)
        {
            transform.Translate(Vector3.right * speed * horizonatlValue);
        }
    }
}
