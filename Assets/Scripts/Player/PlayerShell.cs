using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShell : MonoBehaviour
{
    private float speed = 15.0f;
    public float damage = 1.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyShell shell = other.GetComponent<EnemyShell>();
        if (shell == null)
        {
            EnemyCharacter character = other.GetComponent<EnemyCharacter>();
            if (character != null)
            {
                character.ChangedHealth((int)damage);
            }
            Destroy(this.gameObject);
        }
    }
}
