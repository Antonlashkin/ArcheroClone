using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject graundEnemeyPrefab;
    [SerializeField] private GameObject airEnemeyPrefab;

    private GameObject _graundEnemey;
    private GameObject _airEnemey;

    void Awake()
    {
        _graundEnemey = Instantiate(graundEnemeyPrefab);
        _graundEnemey.transform.position = new Vector3(Random.Range(-4, 4), 0.75f, Random.Range(5, 14));

        _airEnemey = Instantiate(airEnemeyPrefab);
        _airEnemey.transform.position = new Vector3(Random.Range(-4, 4), 4.5f, Random.Range(5, 14));
    }
}
