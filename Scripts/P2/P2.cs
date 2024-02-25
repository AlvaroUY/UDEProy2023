using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : Photon.Pun.MonoBehaviourPun
{
    public float speed = 5f ;
    internal Transform tr;
    Rigidbody rg;
    private GameManager gm ;

    public int player; 
    public int bola; 
    public int costoVida = 100; 

    public bool initialized = false;

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
    }

    private void OnEnable()
    {
        if (!initialized){
            Initialize();
        }
    }

    void Initialize()
    {
        tr = this.transform;
        rg = GetComponent<Rigidbody>();
        initialized = true;
    }

    void Update()
    {
        if (player==gm.getPlayer() && photonView.IsMine && gm.getBola()==bola) {
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
