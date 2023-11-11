using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotatie : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private PlayerShooting shooting;
    public static Action onKilledEveryBody;
    public float sensitivityHor = 3.0f;

    GameObject[] enemy;
    GameObject closest;

    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {

        //float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        //float rotationY = transform.localEulerAngles.y + delta;
        //transform.localEulerAngles = new Vector3(0, rotationY, 0);
        if (closest == null)
        {
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
        }
        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            float angle = Mathf.Atan2(_joystick.Horizontal, _joystick.Vertical) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        else
        {
            if (enemy.Length != 0)
            {
                Transform closestsEnemy = FindClosesEnemy();
                var direction = closestsEnemy.position - this.transform.position;
                float angleHor = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float directXZ = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.z, 2));
                float angleVert = Mathf.Atan2(-direction.y, directXZ) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(angleVert, angleHor, 0);
            }
            else
            {
                onKilledEveryBody?.Invoke();
            }
        }
    }


    Transform FindClosesEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in enemy)
        {
            Vector3 difference = go.transform.position - position;
            float curDistance = difference.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest.transform;
    }
}
