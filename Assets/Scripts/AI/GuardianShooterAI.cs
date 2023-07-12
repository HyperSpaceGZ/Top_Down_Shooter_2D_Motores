using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianShooterAI : EnemyAIShooter
{
    [SerializeField] private Transform Spawner3;
    [SerializeField] private Transform Spawner4;
    [SerializeField] public GameObject HPDrop;

    void Start()
    {
        Spawner1 = transform.GetChild(0);
        Spawner2 = transform.GetChild(1);
        Spawner3 = transform.GetChild(2);
        Spawner4 = transform.GetChild(3);
    }

    public override void ShootingEnemy()
    {
        base.ShootingEnemy();

        //Spawner3
        GameObject bulletClone3 = Instantiate(EnemyBullet, Spawner3.position, Spawner3.rotation);
        Rigidbody2D rb3 = bulletClone3.GetComponent<Rigidbody2D>();
        rb3.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health--;
            if (health == 0)
            {
                Destroy(this.gameObject);
                GameObject MINION = Instantiate(HPDrop, Spawner4.position, Quaternion.identity);
                Debug.Log("muerte");
            }
        }

        if (hastriggered == false && collision.gameObject.tag == "bullet")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
    }
}
