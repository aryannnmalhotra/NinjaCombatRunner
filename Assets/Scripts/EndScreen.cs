using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text HighScoreText;
    public Text ScoreText;
    void Start()
    {
        ScoreText.text = UIManager.Score.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        ClearList();
    }
    void ClearList()
    {
        for (int i = 0; i < ReplenishableSpawn.replenishables.Count; i++)
        {
            var toDestroy = ReplenishableSpawn.replenishables[i];
            ReplenishableSpawn.replenishables.RemoveAt(i);
            Destroy(toDestroy);
        }
        for (int i = 0; i < ObstacleSpawn.obstacles.Count; i++)
        {
            var toDestroy = ObstacleSpawn.obstacles[i];
            ObstacleSpawn.obstacles.RemoveAt(i);
            Destroy(toDestroy);
        }
    }
    void Update()
    {
        
    }
}
