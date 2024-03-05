using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class P2_dispararLaser : MonoBehaviourPunCallbacks
{
    private GameManager gm ;
    public GameObject bala;
    public Transform salidaBala1;
    public Transform salidaBala2;

    private float distancia = 0.3f;

    private float tiempo = 0;

    private int player = 2; 
    public int bola; 

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        if (gm.getPlayer()==player && gm.getBola()==bola) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (Time.time > tiempo) {
                    photonView.RPC("DispararLaser_RPC", RpcTarget.AllBuffered, salidaBala1.position, salidaBala1.rotation);
                    photonView.RPC("DispararLaser_RPC", RpcTarget.AllBuffered, salidaBala2.position, salidaBala2.rotation);
                    tiempo = Time.time + distancia;
                }
            }
        }
    }

    [PunRPC]
    public IEnumerator DispararLaser_RPC(Vector3 position, Quaternion rotation)
    {   
        GameObject bala = BalasPoolLaser.lPool.GetBala();
        Transform tr = bala.GetComponent<Transform>();
        tr.position = position; 
        tr.rotation = rotation; 
        bala.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        bala.gameObject.SetActive(false);
    }
    
}
