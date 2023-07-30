using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss3AI : EnemyAI
{
    [SerializeField] private GameObject Portal;
    [SerializeField] bool ShieldIsDestroyed;
    [SerializeField] int ArmAmount;
    [SerializeField] int ArmsDestroyed;
    [SerializeField] private GameObject Shield;

    protected override void Awake()
    {
        base.Awake();
        ShieldIsDestroyed = false;
        Shield = transform.GetChild(1).gameObject;
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
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
    }

    private void DestroyShield()
    {
        if (ArmsDestroyed >= ArmAmount)
        {
            Debug.Log("Shield Destroyed");
            ShieldIsDestroyed = true;
            Shield.SetActive(false);
        }
    }

    private void OnEnable()
    {
        ArmHP.armdestroyEvent += DestroyArm;
    }
    private void OnDisable()
    {
        ArmHP.armdestroyEvent -= DestroyArm;
    }
    private void DestroyArm()
    {
        ArmsDestroyed++;
        DestroyShield();
        Debug.Log("ARM DESTROYED");
    }
}
