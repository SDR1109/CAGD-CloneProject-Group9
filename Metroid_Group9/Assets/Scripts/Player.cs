using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name: Maya Andrade
 * Date: 04/06/25
 * Last Updated: 04/06/25
 * Description: Allows player movement control
 */
public class Player : MonoBehaviour
{
    [Header("Player Movement Variables")]
    public float speed = 10;
    public float jumpForce = 7;
    //makes it so that you can check under the player for ground in OnGround() incase the model height is changed later on
    public float underPlayer = 1.2f;


    public int healthPoints = 99;
    public Vector3 respawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    /// <summary>
    /// Allows the player to move left and right using the WASD and arrow key input
    /// </summary>
    private void Move()
    {
        //to move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        //to move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    /// <summary>
    /// Allows the player to jump using WASD and arrow key input
    /// </summary>
    private void Jump()
    {
        if (OnGround() && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            transform.position += Vector3.up * jumpForce;
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
    /// Make player lose HP, blink when they do so, and goes to game over screen if they reach 0HP
    /// </summary>
    public void LoseHP()
    {
        //somehow get the player health to drop by the amount of damage the enemy type does

        if (healthPoints > 0)
        {
            //The player should blink for the next 5 seconds and shouldn’t be able to get damaged again during that time. 
        }
        else //hp is less than or equal to 0
        {
            SceneManager.LoadScene(3);
            print("GAME OVER =[");
        }
    }
}
