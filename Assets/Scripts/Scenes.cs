using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenes : MonoBehaviour
{
    void Start()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Help1()
    {
        SceneManager.LoadScene("Help1");
    }
    void Update()
    {

    }
}
