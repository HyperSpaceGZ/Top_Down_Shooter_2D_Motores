using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAI : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private float EnemyBulletForce = 10f;
    [SerializeField] private GameObject HPDrop;

    [SerializeField] private Transform Spawner1;
    [SerializeField] private Transform Spawner2;
    [SerializeField] private Transform Spawner3;
    [SerializeField] private Transform Spawner4;
    [SerializeField] private Transform HPDropSpawner;

    [SerializeField] private bool hastriggered;
    [SerializeField] public Vector3  rotationamount;

    private UIScript ScriptUI;

    // Start is called before the first frame update
    void Start()
    {
        hastriggered = false;
        ScriptUI = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("ShootingGuardian", 3f, 1.5f);
            InvokeRepeating("Rotation", 0f, 0.01f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("bullet"))
        {
            health--;
            if (health == 0)
            {
                Destroy(this.gameObject);
                GameObject MINION = Instantiate(HPDrop, HPDropSpawner.position, Quaternion.identity);
                ScriptUI.AddKill();
                Debug.Log("muerte");
            }
        }
    }


    private void ShootingGuardian()
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

        //Spawner3
        GameObject bulletClone4 = Instantiate(EnemyBullet, Spawner4.position, Spawner4.rotation);
        Rigidbody2D rb4 = bulletClone4.GetComponent<Rigidbody2D>();
        rb4.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);
    }

    private void Rotation()
    {
        transform.Rotate(rotationamount * Time.deltaTime);
    }

}
