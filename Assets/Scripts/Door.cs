using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerRotatie.onKilledAveryBody += Open;
    }

    private void OnDestroy()
    {
        PlayerRotatie.onKilledAveryBody -= Open;
    }

    private void Open()
    {
        this.gameObject.SetActive(false);
    }
}
