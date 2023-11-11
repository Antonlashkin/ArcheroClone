using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] private GameObject shellPrefab;
    [SerializeField] PlayerMove _playerMove;
    private GameObject _shell;
    private bool anyEnemy = true;

    private void OnEnable()
    {
        PlayerRotatie.onKilledEveryBody += Anigilation;
    }
    private void Start()
    {
        StartCoroutine(shooting());
    }

    private void OnDestroy()
    {
        PlayerRotatie.onKilledEveryBody -= Anigilation;
    }

    private void Anigilation()
    {
        anyEnemy = false;
    }

    IEnumerator shooting()
    {
        if (anyEnemy)
        {
            yield return new WaitForSeconds(0.1f);
            if (!_playerMove.move)
            {
                _shell = Instantiate(shellPrefab);
                _shell.transform.position = transform.TransformPoint(Vector3.up * 1.5f);
                _shell.transform.rotation = transform.rotation;
                _shell.transform.Rotate(-90, 0, 90);
            }
            StartCoroutine(shooting());
            //yield return null;
        }       
        yield return null;
    }
}
