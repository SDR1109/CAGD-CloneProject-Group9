/*Author [Samuel Diaz ]
 * Last Updated [04/18/2025]
 * Description [This code is in charge of breaking the walls if the player has the hammer power up]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    /*public GameObject hammer;

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.GetComponent<HammerScript>())
        {
            if (GetComponent<Player>().bulletUpgraded = true && GetComponent<Player>().jumpForce == 14 && GetComponent<Player>()
                .hammerEquipped == true)
            {
                Destroy(gameObject);
            }
        }
    }
    */
    public void BreakWall()
    {
        // First we look for a GameObject in the current scene that has the "Player" tag.
        Player foundPlayer = GameObject.FindWithTag("Player").GetComponent<Player>();

        // If we *DID* find a player
        if (foundPlayer != null)
        {
            // Go through the regular conditions with the found player
            if (foundPlayer.bulletUpgraded && foundPlayer.jumpForce == 14 && foundPlayer.hammerEquipped)
            {
                Destroy(gameObject);
            }
        }
    }
}

