using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss3AI : EnemyAI
{
    //Boss
    [SerializeField] private GameObject Portal;
    [SerializeField] bool RArmDestroyed;
    [SerializeField] bool LArmDestroyed;
    [SerializeField] bool ShieldIsDestroyed;
    [SerializeField] private GameObject Shield;
    [SerializeField] public GameObject EnemyBullet;
    [SerializeField] protected float EnemyBulletForce = 10f;

    //Spawners
    [SerializeField] protected Transform Spawner1;
    [SerializeField] protected Transform Spawner2;
    [SerializeField] protected Transform Spawner3;
    [SerializeField] protected Transform Spawner4;
    [SerializeField] protected Transform Spawner5;
    [SerializeField] protected Transform Spawner6;
    [SerializeField] protected Transform Spawner7;
    [SerializeField] protected Transform Spawner8;

    //Minions

    public GameObject Minion1;
    public GameObject Minion2;
    public GameObject Minion3;

    [SerializeField] private Transform enemySpawner1;
    [SerializeField] private Transform enemySpawner2;
    [SerializeField] private Transform enemySpawner3;

    protected override void Awake()
    {
        base.Awake();
        ShieldIsDestroyed = false;
        RArmDestroyed = false;
        LArmDestroyed = false;
        Shield = transform.GetChild(0).gameObject;
        Spawner1 = transform.GetChild(1);
        Spawner2 = transform.GetChild(2);
        Spawner3 = transform.GetChild(3);
        Spawner4 = transform.GetChild(4);
        Spawner5 = transform.GetChild(5);
        Spawner6 = transform.GetChild(6);
        Spawner7 = transform.GetChild(7);
        Spawner8 = transform.GetChild(8);

        enemySpawner1 = transform.GetChild(9);
        enemySpawner2 = transform.GetChild(10);
        enemySpawner3 = transform.GetChild(11);
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShieldIsDestroyed == true && collision.gameObject.CompareTag("bullet"))
        {
            health--;
            EnemyDeathCheck();
        }

        if (hastriggered == false && collision.gameObject.tag == "bullet")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
            InvokeRepeating("BossMinionSpawn", 2f, 25f);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
            InvokeRepeating("BossMinionSpawn", 2f, 25f);
        }
    }

    private void DestroyShield()
    {
        if (RArmDestroyed == true && LArmDestroyed == true)
        {
            Debug.Log("SHIELD DESTROYED");
            ShieldIsDestroyed = true;
            Shield.SetActive(false);
            InvokeRepeating("ShootingEnemy", 1f, 0.5f);
            CancelInvoke("BossMinionSpawn");
        }
    }

    private void OnEnable()
    {
        ArmHP.armdestroyEvent += DestroyArmRight;
        ArmHP1.arm1destroyEvent += DestroyArmLeft;
    }
    private void OnDisable()
    {
        ArmHP.armdestroyEvent -= DestroyArmRight;
        ArmHP1.arm1destroyEvent -= DestroyArmLeft;
    }
    private void DestroyArmRight()
    {
        RArmDestroyed = true;
        DestroyShield();
        Debug.Log("RIGHT ARM DESTROYED");
    }
    private void DestroyArmLeft()
    {
        LArmDestroyed = true;
        DestroyShield();
        Debug.Log("LEFT ARM DESTROYED");
    }
    private void ShootingEnemy()
    {
        //Spawner1
        GameObject bulletClone1 = Instantiate(EnemyBullet, Spawner1.position, Spawner1.rotation);
        Rigidbody2D rb1 = bulletClone1.GetComponent<Rigidbody2D>();
        rb1.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);

        //Spawner2
        GameObject bulletClone2 = Instantiate(EnemyBullet, Spawner2.position, Spawner2.rotation);
        Rigidbody2D rb2 = bulletClone2.GetComponent<Rigidbody2D>();
        rb2.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);

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

        //Spawner6
        GameObject bulletClone6 = Instantiate(EnemyBullet, Spawner6.position, Spawner6.rotation);
        Rigidbody2D rb6 = bulletClone6.GetComponent<Rigidbody2D>();
        rb6.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);

        //Spawner7
        GameObject bulletClone7 = Instantiate(EnemyBullet, Spawner7.position, Spawner7.rotation);
        Rigidbody2D rb7 = bulletClone7.GetComponent<Rigidbody2D>();
        rb7.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);

        //Spawner8
        GameObject bulletClone8 = Instantiate(EnemyBullet, Spawner8.position, Spawner8.rotation);
        Rigidbody2D rb8 = bulletClone8.GetComponent<Rigidbody2D>();
        rb8.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);
    }

    private void BossMinionSpawn()
    {
        GameObject MINION1 = Instantiate(Minion1, enemySpawner1.position, enemySpawner1.rotation);
        GameObject MINION2 = Instantiate(Minion2, enemySpawner2.position, enemySpawner2.rotation);
        GameObject MINION3 = Instantiate(Minion3, enemySpawner3.position, enemySpawner3.rotation);
    }

    protected override void EnemyDeathCheck()
    {
        if (health < 0)
        {
            Destroy(this.gameObject);
            GameObject Portal1 = Instantiate(Portal, enemySpawner3.position, Quaternion.identity);
        }
    }
}