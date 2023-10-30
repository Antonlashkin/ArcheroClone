using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShell : MonoBehaviour
{
    private float speed = 10.0f;
    public float damage = 15f;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShell shell = other.GetComponent<PlayerShell>();
        if (shell == null)
        {
            PlayerCharacter character = other.GetComponent<PlayerCharacter>();
            if (character != null)
            {
                character.ChangedHealth((int)damage);
            }
            Destroy(this.gameObject);
        }
    }
}
