using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    public float speed = 5f;
    CharacterController _characterCantroller;
    internal bool move = true;


    void Start()
    {
        _characterCantroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //float deltaX = _joystick.Horizontal * speed;
        float deltaZ = Mathf.Sqrt(Mathf.Pow(_joystick.Vertical, 2f)  + Mathf.Pow(_joystick.Horizontal, 2f)) * speed;
        Vector3 movement = new Vector3(0, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterCantroller.Move(movement);


        if (deltaZ != 0)
        {
            move = true;
        }
        else
        {
            move = false;
        }
    }
}
