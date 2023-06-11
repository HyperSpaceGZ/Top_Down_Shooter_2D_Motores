using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private NavMeshAgent EnemyNavMesh;
    [SerializeField] private bool hastriggered;

    [SerializeField] private int health;

    // Start is called before the first frame update
    void Start()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>();
        EnemyNavMesh.updateRotation = false;
        EnemyNavMesh.updateUpAxis = false;
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
        }
    }

    private void EnemyFollowerMovement()
    {
        //Rotacion del sprite enemigo
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Movimiento
        EnemyNavMesh.SetDestination(Player.position);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
    private void EnemyDeathCheck()
    {
        if (health < 0)
        {
            Destroy(this.gameObject);
        }
    }





}
