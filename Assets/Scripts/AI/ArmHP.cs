using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmHP : MonoBehaviour
{
    public delegate void ArmDestroyEvent();
    public static ArmDestroyEvent armdestroyEvent;

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
            armdestroyEvent?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
