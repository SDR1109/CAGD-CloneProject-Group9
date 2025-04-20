using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Maya Andrade
 * Date: 04/17/25
 * Last Updated: 04/17/25
 * Description: Increases player's maxHP by 100 and puts them at full hp
 */

public class IncMaxHP : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (!PauseMenuScript.gameIsPaused)
        {
            transform.Rotate(0, .5f, 0); //makes health pack rotate for aesthetic purposes
        }
    }

    //Heals the player back to max health
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().maxHP += 100;
            other.GetComponent<Player>().healthPoints = other.GetComponent<Player>().maxHP;
            Destroy(gameObject);
        }
    }
}
