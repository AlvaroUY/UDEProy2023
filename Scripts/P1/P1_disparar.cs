using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using System.Threading.Tasks;

public class P1_disparar : MonoBehaviourPunCallbacks
{
    private GameManager gm ;
    public GameObject bala;
    public Transform salidaBala;

    private float fuerza = 20f;
    private float distancia = 0.5f;

    private float tiempo = 0;

    private int player = 1; 
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
                        photonView.RPC("Disparar_RPCAsync", RpcTarget.AllBuffered, salidaBala.position, salidaBala.rotation);
                    }
                }
            }
        }
    }


    [PunRPC]
    public async Task Disparar_RPCAsync(Vector3 position, Quaternion rotation)
    {   
        //Debug.Log("entré al disparar_RPC");
        if (Time.time > tiempo) {
            GameObject bala = BalasPool.bPool.GetBala();
           // if(bala != null)
             //   Debug.Log("obtuve bala");
            Transform tr = bala.GetComponent<Transform>();
            //if(tr != null)
              //  Debug.Log("obtuve el transform");
            tr.position = position; 
            tr.rotation = rotation; 
            bala.SetActive(true);
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            //if(rb != null)
              //  Debug.Log("obtuve el Rigidbody");
            rb.velocity = tr.forward * fuerza;
            tiempo = Time.time + distancia;
           // bala.SetActive(false);
            gm.quitarBalas(player,bola);
            await Task.Delay(1500);
            bala.SetActive(false);
        }
    }
}
