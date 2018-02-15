using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTower : MonoBehaviour
{
    private TangoPoseController poseController;


    void Start()
    {
        poseController = GetComponent<TangoPoseController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.L))
        {
            poseController.enabled = false;
            transform.LookAt(JengaBuilder.Instance.transform);
            poseController.enabled = true;
        }
    }
}
