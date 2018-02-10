using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleAnimation : MonoBehaviour
{
    public static CircleAnimation Instance;

    public float time;

    public Image dotImage;

    private Vector2 defaultSize;

    private RectTransform rectT;

    private Coroutine resizeRoutine;

    void Start()
    {
        Instance = this;

        rectT = GetComponent<RectTransform>();

        defaultSize = rectT.sizeDelta;

        rectT.sizeDelta = Vector2.zero;
    }

    public void Resize(bool enlarge)
    {
        if (resizeRoutine != null)
        {
            StopCoroutine(resizeRoutine);
            resizeRoutine = null;
        }

        resizeRoutine = StartCoroutine(ResizeAnimation(enlarge));
    }


    IEnumerator ResizeAnimation(bool enlarge)
    {
        float i = 0;
        float rate = 1 / time;

        Vector2 start = rectT.sizeDelta;
        Vector2 end = Vector2.left;

        switch (enlarge)
        {
            case true:
                end = defaultSize;
                dotImage.enabled = false;
                break;
            case false:
                end = Vector2.zero;
                break;
        }

        while (i < 1)
        {
            rectT.sizeDelta = Vector2.Lerp(start, end, i);
            i += Time.deltaTime * rate;
            yield return null;
        }

        rectT.sizeDelta = end;

        resizeRoutine = null;

        if (!enlarge)
        {
            dotImage.enabled = true;
        }
    }
}
