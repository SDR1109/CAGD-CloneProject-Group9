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

    //increases the player's max HP and heals them back to that new max
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
