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
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1f;
    }

    public void Level1()
    {
        LoadingScreen.enabled = true;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void Level2()
    {
        LoadingScreen.enabled = true;
        SceneManager.LoadScene("Game2");
        Time.timeScale = 1f;
    }
    public void Level3()
    {
        LoadingScreen.enabled = true;
        SceneManager.LoadScene("Game3");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
        Time.timeScale = 1f;
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1f;
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
