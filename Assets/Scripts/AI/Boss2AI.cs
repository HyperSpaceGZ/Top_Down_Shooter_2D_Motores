using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2AI : EnemyAIShooter
{
    [SerializeField] private Transform Spawner3;
    [SerializeField] private Transform Spawner4;
    [SerializeField] private Transform Spawner5;
    [SerializeField] private Transform Spawner6;

    [SerializeField] private Transform enemySpawner1;
    [SerializeField] private Transform enemySpawner2;

    [SerializeField] private GameObject Minion1;
    [SerializeField] private GameObject Minion2;

    [SerializeField] private GameObject Portal;

    void Start()
    {
        Spawner1 = transform.GetChild(0);
        Spawner2 = transform.GetChild(1);
        Spawner3 = transform.GetChild(2);
        Spawner4 = transform.GetChild(3);
        Spawner5 = transform.GetChild(4);

        enemySpawner1 = transform.GetChild(5);
        enemySpawner2 = transform.GetChild(6);

        Spawner6 = transform.GetChild(7);
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health--;
            BossDeathCheck();
        }

        if (hastriggered == false && collision.gameObject.tag == "bullet")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("ShootingEnemy", 1.5f, 1f);
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
            InvokeRepeating("BossMinionSpawn",0f, 10f);
        }
    }

    private void BossDeathCheck()
    {
        if (health < 0)
        {
            Destroy(this.gameObject);
            GameObject Portal1 = Instantiate(Portal, Spawner6.position, Quaternion.identity);
        }
    }

    protected override void ShootingEnemy()
    {
        base.ShootingEnemy();

        //Spawner3
        GameObject bulletClone3 = Instantiate(EnemyBullet, Spawner3.position, Spawner3.rotation);
        Rigidbody2D rb3 = bulletClone3.GetComponent<Rigidbody2D>();
        rb3.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);

        //Spawner4
        GameObject bulletClone4 = Instantiate(EnemyBullet, Spawner4.position, Spawner4.rotation);
        Rigidbody2D rb4 = bulletClone4.GetComponent<Rigidbody2D>();
        rb4.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);

        //Spawner5
        GameObject bulletClone5 = Instantiate(EnemyBullet, Spawner5.position, Spawner5.rotation);
        Rigidbody2D rb5 = bulletClone5.GetComponent<Rigidbody2D>();
        rb5.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);
    }

    private void BossMinionSpawn()
    {
        GameObject MINION1 = Instantiate(Minion1, enemySpawner1.position, enemySpawner1.rotation);
        GameObject MINION2 = Instantiate(Minion2, enemySpawner2.position, enemySpawner2.rotation);
    }
}
