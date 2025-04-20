using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public int HammerSpeed = 20;
    public int HammerDespawnTime = 7;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * HammerSpeed * Time.deltaTime;
        if (!PauseMenuScript.gameIsPaused)
        {
            transform.Rotate(0, .5f, 0); //makes health pack rotate for aesthetic purposes
        }
    }
    IEnumerator DespawnTime()
    {
        yield return new WaitForSeconds(HammerDespawnTime);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {

        }
        else
        {
            if (other.GetComponent<BreakableWall>())
                {
                GetComponent<BreakableWall>().BreakWall();
            }
        }
    }
}
