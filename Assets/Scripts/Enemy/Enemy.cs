using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{



    protected IMove _moveEnemy;
    protected IShoot _shootEnemy;

    public void SetMoveEnemy(IMove moveEnemy)
    {
        _moveEnemy = moveEnemy;
    }
    public void SetShootEnemy(IShoot shootEnemy)
    {
        _shootEnemy = shootEnemy;
    }



    protected void Move()
    {
        _moveEnemy.Move();
    }
    protected void Shoot(GameObject shell)
    {
        _shootEnemy.Shoot(shell);
    }
    protected void SetSpeed(float speed)
    {
        _moveEnemy.SetSpeed(speed);
    }
}
