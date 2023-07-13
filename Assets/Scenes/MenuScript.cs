using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Image LoadingScreen;
    public Image tutorial1;
    public Image tutorial2;
    public Image tutorial3;

    private void Awake()
    {
        LoadingScreen.enabled = false;
    }

    public void Play()
    {
        LoadingScreen.enabled = true;
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Level1()
    {
        LoadingScreen.enabled = true;
        SceneManager.LoadScene("Game");
    }
    public void Level2()
    {
        LoadingScreen.enabled = true;
        SceneManager.LoadScene("Game2");
    }
    public void Level3()
    {
        LoadingScreen.enabled = true;
        SceneManager.LoadScene("Game3");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void TutorialScreen1()
    {      
        tutorial1.enabled = true;
        tutorial2.enabled = false;
        tutorial3.enabled = false;
    }
    public void TutorialScreen2()
    {
        tutorial1.enabled = false;
        tutorial2.enabled = true;
        tutorial3.enabled = false;
    }
    public void TutorialScreen3()
    {
        tutorial1.enabled = false;
        tutorial2.enabled = false;
        tutorial3.enabled = true;
    }

}
