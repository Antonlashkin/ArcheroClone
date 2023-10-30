using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundEnemy : Enemy
{
    [SerializeField] GameObject enemy;
    [SerializeField] private GameObject shellPrefab;
    [SerializeField] float speed = 3.0f;
    private GameObject shell;
    void Start()
    {
        SetMoveEnemy(new MoveGroundEnemy(enemy));
        SetShootEnemy(new ShootGroundEnemy(enemy));
        StartCoroutine(shooting());
        SetSpeed(speed);
    }

    void Update()
    {
        Move();
    }

    IEnumerator shooting()
    {
        yield return new WaitForSeconds(3f);
        SetSpeed(0);
        for (int i = 0; i < 3; i++)
        {
            shell = Instantiate(shellPrefab);
            Shoot(shell);
            yield return new WaitForSeconds(1);
        }
        SetSpeed(speed);
        StartCoroutine(shooting());
    }

}
