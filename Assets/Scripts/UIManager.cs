using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private float preOffset;
    public GameObject HBBase;
    public GameObject HB;
    public Text HealthText;
    public Text KunaiCountText;
    public Text StarCountText;
    public Text ScoreText;
    public static int Score;
    public static int HighScore;
    private void Awake()
    {
        Score = 0;
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    void Start()
    {
        preOffset = 0;
    }
    public void HealthBar()
    {
        HB.transform.localScale = new Vector3(1.2f * (Ninja.Health / 100), 1.2f, 0);
        HB.transform.position -= new Vector3(0.3f * ((1.2f - (1.2f*(Ninja.Health / 100))) / 0.12f) - preOffset, 0, 0);
        preOffset = (0.3f * ((1.2f - (1.2f * (Ninja.Health / 100))) / 0.12f));
    }
    void SceneChange()
    {
        SceneManager.LoadScene("EndScene");
    }
    void Update()
    {
        if (Ninja.IsAlive)
        {
            HBBase.transform.position += new Vector3(5.5f * Time.deltaTime, 0, 0);
            HB.transform.position += new Vector3(5.5f * Time.deltaTime, 0, 0);
            HealthText.text = Ninja.Health.ToString();
            KunaiCountText.text = Ninja.KunaiCount.ToString();
            StarCountText.text = Ninja.StarCount.ToString();
            ScoreText.text = Score.ToString();
        }
        if (!Ninja.IsAlive)
        {
            if (Score > HighScore)
                PlayerPrefs.SetInt("HighScore", Score);
            Invoke("SceneChange", 0.6f);
        }
    }
}
