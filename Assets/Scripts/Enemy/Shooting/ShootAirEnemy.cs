using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAirEnemy : IShoot
{
    GameObject enemy;
    GameObject player;

    public ShootAirEnemy(GameObject enemy)
    {
        this.enemy = enemy;

    }
    public void Shoot(GameObject shell)
    {
        player = GameObject.FindGameObjectWithTag("Player");


        var direction = player.transform.position - enemy.transform.position;
        float angleHor = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float directXZ = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.z, 2));
        float angleVert = Mathf.Atan2(- direction.y, directXZ) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.Euler(angleVert, angleHor, 0);

        shell.transform.position = enemy.transform.TransformPoint(Vector3.forward * 1.1f);
        shell.transform.rotation = enemy.transform.rotation;
        shell.transform.Rotate(0, 0, 0);
    }
}
