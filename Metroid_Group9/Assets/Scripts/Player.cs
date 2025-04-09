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
 * Last Updated: 04/08/25
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
    public int healthPoints = 99;
    public Vector3 respawnPoint;
    public int blinkCounter = 5;

    [Header("Combat Variables")]
    public GameObject regularBullet;
    public GameObject heavyBullet;
    private bool bulletUpgraded = false;
    public bool canShoot = true;
    public int magazineSize = 2;
    public int bulletsShot = 0;



    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Shoot();

        if (healthPoints <= 0) //checks to see if player has "died" yet or not
        {
            SceneManager.LoadScene(3);
            print("GAME OVER =[");
        }
        if (bulletsShot >= magazineSize)  //checks to see if the player needs a cooldown time from shooting bullets
        {
            canShoot = false;
            StartCoroutine(BulletCooldown());
        }
    }

    /// <summary>
    /// Allows the player to move left and right using the WASD and arrow key input
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
            isfacingLeft = true;
        }
    }

    /// <summary>
    /// Allows the player to jump using WASD and arrow key input
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
            yield return new WaitForEndOfFrame();
        }
        GetComponent<MeshRenderer>().enabled = true;
    }

    /// <summary>
    /// Player can shoot bullets to harm enemies
    /// </summary>
    private void Shoot()
    {

        /*
         * This will allow the player to shoot a new bullet in the direction the player is facing, 
         * while the player holds the fire button. 
         * The player should not be able to fire faster than 2 bullets per second.
         * SPACE = fire in the direction the player is facing. 
         * OR LEFT ARROW fires left – RIGHT ARROW fires right.
         */

        //if using space bar
        if (Input.GetKey(KeyCode.Space))
        {
            if (isfacingLeft == true)
            {
                if (bulletUpgraded == false)
                {
                    Instantiate(regularBullet, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(heavyBullet, transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (bulletUpgraded == false)
                {
                    Instantiate(regularBullet, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(heavyBullet, transform.position, Quaternion.identity);
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
