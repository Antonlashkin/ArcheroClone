using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : Enemy
{
    [SerializeField] GameObject enemy;
    [SerializeField] private GameObject shellPrefab;
    [SerializeField] float speed = 3.0f;
    private GameObject shell;
    // Start is called before the first frame update
    void Start()
    {
        SetMoveEnemy(new MoveAirEnemy(enemy));
        SetShootEnemy(new ShootAirEnemy(enemy));
        StartCoroutine(shooting());
        SetSpeed(speed);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    IEnumerator shooting()
    {
        yield return new WaitForSeconds(3f);
        SetSpeed(0);
        float x = transform.rotation.x;
        float y = transform.rotation.y;
        float z = transform.rotation.z;
        float w = transform.rotation.w;
        for (int i = 0; i < 3; i++)
        {
            shell = Instantiate(shellPrefab);
            Shoot(shell);
            yield return new WaitForSeconds(1);
        }
        SetSpeed(speed);
        transform.rotation = new Quaternion(x,y,z,w);
        StartCoroutine(shooting());
    }
}
