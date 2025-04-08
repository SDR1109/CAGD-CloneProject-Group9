/*Author [Samuel Diaz ]
 * Last Updated [04/04/2025]
 * Description [This code is in charge of the portal]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform TeleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = TeleportPoint.position;
    }
}
