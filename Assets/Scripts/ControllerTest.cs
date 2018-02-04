using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControllerTest : MonoBehaviour
{

    public GameObject Cube;

    void Update()
    {
        bool button1 = false;

        var controllers = Input.GetJoystickNames();

        if (controllers.Contains("Wireless Controller"))
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                button1 = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                button1 = true;
            }
        }

        if (button1)
        {
            Instantiate(Cube, Vector3.zero, Quaternion.identity);
        }
    }
}
