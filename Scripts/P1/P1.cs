using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class P1 : Photon.Pun.MonoBehaviourPun
{
    public float speed = 5f ;
    internal Transform tr;
    Rigidbody rg;
    private GameManager gm ;

    public int player; 
    public int bola; 
    //public int costoVida = 100; 

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
            /*
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");
            //float movimientoArriba = Input.GetAxis("Fire1");
            //float movimientoAbajo = Input.GetAxis("Fire2");
            //Vector3 desplazamiento = new Vector3(movimientoHorizontal, movimientoArriba - movimientoAbajo, movimientoVertical) * speed * Time.deltaTime;
            Vector3 desplazamiento = new Vector3(movimientoHorizontal, 0, movimientoVertical) * speed * Time.deltaTime;
            transform.Translate(desplazamiento);
            */
            var y = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
            var x = Input.GetAxis("Vertical") * Time.deltaTime * 30.0f;
            transform.Rotate(0,y,0);
            transform.Translate(x,0,0);
        }

        /*
        if (gm.getPlayer()==player && gm.getBola()==bola) {
            if (Input.GetKey(KeyCode.M)) {
                if (gm.getVida(player,bola)<gm.getMaxVida(player,bola) && gm.getDinero(player)>=costoVida) {
                    gm.quitarDinero(player,costoVida);
                    gm.darVida(player,bola);
                }
            }
        }
        */
    }

}
