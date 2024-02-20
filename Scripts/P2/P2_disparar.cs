using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_disparar : MonoBehaviour
{
    private GameManager gm ;
    public GameObject bala;
    public Transform salidaBala;

    private float fuerza = 1500;
    private float distancia = 0.5f;

    private float tiempo = 0;

    private int player = 2; 
    public int bola; 

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        if (gm.getPlayer()==player && gm.getBola()==bola) {
            if (Input.GetKey(KeyCode.Space)) {
                if (gm.getBalas(player,bola) > 0) {
                    if (Time.time > tiempo) {
                        GameObject newBala;
                        newBala = Instantiate(bala,salidaBala.position,salidaBala.rotation);
                        newBala.GetComponent<Rigidbody>().AddForce(salidaBala.forward*fuerza);
                        tiempo = Time.time + distancia;
                        Destroy(newBala,1);
                        gm.quitarBalas(player,bola);
                    }
                }
            }
        }

        if (gm.getPlayer()==player && gm.getBola()==2) {
            if (Input.GetKey(KeyCode.R)) {
                gm.recargarBofors();
            }
        }
    }
}
