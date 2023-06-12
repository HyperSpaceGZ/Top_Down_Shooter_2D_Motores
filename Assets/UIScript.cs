using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public TMP_Text GuardiansText;
    public int Guardians;
    public GameObject[] GuardiansLeft;

    public bool HasKilledAllGuardians;

    public GameObject Boss;
    public Transform BossSpawner;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void AllCoinsCheck()
    {
        if (Guardians == GuardiansLeft.Length)
        {
            Debug.Log("PLAYER HAS KILLED ALL GUARDIANS");
            HasKilledAllGuardians = true;

            GameObject MINION = Instantiate(Boss, BossSpawner.position, BossSpawner.rotation);
        }
    }
}
