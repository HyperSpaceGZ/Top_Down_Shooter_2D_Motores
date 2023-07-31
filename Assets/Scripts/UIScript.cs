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
    public GameObject WinMenu;
    public GameObject Map;
    public bool mapshown;
    public bool ispaused;
    public bool haswon;

    [SerializeField] private float BossTextDisableTime;
    void Start()
    {
        haswon = false;
        mapshown = false;
    BossSpawnText.enabled = false;
        PauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        GuardiansLeft = GameObject.FindGameObjectsWithTag("EnemyGuardian");
        UIRefresh();
    }

    void Update()
    {
        Map.SetActive(false);

        if (haswon == false && Input.GetKeyDown(KeyCode.Escape))
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

        if (haswon == false && Input.GetKey(KeyCode.Tab))
        {
            Map.SetActive(true);
        }
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

    public void Win()
    {
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
        haswon = true;
    }

    private void OnEnable()
    {
        PortalScript.PortalEvent += Win;
    }

    private void OnDisable()
    {
        PortalScript.PortalEvent -= Win;
    }
}
