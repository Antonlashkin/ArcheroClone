using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GetMoney : MonoBehaviour
{
    [SerializeField] public Text score;
    private int coast = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Money")
        {
            int lastScore = Convert.ToInt32(score.text);
            int newScore = lastScore + coast;
            score.text = newScore.ToString();
        }
        Destroy(other.gameObject);
    }
}
