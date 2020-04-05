using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject Bg;
    public GameObject Panel;
    public GameObject User1;
    public GameObject User2;
    public GameObject User3;
    public GameObject User4;
    public GameObject User5;
    public GameObject User6;
    void Start()
    {

    }
    public void Next()
    {
        Bg.SetActive(false);
        Panel.SetActive(false);
        if (ScreenCount.ScreenNo == 0)
        {
            User1.SetActive(true);
            ScreenCount.ScreenNo++;
        }
        else if (ScreenCount.ScreenNo == 1)
        {
            User1.SetActive(false);
            User2.SetActive(true);
            ScreenCount.ScreenNo++;
        }
        else if (ScreenCount.ScreenNo == 2)
        {
            User2.SetActive(false);
            User3.SetActive(true);
            ScreenCount.ScreenNo++;
        }
        else if (ScreenCount.ScreenNo == 3)
        {
            User3.SetActive(false);
            User4.SetActive(true);
            ScreenCount.ScreenNo++;
        }
        else if (ScreenCount.ScreenNo == 4)
        {
            User4.SetActive(false);
            User5.SetActive(true);
            ScreenCount.ScreenNo++;
        }
        else
        {
            User5.SetActive(false);
            User6.SetActive(true);
            ScreenCount.ScreenNo++;
        }
    }
    public void Previous()
    {
        if (ScreenCount.ScreenNo == 2)
        {
            ScreenCount.ScreenNo--;
            User2.SetActive(false);
            User1.SetActive(true);
        }
        else if (ScreenCount.ScreenNo == 3)
        {
            ScreenCount.ScreenNo--;
            User3.SetActive(false);
            User2.SetActive(true);
        }
        else if (ScreenCount.ScreenNo == 4)
        {
            ScreenCount.ScreenNo--;
            User4.SetActive(false);
            User3.SetActive(true);
        }
        else if (ScreenCount.ScreenNo == 5)
        {
            ScreenCount.ScreenNo--;
            User5.SetActive(false);
            User4.SetActive(true);
        }
        else
        {
            ScreenCount.ScreenNo--;
            User6.SetActive(false);
            User5.SetActive(true);
        }
    }
    public void Home()
    {
        if (ScreenCount.ScreenNo == 1)
            User1.SetActive(false);
        else if (ScreenCount.ScreenNo == 2)
        {
            User2.SetActive(false);
        }
        else if (ScreenCount.ScreenNo == 3)
        {
            User3.SetActive(false);
        }
        else if (ScreenCount.ScreenNo == 4)
        {
            User4.SetActive(false);
        }
        else if (ScreenCount.ScreenNo == 5)
        {
            User5.SetActive(false);
        }
        else
        {
            User6.SetActive(false);
        }
        ScreenCount.ScreenNo = 0;
        Bg.SetActive(true);
        Panel.SetActive(true);
    }
    void Update()
    {
        
    }
}
