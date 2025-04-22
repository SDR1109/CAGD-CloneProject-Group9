/*
 * Author [Samuel Diaz ]
 * Last Updated [04/04/2025]
 * Description [This code is in charge of the hammer movement]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public int hammerSpeed = 20;
    public int hammerDespawnTime = 7;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * hammerSpeed * Time.deltaTime;
    }
    IEnumerator DespawnTime()
    {
        yield return new WaitForSeconds(hammerDespawnTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
      
        if (other.gameObject.tag == "Player")
        {

        }
        else
        {
            print(other.gameObject + "Test 1");

            if (other.gameObject.GetComponent<BreakableWall>())
            {
                print(other.gameObject + "Test 2");

                other.transform.GetComponent<BreakableWall>().BreakWall();

                Destroy(gameObject);
            }
        }
    }
}

