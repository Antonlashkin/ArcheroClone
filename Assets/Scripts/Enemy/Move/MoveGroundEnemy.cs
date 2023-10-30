using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroundEnemy : IMove
{
    GameObject enemy;
    private float speed;
    private float obstacleRange = 1.0f;

    public MoveGroundEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }
    public void Move()
    {
        enemy.transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(enemy.transform.position, enemy.transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 1f, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                enemy.transform.Rotate(0, angle, 0);
            }
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
