using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmHP1 : MonoBehaviour
{
    public delegate void Arm1DestroyEvent();
    public static Arm1DestroyEvent arm1destroyEvent;

    [SerializeField] protected int health;

    // Start is called before the first frame update
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health--;
            ArmDestroyCheck();
        }
    }

    protected void ArmDestroyCheck()
    {
        if (health < 0)
        {
            arm1destroyEvent?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
