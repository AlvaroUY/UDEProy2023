using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    public float speed = 5f ;
    private Rigidbody rb ; 
    private GameManager gm ;

    private int player = 2; 
    public int bola; 
    public int costoVida = 100; 

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gm.getPlayer()==player && gm.getBola()==bola) {
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");            
            Vector3 desplazamiento = new Vector3(movimientoHorizontal, 0, movimientoVertical) * speed * Time.deltaTime;
            transform.Translate(desplazamiento);
        }

        if (gm.getPlayer()==player && gm.getBola()==bola) {
            if (Input.GetKey(KeyCode.M)) {
                if (gm.getVida(player,bola)<gm.getMaxVida(player,bola) && gm.getDinero(player)>=costoVida) {
                    gm.quitarDinero(player,costoVida);
                    gm.darVida(player,bola);
                }
            }
        }
    }

}
