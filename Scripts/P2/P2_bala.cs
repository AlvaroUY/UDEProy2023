using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class P2_bala : MonoBehaviourPunCallbacks
{
    private GameManager gm ;

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
    }
    
    private void OnCollisionEnter (Collision collision) {
        if (collision.transform.CompareTag("P1_B1")) gm.quitarVida(1,1);
        if (collision.transform.CompareTag("P1_B2")) gm.quitarVida(1,2);
        if (collision.transform.CompareTag("P1_B3")) gm.quitarVida(1,3);
        if (collision.transform.CompareTag("P1_B4")) gm.quitarVida(1,4);
        if (collision.transform.CompareTag("P1_B5")) gm.quitarVida(1,5);
        if (collision.transform.CompareTag("P1_B6")) gm.quitarVida(1,6);
    }

}
