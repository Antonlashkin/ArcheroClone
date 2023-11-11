using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerRotatie.onKilledEveryBody += Open;
    }

    private void OnDestroy()
    {
        PlayerRotatie.onKilledEveryBody -= Open;
    }

    private void Open()
    {
        gameObject.SetActive(false);
    }
}
