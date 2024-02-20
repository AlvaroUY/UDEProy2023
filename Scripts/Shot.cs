using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject missil;
    public Transform spawnPoint;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(Time.time > shotRateTime)
            {
                GameObject newMissil;
                newMissil = Instantiate(missil, spawnPoint.position, spawnPoint.rotation);
                newMissil.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*shotForce);
                shotRateTime = Time.time + shotRate;
                Destroy(newMissil, 0.5f);
            }
        }

    }
}
