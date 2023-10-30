using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerRotatie.onKilledAveryBody += Disappearence;
    }

    private void OnDestroy()
    {
        PlayerRotatie.onKilledAveryBody -= Disappearence;
    }

    private void Disappearence()
    {
        this.gameObject.SetActive(false);
    }
}
