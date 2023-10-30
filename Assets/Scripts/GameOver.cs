using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    private void OnTriggerEnter(Collider other)
    {
        EnemyShell enemyShell = other.GetComponent<EnemyShell>();
        if (enemyShell == null)
        {
            PlayerShell playerShell = other.GetComponent<PlayerShell>();
            if (playerShell == null)
            {
                if (other.tag == "Player")
                {
                    gameOverScreen.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
        }
    }
}
