using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Image LoadingScreen;

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


}
