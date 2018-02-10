using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;

public class SwitchToVRLoadScene : MonoBehaviour
{

    public void SwitchToVRAndLoadScene()
    {
        StartCoroutine(SwitchToVRRoutine());

    }

    private IEnumerator SwitchToVRRoutine()
    {
        VRSettings.LoadDeviceByName("split");
        yield return null;
        VRSettings.enabled = true;
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }
}
