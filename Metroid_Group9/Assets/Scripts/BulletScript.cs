using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Name: Maya Andrade
 * Date: 04/08/25
 * Last Updated: 04/20/25
 * Description: Allows player's bullets to damage enemies and despawn
 */

public class BulletScript : MonoBehaviour
{
    public int bulletDamage = 1;

    //regular bullet deals 1HP of damage
    //heavy bullet deals 3HP of damage

    public int bulletSpeed = 20;
    public int bulletDespawnTime = 7;

    // Start is called before the first frame update
    void Start()
    {
        //start timer to despawn bullet if it doesn't hit anything
        StartCoroutine(DespawnTime());
    }

    private void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Despawns the bullet after x amount of seconds
    /// </summary>
    IEnumerator DespawnTime()
    {
        yield return new WaitForSeconds(bulletDespawnTime);
        Destroy(gameObject);
    }

    /*
     * if it collides with the player, nothing happens
     * ifit collides with an enemy, it damages the enemy by whatever amount of damage that bullet does
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            //makes sure that if the bullets overlap with themselves or any part of their models they dont cause each other to delete accidentally
        }
        if (other.tag == "Player")
        {
            //makes sure that if the bullets overlap with any part of the player it doesn't delete the bullet accidentally
        }
        else
        {
            if (other.TryGetComponent(out EnemyMovement enemy))
            {
                enemy.DamageEnemy(bulletDamage);
            }
            Destroy(gameObject);
        }
    }
}
