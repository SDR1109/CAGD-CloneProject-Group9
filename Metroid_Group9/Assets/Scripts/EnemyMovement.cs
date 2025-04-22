/*Author [Samuel Diaz ]
 * Last Updated [04/04/2025]
 * Description [This code is in charge of the enemy movement]
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public int Damage;
    
    public float speed = 5;
    public int life;
    public bool MoveRight = false;
    public bool MoveLeft = false;
    public int EnemyCount = 7;
    
    public LayerMask nonPlayerMask;


    // Start is called before the first frame update
    void Start()
    {
        MoveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
        RaycastHit hit;
        Vector3 Right = transform.position + new Vector3(1.5f, 0, 0);
        Vector3 Left = transform.position + new Vector3(-1.5f, 0, 0);

        if (Physics.Raycast(Right, Vector3.right, out hit, 0.5f, nonPlayerMask) && OnGround() == true)
        {

            
            
            
                print("Raycast hit the right");
                MoveRight = false;
                MoveLeft = true;
            
                
            

        }
               

            if (Physics.Raycast(Left, Vector3.left, out hit, 0.5f, nonPlayerMask) && OnGround() == true)
            {
           
                print("Raycast hit the left");
                MoveLeft = false;
                MoveRight = true;
            
           
            
        } if (MoveRight)
                {
                    MovingRight();
                }
                if (MoveLeft)
                {
                    MovingLeft();
                }



        DestroyObject();

    }
    
    private bool OnGround()
    {
        bool onGround = false;
        RaycastHit hit;
        Vector3 leftEdge = transform.position + new Vector3(-1.5f, 0, 0);
        Vector3 rightEdge = transform.position + new Vector3(1.5f, 0, 0);
        if (Physics.Raycast(leftEdge, Vector3.down, out hit, 1.2f))
        {
            onGround = true;
        }
       else if (Physics.Raycast(rightEdge, Vector3.down, out hit, 1.2f))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
        return onGround;
    }
    private void MovingRight()
    { 
        transform.position += Vector3.right * speed * Time.deltaTime;
       

    }
    private void MovingLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

    }

    public void DamageEnemy(int amount)
    {
        print(gameObject.name + " was damaged " + amount + " hp!");
        life -= amount;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other);
        //if (other.GetComponent<BulletScript>())
        //{ 
        //    print("bullet impacted");
        //    life -= other.GetComponent<BulletScript>().bulletDamage;
        //    Destroy(other.gameObject);
        //}
           
        
    }

    private void DestroyObject()
    {
        if(life <=0)
        {
            Destroy(gameObject);
            EnemyCount--;
        }
    }
    private void WinGame()
    {
        if (EnemyCount == 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}
