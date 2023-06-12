using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //Player
    public float movementspeed;
    public int playerhealth;
    public Rigidbody2D rb;
    Vector2 Movement;

    //Bullets
    public GameObject Bullet;
    public Transform BulletSpawner;
    public float BulletForce;
    public float FireRate;
    private float NextFire;

    private int health = 20;
    public TMP_Text HealthText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UIRefreshHP();
    }

    // Update is called once per frame
    void Update()
    {
        MovementXY();
        LookAtMouse();

        if(Input.GetAxis("Fire1") != 0)
        {
            Shooting();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * movementspeed * Time.deltaTime);
    }

    private void MovementXY()
    {
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");
    }

    private void LookAtMouse()
    {
        Vector2 MousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector2)MousePosition - new Vector2(transform.position.x, transform.position.y);
    }

    private void Shooting()
    {
        if (Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            GameObject bulletClone = Instantiate(Bullet, BulletSpawner.position, BulletSpawner.rotation);
            Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
            rb.AddRelativeForce(Vector3.up * BulletForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            health--;
            UIRefreshHP();
            PlayerDeathCheck();

        }

        if (collision.gameObject.tag == "enemybullet")
        {
            health--;
            UIRefreshHP();
            PlayerDeathCheck();
        }

        if ( health < 20 && collision.gameObject.tag == "HealthItem")
        {
            health++;
            UIRefreshHP();
            PlayerDeathCheck();
        }

    }

    private void UIRefreshHP()
    {
        HealthText.text = "HP: " + health;
    }

    private void PlayerDeathCheck()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }
}
