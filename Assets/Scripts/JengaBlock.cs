using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaBlock : MonoBehaviour
{
    public bool isBottomPiece = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isBottomPiece && collision.gameObject.tag == "Bottom")
        {
            Destroy(gameObject);
        }
    }
}
