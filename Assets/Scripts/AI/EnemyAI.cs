using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] protected Transform PlayerTransform;
    [SerializeField] protected GameObject Player;
    [SerializeField] private NavMeshAgent EnemyNavMesh;
    [SerializeField] protected bool hastriggered;

    [SerializeField] protected int health;

    // Start is called before the first frame update
    void Awake()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>();
        EnemyNavMesh.updateRotation = false;
        EnemyNavMesh.updateUpAxis = false;

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
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

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
    }

    protected void EnemyFollowerMovement()
    {
        //Rotacion del sprite enemigo
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Movimiento
        EnemyNavMesh.SetDestination(PlayerTransform.position);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
    protected void EnemyDeathCheck()
    {
        if (health < 0)
        {
            Destroy(this.gameObject);
        }
    }





}
