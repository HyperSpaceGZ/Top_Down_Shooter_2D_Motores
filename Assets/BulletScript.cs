using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletSpawnedTime;
    public float BulletDespawnTime;
    void Start()
    {

    }

    // Update is called once per frame
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

        if (collision.gameObject.tag == "border")
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
