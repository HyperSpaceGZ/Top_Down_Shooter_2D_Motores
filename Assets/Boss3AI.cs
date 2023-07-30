using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss3AI : EnemyAI
{
    [SerializeField] private GameObject Portal;
    [SerializeField] bool RArmDestroyed;
    [SerializeField] bool LArmDestroyed;
    [SerializeField] bool ShieldIsDestroyed;
    [SerializeField] private GameObject Shield;

    protected override void Awake()
    {
        base.Awake();
        ShieldIsDestroyed = false;
        RArmDestroyed = false;
        LArmDestroyed = false;
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
        if (RArmDestroyed == true && LArmDestroyed == true)
        {
            Debug.Log("SHIELD DESTROYED");
            ShieldIsDestroyed = true;
            Shield.SetActive(false);
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
}
