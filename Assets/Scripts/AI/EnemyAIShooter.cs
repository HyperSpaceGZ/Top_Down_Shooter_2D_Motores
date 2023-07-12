using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIShooter : EnemyAI
{
    [SerializeField] public GameObject EnemyBullet;
    [SerializeField] protected float EnemyBulletForce = 10f;
    [SerializeField] protected Transform Spawner1;
    [SerializeField] protected Transform Spawner2;
    void Start()
    {
        Spawner1 = transform.GetChild(0);
        Spawner2 = transform.GetChild(1);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("ShootingEnemy", 1.5f, 1f);
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
    }

    public virtual void ShootingEnemy()
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
