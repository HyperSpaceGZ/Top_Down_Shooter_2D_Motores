using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public TMP_Text GuardiansText;
    public TMP_Text BossSpawnText;
    public int Guardians;
    public GameObject[] GuardiansLeft;

    public bool HasKilledAllGuardians;

    public GameObject Boss;
    public Transform BossSpawner;

    public GameObject PauseMenu;
    public bool ispaused;

    [SerializeField] private float BossTextDisableTime;
    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
            {
                UnPauseGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void Start()
    {
        BossSpawnText.enabled = false;
        PauseMenu.SetActive(false);
        GuardiansLeft = GameObject.FindGameObjectsWithTag("EnemyGuardian");
        UIRefresh();
    }

    private void UIRefresh()
    {
        GuardiansText.text = "Guardians Killed: " + Guardians + "/" + GuardiansLeft.Length;
    }

    public void AddKill()
    {
        Guardians++;
        UIRefresh();
        AllCoinsCheck();
        Debug.Log("TEST");
    }

    public void AllCoinsCheck()
    {
        if (Guardians == GuardiansLeft.Length)
        {
            Debug.Log("PLAYER HAS KILLED ALL GUARDIANS");
            HasKilledAllGuardians = true;
            GameObject BOSS = Instantiate(Boss, BossSpawner.position, BossSpawner.rotation);
            BossSpawnText.enabled = true;
            StartCoroutine(BossTextDisable());
        }
    }

    IEnumerator BossTextDisable()
    {
        yield return new WaitForSeconds(BossTextDisableTime);
        BossSpawnText.enabled = false;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }
    public void UnPauseGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }
}
