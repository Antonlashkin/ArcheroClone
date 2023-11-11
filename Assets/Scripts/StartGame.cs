using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject SceneController;
    public void Spawn()
    {
        SceneController.SetActive(true);
    }
}
