using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name: Maya Andrade
 * Date: 04/06/25
 * Last Updated: 04/19/25
 * Description: Allows player movement
 */
public class Player : MonoBehaviour
{

    [Header("Movement Variables")]
    public float speed = 10;
    public float jumpForce = 7f;
    //makes it so that you can check under the player for ground in OnGround() incase the model height is changed later on
    public float underPlayer = 1.2f;
    private bool isfacingLeft;
    private Rigidbody rb;

    [Header("Health Variables")]
    public int maxHP = 99;
    public int healthPoints;
    public Vector3 respawnPoint;
    public int blinkCounter = 5;
    private bool canTakeDamage = true;

    [Header("Combat Variables")]
    public GameObject regularBullet;
    public GameObject heavyBullet;
    public bool bulletUpgraded = false;
    public bool canShoot = true;
    public int magazineSize = 2;
    public int bulletsShot = 0;



    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxHP;
        respawnPoint = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!PauseMenuScript.gameIsPaused)
        {
            Move();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenuScript.gameIsPaused)
        {

            if (healthPoints <= 0) //checks to see if player has "died" yet or not
            {
                SceneManager.LoadScene(3);
                print("GAME OVER =[");
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                healthPoints -= 10;
            }

            Jump();
            Shoot();
        }
    }

    /// <summary>
    /// Allows the player to move left and right using the WASD keys
    /// </summary>
    private void Move()
    {
        //to move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
            isfacingLeft = true;
        }

        //to move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
            isfacingLeft = false;
        }
    }

    /// <summary>
    /// Allows the player to jump using WASD inputs
    /// </summary>
    private void Jump()
    {
        if (OnGround() && Input.GetKeyDown(KeyCode.W))
        {
            //transform.position += Vector3.up * jumpForce;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Draws a raycast right underneath the player that checks if there's ground or air beneath it
    /// </summary>
    /// <returns>if there's ground or not (to be able to jump again)</returns>
    private bool OnGround()
    {
        bool onGround = false;

        RaycastHit hit;

        //Draws a raycast just underneath the player to check for the ground
        if (Physics.Raycast(transform.position, Vector3.down, out hit, underPlayer))
        {
            onGround = true;
        }

        return onGround;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>() && canTakeDamage == true)
        {
            healthPoints -= collision.gameObject.GetComponent<EnemyMovement>().Damage;
            canTakeDamage = false;
            StartCoroutine(Blink());
        }
    }

    /// <summary>
    /// Makes the player blink when it takes damage
    /// </summary>
    private IEnumerator Blink()
    {
        for (int count = 0; count < blinkCounter; count++)
        {
            if (count % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(0.25f);
        }
        GetComponent<MeshRenderer>().enabled = true;
        canTakeDamage = true;
    }

    /// <summary>
    /// Player can shoot bullets to harm enemies with spacebar button
    /// </summary>
    private void Shoot()
    {
        //if using space bar
        if (Input.GetKeyDown(KeyCode.Space) && canShoot == true)
        {
            if (bulletUpgraded == false)
            {
                bulletsShot++;
                GameObject newBullet = Instantiate(regularBullet, transform.position, Quaternion.identity);
                newBullet.transform.forward = isfacingLeft ? Vector3.left : Vector3.right;
                if (bulletsShot >= magazineSize)  //checks to see if the player needs a cooldown time from shooting bullets
                {
                    canShoot = false;
                    StartCoroutine(BulletCooldown());
                }
            }
            else
            {
                bulletsShot++;
                GameObject newBullet = Instantiate(heavyBullet, transform.position, Quaternion.identity);
                newBullet.transform.forward = isfacingLeft ? Vector3.left : Vector3.right;
                if (bulletsShot >= magazineSize)  //checks to see if the player needs a cooldown time from shooting bullets
                {
                    canShoot = false;
                    StartCoroutine(BulletCooldown());
                }
            }
        }
    }

    /// <summary>
    /// Resets bullets shot and makes a cooldown where the player cannot shoot
    /// </summary>
    /// <returns></returns>
    IEnumerator BulletCooldown()
    {
        yield return new WaitForSeconds(1);
        canShoot = true;
        bulletsShot = 0;
    }
}
