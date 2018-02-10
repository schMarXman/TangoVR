using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldButtonPushAnimation : MonoBehaviour
{
    public float animationTime;
    public float distance;

    public void TriggerAnimation()
    {
        StartCoroutine(DoCompleteAnimation());
    }

    private IEnumerator DoCompleteAnimation()
    {
        yield return StartCoroutine(MoveInDirectionAnimation(Vector3.down, animationTime / 2));
        yield return StartCoroutine(MoveInDirectionAnimation(Vector3.up, animationTime / 2));
    }

    private IEnumerator MoveInDirectionAnimation(Vector3 direction, float time)
    {
        float i = 0;
        float rate = 1 / time;

        Vector3 start = transform.position;
        Vector3 end = transform.position + direction * distance;

        while (i < 1)
        {
            transform.position = Vector3.Lerp(start, end, i);
            i += Time.deltaTime * rate;
            yield return null;
        }

        transform.position = end;
    }
}
