/*
 * Author [Samuel Diaz ]
 * Last Updated [04/20/2025]
 * Description [This code is in charge of giving the player the hammer]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPowerUP : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!PauseMenuScript.gameIsPaused)
        {
            transform.Rotate(0, 0, .5f); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().hammerEquipped = true;
            Destroy(gameObject);
        }
    }
}
