using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private NavMeshAgent EnemyNavMesh;
    [SerializeField] private bool hastriggered;
    [SerializeField] private GameObject Portal;

    [SerializeField] private GameObject Minion;
    [SerializeField] private Transform Spawner;

    [SerializeField] private int health;
    void Start()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>();
        EnemyNavMesh.updateRotation = false;
        EnemyNavMesh.updateUpAxis = false;

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Spawner = GameObject.FindGameObjectWithTag("MinionSpawner").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health--;
            EnemyDeathCheck();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
            InvokeRepeating("BossMinionSpawn", 0f, 5f);
        }
    }

    private void EnemyFollowerMovement()
    {
        EnemyNavMesh.SetDestination(Player.position);
    }
    private void EnemyDeathCheck()
    {
        if (health < 0)
        {
            Destroy(this.gameObject);
            GameObject Portal1 = Instantiate(Portal, Spawner.position, Quaternion.identity);
        }
    }
    private void BossMinionSpawn()
    {
        GameObject MINION = Instantiate(Minion, Spawner.position, Spawner.rotation);

    }

}
