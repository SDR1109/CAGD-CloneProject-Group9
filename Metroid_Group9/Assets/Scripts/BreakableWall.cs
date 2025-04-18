/*Author [Samuel Diaz ]
 * Last Updated [04/18/2025]
 * Description [This code is in charge of breaking the walls if the player has the hammer power up]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(GetComponent<Player>().bulletUpgraded =true && GetComponent<Player>().jumpForce == 14)
        {

        }
    }
}
