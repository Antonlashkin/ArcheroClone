using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GetMoney : MonoBehaviour
{
    [SerializeField] public Text Tscore;
    private int cost = 1;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Money")
        {
            score += cost;
            Tscore.text = score.ToString();
        }
        Destroy(other.gameObject);
    }
}
