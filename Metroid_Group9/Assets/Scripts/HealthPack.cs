using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Maya Andrade
 * Date: 04/10/25
 * Last Updated: 04/17/25
 * Description: Allows health pack powerup to heal player to their max HP
 */

public class HealthPack : MonoBehaviour
{
    public int givenHP = 30;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, .5f, 0); //makes health pack rotate for aesthetic purposes
    }

    //Heals the player back to max health
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            //heals player
            givenHP = Mathf.Clamp(givenHP, 0, other.GetComponent<Player>().maxHP);
            other.GetComponent<Player>().healthPoints += givenHP;

            //destorys object
            Destroy(gameObject);
        }
    }
}
