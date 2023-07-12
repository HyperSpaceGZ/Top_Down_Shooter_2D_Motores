using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
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
        SceneManager.LoadScene("Game");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Game2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Game3");
    }
}
