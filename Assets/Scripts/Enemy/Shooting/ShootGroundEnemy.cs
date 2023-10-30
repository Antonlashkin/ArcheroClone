using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShootGroundEnemy : IShoot
{
    //[SerializeField] private GameObject shellPrefab;
    GameObject enemy;
    GameObject player;
    //GroundEnemy _moving;

    public ShootGroundEnemy(GameObject enemy)
    {
        this.enemy = enemy;

    }
    public void Shoot(GameObject shell)
    {
        player = GameObject.FindGameObjectWithTag("Player");


        var direction = player.transform.position - enemy.transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.Euler(0, angle, 0);
        //Debug.Log(direction.x);

        shell.transform.position = enemy.transform.TransformPoint(Vector3.forward * 1.1f);
        shell.transform.rotation = enemy.transform.rotation;
        shell.transform.Rotate(0, 0, 0);
    }
   

    //IEnumerator shooting()
    //{
    //    //yield return new WaitForSeconds(1);
    //    //float speed = _moving.speed;
    //    //_moving.speed = 0;
    //    for (int i = 0; i < 3; i++)
    //    {
    //        var direction = player.transform.position - enemy.transform.position;
    //        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    //        enemy.transform.rotation = Quaternion.Euler(0, angle, 0);


    //        //_shell = Instantiate(shellPrefab);
    //        _shell.transform.position = enemy.transform.TransformPoint(Vector3.forward * 1.1f);
    //        _shell.transform.rotation = enemy.transform.rotation;
    //        _shell.transform.Rotate(0, 0, 0);
    //        //yield return new WaitForSeconds(1);
    //    }
    //    //_moving.speed = speed;
    //    //StartCoroutine(shooting());
    //}
}
