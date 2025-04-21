/*Author [Samuel Diaz ]
 * Last Updated [04/20/2025]
 * Description [This code is in charge of giving the player the hammer]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPowerUP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
