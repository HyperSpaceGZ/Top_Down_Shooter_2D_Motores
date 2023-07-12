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

    [SerializeField] private float BossTextDisableTime;
    // Start is called before the first frame update
    void Start()
    {
        BossSpawnText.enabled = false;
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

}
