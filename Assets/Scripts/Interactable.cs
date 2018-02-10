using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool onCooldown { get; private set; }

    [SerializeField]
    private float cooldownTime;

    [SerializeField]
    private UnityEvent OnInteraction = new UnityEvent();

    public void TryInvokeOnInteraction()
    {
        if (!onCooldown)
        {
            OnInteraction.Invoke();
            StartCoroutine(WaitCooldownTime());
        }
    }

    private IEnumerator WaitCooldownTime()
    {
        onCooldown = true;

        yield return new WaitForSeconds(cooldownTime);

        onCooldown = false;
    }
}
