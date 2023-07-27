using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{ 
    //Player
    public float movementspeed;
    [SerializeField] private int health = 20;
    [SerializeField] private int armor = 0;
    [SerializeField] private bool hasArmor;
    public Rigidbody2D rb;
    Vector2 Movement;
    public TMP_Text HealthText;
    public TMP_Text ShieldText;

    //Bullets
    public GameObject Bullet;
    public Transform BulletSpawner;
    public float BulletForce;
    public float FireRate;
    private float NextFire;

    //power ups
    [SerializeField] private float PowerUpSpeedTimer;
    [SerializeField] private bool SpeedSet;
    [SerializeField] private float PowerUpTripleShotTimer;
    [SerializeField] private bool TripleShotSet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UIRefreshHP();
        hasArmor = false;
        SpeedSet = false;
        TripleShotSet = false;
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
        //Enemy Hit
        if (armor > 0 && collision.collider.CompareTag("enemy"))
        {
            ShielDMG();
            Debug.Log("armor hit");
            UIRefreshHP();
        }
        else if (armor == 0 && collision.gameObject.tag == "enemy")
        {
            hasArmor = false;
            health--;
            UIRefreshHP();
            PlayerDeathCheck();
            Debug.Log("hp hit");
        }

        //Enemy Bullet Hit
        if (armor > 0 && collision.gameObject.tag == "enemybullet")
        {
            ShielDMG();
            Debug.Log("armor hit");
            UIRefreshHP();
        }
        else if (armor == 0 && collision.gameObject.tag == "enemybullet")
        {
            hasArmor = false;
            health--;
            UIRefreshHP();
            PlayerDeathCheck();
            Debug.Log("hp hit");
        }

        //Healing
        if (health < 10 && collision.gameObject.tag == "HealthItem")
        {
            health++;
            UIRefreshHP();
        }

        //ItemSpeed
        if (collision.gameObject.tag == "Speed")
        {
            SpeedBoost();
        }

        //ItemShoot
        if (collision.gameObject.tag == "TripleShot")
        {

        }
    }

    private void UIRefreshHP()
    {
        HealthText.text = "HP: " + health;
        ShieldText.text = "" + armor;
    }

    private void ShielDMG() 
    {
        armor--;
    }

    private void PlayerDeathCheck()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }

    private void SpeedBoost()
    {
        if(SpeedSet == false)
        {
            movementspeed = movementspeed * 2;
            StartCoroutine(SpeedBoostTimer());
            SpeedSet = true;
        }     
    }
    private void SpeedBoostOrigin()
    {
        movementspeed = movementspeed / 2;
        SpeedSet = false;
    }

    IEnumerator SpeedBoostTimer()
    {
        yield return new WaitForSeconds(PowerUpSpeedTimer);
        SpeedBoostOrigin();
    }

}
