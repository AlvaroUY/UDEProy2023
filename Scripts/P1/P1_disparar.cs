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
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (gm.getBalas(player,bola) > 0) {
                    if (Time.time > tiempo) {
                        photonView.RPC("Disparar_RPCAsync", RpcTarget.AllBuffered, salidaBala.position, salidaBala.rotation);
                    }
                }
            }
        }
    }


    [PunRPC]
    public IEnumerator Disparar_RPCAsync(Vector3 position, Quaternion rotation)
    {
        if (Time.time > tiempo) {
            GameObject bala = BalasPool.bPool.GetBala();
            Transform tr = bala.GetComponent<Transform>();
            gm.quitarBalas(player,bola);
            bala.SetActive(true);
            tr.position = position; 
            tr.rotation = rotation; 
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            rb.velocity = tr.forward * fuerza;
            tiempo = Time.time + distancia;
            yield return new WaitForSeconds(3);
            bala.gameObject.SetActive(false);
        }
    }

}
