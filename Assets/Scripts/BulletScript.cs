using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletSpawnedTime;
    public float BulletDespawnTime;
    void Update()
    {
        BulletSpawnedTime += Time.deltaTime;
        if (BulletSpawnedTime >= BulletDespawnTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            DestroyBullet();
        }

        if (collision.gameObject.tag == "EnemyShooter")
        {
            DestroyBullet();
        }

        if (collision.gameObject.tag == "EnemyGuardian")
        {
            DestroyBullet();
        }

        if (collision.gameObject.tag == "enemybullet")
        {
            DestroyBullet();
        }

        if (collision.gameObject.tag == "border")
        {
            DestroyBullet();
        }

        if (collision.gameObject.tag == "HealthItem")
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
