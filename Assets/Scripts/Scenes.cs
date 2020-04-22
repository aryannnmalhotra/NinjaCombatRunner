using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenes : MonoBehaviour
{
    private AudioSource soundPlayer;
    public AudioClip ButtonSound;
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        soundPlayer.PlayOneShot(ButtonSound);
        SceneManager.LoadScene("GameScene");
    }
    public void Home()
    {
        soundPlayer.PlayOneShot(ButtonSound);
        SceneManager.LoadScene("MainMenu");
    }
    public void Help1()
    {
        soundPlayer.PlayOneShot(ButtonSound); soundPlayer.PlayOneShot(ButtonSound);
        SceneManager.LoadScene("Help1");
    }
    void Update()
    {

    }
}
