using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_movimiento : Photon.Pun.MonoBehaviourPun
{
    public float speedRotate, speedTraslate ;
    internal Transform tr;
    Rigidbody rg;
    private GameManager gm ;

    public int player; 
    public int bola; 

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
            if (Math.Abs(transform.position.x)<260 && Math.Abs(transform.position.z)<260) {
                var y = Input.GetAxis ("Horizontal") * Time.deltaTime * speedRotate;
                var x = Input.GetAxis("Vertical") * Time.deltaTime * speedTraslate;
                transform.Rotate(0,y,0);
                transform.Translate(-x,0,0);
            } else {
                if (transform.position.x>=260) transform.position = new Vector3(259,transform.position.y,transform.position.z);
                else if (transform.position.x<=-260) transform.position = new Vector3(-259,transform.position.y,transform.position.z);
                
                if (transform.position.z>=260) transform.position = new Vector3(transform.position.x,transform.position.y,259);
                else if (transform.position.z<=-260) transform.position = new Vector3(transform.position.x,transform.position.y,-259);
            }
        }
    }

    private void OnCollisionEnter (Collision collision) {
        if (collision.transform.CompareTag("missil")) collision.gameObject.SetActive(false);
    }

}
