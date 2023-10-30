using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAirEnemy : IMove
{
    GameObject enemy;
    private float speed;
    private float maxDistance = 5f;
    private float distance = 0;


    public MoveAirEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    public void Move()
    {
        if (distance < maxDistance)
        {
            enemy.transform.Translate(0, 0, speed * Time.deltaTime);
            distance += speed * Time.deltaTime;
            //Debug.Log(distance);
        }
        else
        {
            distance = 0;
            enemy.transform.Rotate(0, 144, 0);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
