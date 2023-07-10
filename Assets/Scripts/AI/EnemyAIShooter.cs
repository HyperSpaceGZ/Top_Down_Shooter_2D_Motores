using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIShooter : EnemyAI
{
    [SerializeField] public GameObject EnemyBullet;
    [SerializeField] private float EnemyBulletForce = 10f;
    [SerializeField] private Transform Spawner1;
    [SerializeField] private Transform Spawner2;
    void Start()
    {
        Spawner1 = transform.GetChild(0);
        Spawner2 = transform.GetChild(1);
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

        if (hastriggered == false && collision.gameObject.tag == "bullet")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("ShootingEnemy", 1.5f, 1f);
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
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
    }


}
