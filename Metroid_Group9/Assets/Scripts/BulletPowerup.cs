/*Author [Samuel Diaz ]
 * Last Updated [04/04/2025]
 * Description [This code is in charge of changing the kind of bullets]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, .5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().bulletUpgraded = true;
            Destroy(gameObject);
        }
    }
}
