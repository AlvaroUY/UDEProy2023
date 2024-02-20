using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_bala : MonoBehaviour
{
    private GameManager gm ;

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
    }
    
    private void OnCollisionEnter (Collision collision) {
        if (collision.transform.CompareTag("P2_B1")) gm.quitarVida(2,1);
        if (collision.transform.CompareTag("P2_B2")) gm.quitarVida(2,2);
        if (collision.transform.CompareTag("P2_B3")) gm.quitarVida(2,3);
        if (collision.transform.CompareTag("P2_B4")) gm.quitarVida(2,4);
        if (collision.transform.CompareTag("P2_B5")) gm.quitarVida(2,5);
        if (collision.transform.CompareTag("P2_B6")) gm.quitarVida(2,6);
        if (collision.transform.CompareTag("P2_B7")) gm.quitarVida(2,7);
    }

}
