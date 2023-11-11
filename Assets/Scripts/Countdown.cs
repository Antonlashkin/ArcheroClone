using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private float time = 4;
    [SerializeField] private Text timerLabel; 
    [SerializeField] private GameObject Player;
    private StartGame Spawner;

    void Start()
    {
        Spawner = GetComponent<StartGame>();
        timerLabel.text = time.ToString();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        int timeInt32 = (int)time;
        timerLabel.text = timeInt32.ToString();
        if (time <= 1)
        {
            timerLabel.text = "GO!";
        }
        if (time < 0)
        {
            Player.SetActive(true);
            Spawner.Spawn();
            Destroy(gameObject);
        }
    }
}
