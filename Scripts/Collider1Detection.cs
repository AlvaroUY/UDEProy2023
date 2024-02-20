using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collider1Detection : MonoBehaviour
{

    public GameObject enemy;
  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entré al collider1");
        if(other.tag == "Player")
        {
            if(enemy.tag == "cilindro1")
            {
                enemy.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Salí del collider1");
        if(other.tag == "Player")
        {   
           if(enemy.tag == "cilindro1")
            {
                enemy.SetActive(false);
            }
        }
    }

}
