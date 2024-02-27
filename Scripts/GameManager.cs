using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using Unity.VisualScripting;

using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviourPunCallbacks
{

    private int player;
    private int bola;

    public P1 P1_B1, P1_B2, P1_B3, P1_B4, P1_B5, P1_B6;
    public P2 P2_B1, P2_B2, P2_B3, P2_B4, P2_B5, P2_B6, P2_B7;
    public Transform P1_salida, P2_salida;

    public Button BTN_Nueva, BTN_Cargar;
    public Button BTN_Partida1, BTN_Partida2, BTN_Partida3, BTN_Partida4, BTN_Partida5, BTN_Volver;
    public TMP_Text TXT_Partida1, TXT_Partida2, TXT_Partida3, TXT_Partida4, TXT_Partida5;
    public int id_Partida_1, id_Partida_2, id_Partida_3, id_Partida_4, id_Partida_5;
    public ControladorDatos controladorDatos ;

    public Transform Menu, MenuInicial, MenuCargar;

    public CanvasRenderer SelectPlayer, P1_BarraSuperior, P2_BarraSuperior, POPUP_Mensajes;
    public Slider P1_B1_SliderVida, P1_B2_SliderVida, P1_B3_SliderVida, P1_B4_SliderVida, P1_B5_SliderVida, P1_B6_SliderVida;
    public Slider P2_B1_SliderVida, P2_B2_SliderVida, P2_B3_SliderVida, P2_B4_SliderVida, P2_B5_SliderVida, P2_B6_SliderVida, P2_B7_SliderVida;
    public TMP_Text P1_Dinero, P2_Dinero, TXT_Mensajes;
    public TMP_Text P1_B1_Balas, P1_B2_Balas, P1_B3_Balas, P1_B4_Balas, P1_B5_Balas, P1_B6_Balas;
    public TMP_Text P2_B1_Balas, P2_B2_Balas_C, P2_B2_Balas_M;

    private int P1_B1_maxVida, P1_B2_maxVida, P1_B3_maxVida, P1_B4_maxVida, P1_B5_maxVida, P1_B6_maxVida;
    private int P2_B1_maxVida, P2_B2_maxVida, P2_B3_maxVida, P2_B4_maxVida, P2_B5_maxVida, P2_B6_maxVida, P2_B7_maxVida;
    private int P1_B1_vida, P1_B2_vida, P1_B3_vida, P1_B4_vida, P1_B5_vida, P1_B6_vida;
    private int P2_B1_vida, P2_B2_vida, P2_B3_vida, P2_B4_vida, P2_B5_vida, P2_B6_vida, P2_B7_vida;
    private int P1_B1_maxBalas, P1_B2_maxBalas, P1_B3_maxBalas, P1_B4_maxBalas, P1_B5_maxBalas, P1_B6_maxBalas;
    private int P1_B1_balas, P1_B2_balas, P1_B3_balas, P1_B4_balas, P1_B5_balas, P1_B6_balas;
    private int P2_B1_maxBalas, P2_B2_maxCargadores, P2_B2_maxBalas, P2_B3_maxBalas;
    private int P2_B1_balas, P2_B2_cargadores, P2_B2_balas, P2_B3_balas;

    private int P1_dinero, P2_dinero;
    private bool juegoIniciado = false;
    private bool juegoTerminado = false;
    
    private int premioDerribar=100, costoBala=25, costoCargador=25;

    private void Awake() {
        mostrarMenuInicial(true);
    }
    
    public void iniciarPartida(int partida) {
        mostrarMenuInicial(false);
        player = PhotonNetwork.LocalPlayer.ActorNumber;
        bola = 1;

        POPUP_Mensajes.gameObject.SetActive(false);

        P1_B1_maxBalas = P1_B2_maxBalas = P1_B3_maxBalas = P1_B4_maxBalas = P1_B5_maxBalas = P1_B6_maxBalas = 4;
        P2_B1_maxBalas = 4;
        P1_B1_maxVida = 2;
        P1_B2_maxVida = 2;
        P1_B3_maxVida = 2;
        P1_B4_maxVida = 2;
        P1_B5_maxVida = 2;
        P1_B6_maxVida = 2;

        P2_B2_maxCargadores = 5;
        P2_B2_maxBalas = 4;
        P2_B3_maxBalas = 1;
        P2_B1_maxVida = 4; // bateria de misiles
        P2_B2_maxVida = 2; // bofors
        P2_B3_maxVida = 4; // cañon laser
        P2_B4_maxVida = 2; // radar 1
        P2_B5_maxVida = 2; // radar 2 (a bateria)
        P2_B6_maxVida = 4; // central electrica
        P2_B7_maxVida = 1; // cable

        P1_B1_SliderVida.minValue = P1_B2_SliderVida.minValue = P1_B3_SliderVida.minValue = P1_B4_SliderVida.minValue = P1_B5_SliderVida.minValue = P1_B6_SliderVida.minValue = 0;
        P2_B1_SliderVida.minValue = P2_B2_SliderVida.minValue = P2_B3_SliderVida.minValue = P2_B4_SliderVida.minValue = P2_B5_SliderVida.minValue = P2_B6_SliderVida.minValue = P2_B7_SliderVida.minValue = 0;
        P1_B1_SliderVida.maxValue = P1_B1_maxVida;
        P1_B2_SliderVida.maxValue = P1_B2_maxVida;
        P1_B3_SliderVida.maxValue = P1_B3_maxVida;
        P1_B4_SliderVida.maxValue = P1_B4_maxVida;
        P1_B5_SliderVida.maxValue = P1_B5_maxVida;
        P1_B6_SliderVida.maxValue = P1_B6_maxVida;
        P2_B1_SliderVida.maxValue = P2_B1_maxVida;
        P2_B2_SliderVida.maxValue = P2_B2_maxVida;
        P2_B3_SliderVida.maxValue = P2_B3_maxVida;
        P2_B4_SliderVida.maxValue = P2_B4_maxVida;
        P2_B5_SliderVida.maxValue = P2_B5_maxVida;
        P2_B6_SliderVida.maxValue = P2_B6_maxVida;
        P2_B7_SliderVida.maxValue = P2_B7_maxVida;

        P1_B1_SliderVida.value = P1_B1_maxVida;
        P1_B2_SliderVida.value = P1_B2_maxVida;
        P1_B3_SliderVida.value = P1_B3_maxVida;
        P1_B4_SliderVida.value = P1_B4_maxVida;
        P1_B5_SliderVida.value = P1_B5_maxVida;
        P1_B6_SliderVida.value = P1_B6_maxVida;
        P2_B1_SliderVida.value = P2_B1_maxVida;
        P2_B2_SliderVida.value = P2_B2_maxVida;
        P2_B3_SliderVida.value = P2_B3_maxVida;
        P2_B4_SliderVida.value = P2_B4_maxVida;
        P2_B5_SliderVida.value = P2_B5_maxVida;
        P2_B6_SliderVida.value = P2_B6_maxVida;
        P2_B7_SliderVida.value = P2_B7_maxVida;

        if (player==1) {
            Vector3 salida = new Vector3(P1_salida.position.x+UnityEngine.Random.Range(-20,0), P1_salida.position.y, P1_salida.position.z+UnityEngine.Random.Range(-20,20));
            Photon.Pun.PhotonNetwork.Instantiate(P1_B1.name, salida - new Vector3(-10,-5,-5), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P1_B2.name, salida - new Vector3(0,-5,-5), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P1_B3.name, salida - new Vector3(10,-5,-5), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P1_B4.name, salida - new Vector3(-10,-5,5), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P1_B5.name, salida - new Vector3(0,-5,5), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P1_B6.name, salida - new Vector3(10,-5,5), Quaternion.identity);
            P1_B1.player = P1_B2.player = P1_B3.player = P1_B4.player = P1_B5.player = P1_B6.player = player;
            P1_B1.bola = 1;
            P1_B2.bola = 2;
            P1_B3.bola = 3;
            P1_B4.bola = 4;
            P1_B5.bola = 5;
            P1_B6.bola = 6;
            P1_BarraSuperior.gameObject.SetActive(true);
            P2_BarraSuperior.gameObject.SetActive(false);
        } else {
            Vector3 salida = new Vector3(P2_salida.position.x+UnityEngine.Random.Range(0,20), P2_salida.position.y, P2_salida.position.z+UnityEngine.Random.Range(-5,5));
            Photon.Pun.PhotonNetwork.Instantiate(P2_B1.name, salida - new Vector3(5,-3,10), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P2_B2.name, salida - new Vector3(0,-3,30), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P2_B3.name, salida - new Vector3(5,-3,-5), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P2_B4.name, salida - new Vector3(5,-3,-25), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P2_B5.name, salida - new Vector3(10,-3,20), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P2_B6.name, salida - new Vector3(0,-3,-20), Quaternion.identity);
            Photon.Pun.PhotonNetwork.Instantiate(P2_B7.name, salida - new Vector3(-10,-8,-10), Quaternion.identity);
            P2_B1.player = P2_B2.player = P2_B3.player = P2_B4.player = P2_B5.player = P2_B6.player = P2_B7.player = player;
            P2_B1.bola = 1;
            P2_B2.bola = 2;
            P2_B3.bola = 3;
            P2_B4.bola = 4;
            P2_B5.bola = 5;
            P2_B6.bola = 6;
            P2_B7.bola = 7;
            P1_BarraSuperior.gameObject.SetActive(false);
            P2_BarraSuperior.gameObject.SetActive(true);
        }

        if (partida==0) {
            P1_dinero = P2_dinero = 0;
            P1_B1_balas = P1_B2_balas = P1_B3_balas = P1_B4_balas = P1_B5_balas = P1_B6_balas = P1_B1_maxBalas ;

            P2_B1_balas = P2_B1_maxBalas ;
            P2_B2_balas = P2_B2_maxBalas ;
            P2_B2_cargadores = P2_B2_maxCargadores ;
            P2_B3_balas = P2_B3_maxBalas;

            P1_B1_vida = P1_B1_maxVida;
            P1_B2_vida = P1_B2_maxVida;
            P1_B3_vida = P1_B3_maxVida;
            P1_B4_vida = P1_B4_maxVida;
            P1_B5_vida = P1_B5_maxVida;
            P1_B6_vida = P1_B6_maxVida;

            P2_B1_vida = P2_B1_maxVida;
            P2_B2_vida = P2_B2_maxVida;
            P2_B3_vida = P2_B3_maxVida;
            P2_B4_vida = P2_B4_maxVida;
            P2_B5_vida = P2_B5_maxVida;
            P2_B6_vida = P2_B6_maxVida;
            P2_B7_vida = P2_B7_maxVida;
        } else {
            switch (partida) {
                case 1: controladorDatos.LoadExterno(player,id_Partida_1); break;
                case 2: controladorDatos.LoadExterno(player,id_Partida_2); break;
                case 3: controladorDatos.LoadExterno(player,id_Partida_3); break;
                case 4: controladorDatos.LoadExterno(player,id_Partida_4); break;
                case 5: controladorDatos.LoadExterno(player,id_Partida_5); break;
            }
        }
        juegoIniciado = true;
    }

    void Update() {
        if (juegoIniciado) {
            if (Input.GetKey(KeyCode.Alpha1)) setBola(1);
            if (Input.GetKey(KeyCode.Alpha2)) setBola(2);
            if (Input.GetKey(KeyCode.Alpha3)) setBola(3);
            if (Input.GetKey(KeyCode.Alpha4)) setBola(4);
            if (Input.GetKey(KeyCode.Alpha5)) setBola(5);
            if (Input.GetKey(KeyCode.Alpha6)) setBola(6);
            if (Input.GetKey(KeyCode.Alpha7) && getPlayer()==2) setBola(7);

            if (Input.GetKey(KeyCode.C)) comprarBalas();
            refreshUI();
            // refreshVida();
            
            if (juegoIniciado && PhotonNetwork.CurrentRoom.PlayerCount < 2) {
                mostrarMensaje("Cantidad insufiente de jugadores",5);
                PhotonNetwork.Disconnect();
                mostrarMenuInicial(true);
                juegoIniciado = false;
            }
        }
    }

    /*  --- UI --- */

    public void mostrarMenuInicial (bool mostrar) {
        Menu.gameObject.SetActive(mostrar);
        MenuInicial.gameObject.SetActive(true);
        MenuCargar.gameObject.SetActive(false);
        BTN_Nueva.interactable = BTN_Cargar.interactable = true;
        if (mostrar && PhotonNetwork.IsConnected) PhotonNetwork.Disconnect();
    }
    
    public void mostrarMenuCargar (bool mostrar) {
        Menu.gameObject.SetActive(mostrar);
        MenuInicial.gameObject.SetActive(false);
        MenuCargar.gameObject.SetActive(true);
        BTN_Nueva.interactable = BTN_Cargar.interactable = true;
        BTN_Partida1.interactable = BTN_Partida2.interactable = BTN_Partida3.interactable = BTN_Partida4.interactable = BTN_Partida5.interactable = BTN_Volver.interactable = true;
        controladorDatos.ListExterno();
    }

    public void cargarBotonesPartidas(DatosPartidas datosPartidas) {
        if (datosPartidas.Partida_1.id != 0) {
            id_Partida_1 = datosPartidas.Partida_1.id; 
            TXT_Partida1.text = datosPartidas.Partida_1.fecha;
            BTN_Partida1.gameObject.SetActive(true);
        } else {
            id_Partida_1 = -1; 
            TXT_Partida1.text = "-";
            BTN_Partida1.gameObject.SetActive(false);
        }

        if (datosPartidas.Partida_2.id != 0) {
            id_Partida_2 = datosPartidas.Partida_2.id; 
            TXT_Partida2.text = datosPartidas.Partida_2.fecha;
            BTN_Partida2.gameObject.SetActive(true);
        } else {
            id_Partida_2 = -1; 
            TXT_Partida2.text = "-";
            BTN_Partida2.gameObject.SetActive(false);
        }

        if (datosPartidas.Partida_3.id != 0) {
            id_Partida_3 = datosPartidas.Partida_3.id; 
            TXT_Partida3.text = datosPartidas.Partida_3.fecha;
            BTN_Partida3.gameObject.SetActive(true);
        } else {
            id_Partida_3 = -1; 
            TXT_Partida3.text = "-";
            BTN_Partida3.gameObject.SetActive(false);
        }
        if (datosPartidas.Partida_4.id != 0) {
            id_Partida_4 = datosPartidas.Partida_4.id; 
            TXT_Partida4.text = datosPartidas.Partida_4.fecha;
            BTN_Partida4.gameObject.SetActive(true);
        } else {
            id_Partida_4 = -1; 
            TXT_Partida4.text = "-";
            BTN_Partida4.gameObject.SetActive(false);
        }
        if (datosPartidas.Partida_5.id != 0) {
            id_Partida_5 = datosPartidas.Partida_5.id; 
            TXT_Partida5.text = datosPartidas.Partida_5.fecha;
            BTN_Partida5.gameObject.SetActive(true);
        } else {
            id_Partida_5 = -1; 
            TXT_Partida5.text = "-";
            BTN_Partida5.gameObject.SetActive(false);
        }
    }

    public void mostrarMensaje (String txt, int seg) {
        TXT_Mensajes.text = txt;
        StartCoroutine(mostrarPopUp(seg));
    }

    IEnumerator mostrarPopUp(float delay) {
        yield return new WaitForSeconds(delay);
        POPUP_Mensajes.gameObject.SetActive(true);

        yield return new WaitForSeconds(delay);
        POPUP_Mensajes.gameObject.SetActive(false);
    }

    public void refreshUI() {        
        P1_Dinero.text = "$ " + getDinero(1).ToString();
        P1_B1_SliderVida.value = getVida(1,1);
        P1_B2_SliderVida.value = getVida(1,2);
        P1_B3_SliderVida.value = getVida(1,3);
        P1_B4_SliderVida.value = getVida(1,4);
        P1_B5_SliderVida.value = getVida(1,5);
        P1_B6_SliderVida.value = getVida(1,6);
        P1_B1_Balas.text = getBalas(1,1).ToString();
        P1_B2_Balas.text = getBalas(1,2).ToString();
        P1_B3_Balas.text = getBalas(1,3).ToString();
        P1_B4_Balas.text = getBalas(1,4).ToString();
        P1_B5_Balas.text = getBalas(1,5).ToString();
        P1_B6_Balas.text = getBalas(1,6).ToString();

        P2_Dinero.text = "$ " + getDinero(2).ToString();
        P2_B1_SliderVida.value = getVida(2,1);
        P2_B2_SliderVida.value = getVida(2,2);
        P2_B3_SliderVida.value = getVida(2,3);
        P2_B4_SliderVida.value = getVida(2,4);
        P2_B5_SliderVida.value = getVida(2,5);
        P2_B6_SliderVida.value = getVida(2,6);
        P2_B7_SliderVida.value = getVida(2,7);

        P2_B1_Balas.text = getBalas(2,1).ToString();
        P2_B2_Balas_C.text = P2_B2_cargadores.ToString();
        P2_B2_Balas_M.text = P2_B2_balas.ToString();

        if (juegoTerminado==false) buscarGanador();
    }

    private void buscarGanador() {
        if (getVida(1,1)==-1 && getVida(1,2)==-1 && getVida(1,3)==-1 && getVida(1,4)==-1 && getVida(1,5)==-1 && getVida(1,6)==-1) {
            mostrarMensaje("GAME OVER!\nGanador: PLAYER 2",5);
            juegoTerminado = true;
        } else if (getVida(2,1)==-1 && getVida(2,2)==-1 && getVida(2,3)==-1 && getVida(2,4)==-1 && getVida(2,5)==-1 && getVida(2,6)==-1) {
            mostrarMensaje("GAME OVER!\nGanador: PLAYER 1",5);
            juegoTerminado = true;
        } else if (
                (
                    (getVida(1,1)==-1 || (getVida(1,1)>0 && getBalas(1,1)==0)) && 
                    (getVida(1,2)==-1 || (getVida(1,2)>0 && getBalas(1,2)==0)) && 
                    (getVida(1,3)==-1 || (getVida(1,3)>0 && getBalas(1,3)==0)) && 
                    (getVida(1,4)==-1 || (getVida(1,4)>0 && getBalas(1,4)==0)) && 
                    (getVida(1,5)==-1 || (getVida(1,5)>0 && getBalas(1,5)==0)) && 
                    (getVida(1,6)==-1 || (getVida(1,6)>0 && getBalas(1,6)==0)) && 
                    getDinero(1)==0
                )
                && (
                    (
                        ((getVida(2,4)==-1 || getVida(2,6)==-1 || getVida(2,7)==-1) && getVida(2,5)==-1) ||
                        (
                            (getVida(2,1)==-1 || (getVida(2,1)>0 && getBalas(2,1)==0)) && 
                            (getVida(2,2)==-1 || (getVida(2,2)>0 && getBalas(2,2)==0 && getCargadores()==0)) && 
                            getDinero(2)==0
                        )
                    )
                )
            )
        {
            mostrarMensaje("GAME OVER!\nEmpate!",5);
            juegoTerminado = true;
        }
        if (juegoTerminado) mostrarMenuInicial(true);
    }

    public void refreshVida() {
        if (getVida(1,1)==0) {darDinero(2,premioDerribar); GameObject.FindGameObjectWithTag("P1_B1").SetActive(false); P1_B1_vida=-1;}
        if (getVida(1,2)==0) {darDinero(2,premioDerribar); GameObject.FindGameObjectWithTag("P1_B2").SetActive(false); P1_B2_vida=-1;}
        if (getVida(1,3)==0) {darDinero(2,premioDerribar); GameObject.FindGameObjectWithTag("P1_B3").SetActive(false); P1_B3_vida=-1;}
        if (getVida(1,4)==0) {darDinero(2,premioDerribar); GameObject.FindGameObjectWithTag("P1_B4").SetActive(false); P1_B4_vida=-1;}
        if (getVida(1,5)==0) {darDinero(2,premioDerribar); GameObject.FindGameObjectWithTag("P1_B5").SetActive(false); P1_B5_vida=-1;}
        if (getVida(1,6)==0) {darDinero(2,premioDerribar); GameObject.FindGameObjectWithTag("P1_B6").SetActive(false); P1_B6_vida=-1;}
        
        if (getVida(2,1)==0) {darDinero(1,premioDerribar); GameObject.FindGameObjectWithTag("P2_B1").SetActive(false); P2_B1_vida=-1;}
        if (getVida(2,2)==0) {darDinero(1,premioDerribar); GameObject.FindGameObjectWithTag("P2_B2").SetActive(false); P2_B2_vida=-1;}
        if (getVida(2,3)==0) {darDinero(1,premioDerribar); GameObject.FindGameObjectWithTag("P2_B3").SetActive(false); P2_B3_vida=-1;}
        if (getVida(2,4)==0) {darDinero(1,premioDerribar); GameObject.FindGameObjectWithTag("P2_B4").SetActive(false); P2_B4_vida=-1;}
        if (getVida(2,5)==0) {darDinero(1,premioDerribar); GameObject.FindGameObjectWithTag("P2_B5").SetActive(false); P2_B5_vida=-1;}
        if (getVida(2,6)==0) {darDinero(1,premioDerribar); GameObject.FindGameObjectWithTag("P2_B6").SetActive(false); P2_B6_vida=-1;}
        if (getVida(2,7)==0) {darDinero(1,premioDerribar); GameObject.FindGameObjectWithTag("P2_B7").SetActive(false); P2_B7_vida=-1;}
    }

    /*  --- PLAYER Y BOLAS --- */
     
    public int getPlayer() {
        return player;
    }

    public void setPlayer(int n) {
        player = n;
        bola = 1;
        SelectPlayer.gameObject.SetActive(false);
        if (player==1) {
            P1_BarraSuperior.gameObject.SetActive(true);
            P2_BarraSuperior.gameObject.SetActive(false);
        } else {
            P1_BarraSuperior.gameObject.SetActive(false);
            P2_BarraSuperior.gameObject.SetActive(true);
        }
    }

    public int getBola() {
        return bola;
    }

    public void setBola(int b) {
        bola = b;
    }


    /*  --- VIDAS --- */

    public void quitarVida(int p, int b) {
        if (p == 1) {
            switch (b) {
                case 1: if (P1_B1_vida>0) P1_B1_vida-- ; break;
                case 2: if (P1_B2_vida>0) P1_B2_vida-- ; break;
                case 3: if (P1_B3_vida>0) P1_B3_vida-- ; break;
                case 4: if (P1_B4_vida>0) P1_B4_vida-- ; break;
                case 5: if (P1_B5_vida>0) P1_B5_vida-- ; break;
                case 6: if (P1_B6_vida>0) P1_B6_vida-- ; break;
            }
        } else {
            switch (b) {
                case 1: if (P2_B1_vida>0) P2_B1_vida-- ; break;
                case 2: if (P2_B2_vida>0) P2_B2_vida-- ; break;
                case 3: if (P2_B3_vida>0) P2_B3_vida-- ; break;
                case 4: if (P2_B4_vida>0) P2_B4_vida-- ; break;
                case 5: if (P2_B5_vida>0) P2_B5_vida-- ; break;
                case 6: if (P2_B6_vida>0) P2_B6_vida-- ; break;
                case 7: if (P2_B7_vida>0) P2_B7_vida-- ; break;
            }    
        }
    }
  
    /*
    [PunRPC]
    public void MatarOponente(string id)
	{
        Debug.Log("entré al matar oponente");
		byte eventCode = 1; 
        object[] content = new object[] { id }; 
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; 
        SendOptions sendOptions = new SendOptions { Reliability = true }; 
        PhotonNetwork.RaiseEvent(eventCode, content, raiseEventOptions, sendOptions);
    }
    */

    public void darVida(int p, int b) {
        if (p == 1) {
            switch (b) {
                case 1: if (getVida(1,1)<getMaxVida(1,1)) P1_B1_vida++ ; break;
                case 2: if (getVida(1,2)<getMaxVida(1,2)) P1_B2_vida++ ; break;
                case 3: if (getVida(1,3)<getMaxVida(1,3)) P1_B3_vida++ ; break;
                case 4: if (getVida(1,4)<getMaxVida(1,4)) P1_B4_vida++ ; break;
                case 5: if (getVida(1,5)<getMaxVida(1,5)) P1_B5_vida++ ; break;
                case 6: if (getVida(1,6)<getMaxVida(1,6)) P1_B6_vida++ ; break;
            }
        } else {
            switch (b) {
                case 1: if (getVida(2,1)<getMaxVida(2,1)) P2_B1_vida++ ; break;
                case 2: if (getVida(2,2)<getMaxVida(2,2)) P2_B2_vida++ ; break;
                case 3: if (getVida(2,3)<getMaxVida(2,3)) P2_B3_vida++ ; break;
                case 4: if (getVida(2,4)<getMaxVida(2,4)) P2_B4_vida++ ; break;
                case 5: if (getVida(2,5)<getMaxVida(2,5)) P2_B5_vida++ ; break;
                case 6: if (getVida(2,6)<getMaxVida(2,6)) P2_B6_vida++ ; break;
                case 7: if (getVida(2,7)<getMaxVida(2,7)) P2_B7_vida++ ; break;
            }    
        }
    }

    public int getVida(int p, int b) {
        int vida = -1;
        if (p == 1) {
            switch (b) {
                case 1: vida = P1_B1_vida ; break;
                case 2: vida = P1_B2_vida ; break;
                case 3: vida = P1_B3_vida ; break;
                case 4: vida = P1_B4_vida ; break;
                case 5: vida = P1_B5_vida ; break;
                case 6: vida = P1_B6_vida ; break;
            }
        } else {
            switch (b) {
                case 1: vida = P2_B1_vida ; break;
                case 2: vida = P2_B2_vida ; break;
                case 3: vida = P2_B3_vida ; break;
                case 4: vida = P2_B4_vida ; break;
                case 5: vida = P2_B5_vida ; break;
                case 6: vida = P2_B6_vida ; break;
                case 7: vida = P2_B7_vida ; break;
            }    
        }
        return vida;
    }

    public void setVida (int p, int b, int v) {
        if (p == 1) {
            switch (b) {
                case 1: P1_B1_vida = v ; break;
                case 2: P1_B2_vida = v ; break;
                case 3: P1_B3_vida = v ; break;
                case 4: P1_B4_vida = v ; break;
                case 5: P1_B5_vida = v ; break;
                case 6: P1_B6_vida = v ; break;
            }
        } else {
            switch (b) {
                case 1: P2_B1_vida = v ; break;
                case 2: P2_B2_vida = v ; break;
                case 3: P2_B3_vida = v ; break;
                case 4: P2_B4_vida = v ; break;
                case 5: P2_B5_vida = v ; break;
                case 6: P2_B6_vida = v ; break;
                case 7: P2_B7_vida = v ; break;
            }    
        }
    }

    public int getMaxVida(int p, int b) {
        int vida = -1;
        if (p == 1) {
            switch (b) {
                case 1: vida = P1_B1_maxVida ; break;
                case 2: vida = P1_B2_maxVida ; break;
                case 3: vida = P1_B3_maxVida ; break;
                case 4: vida = P1_B4_maxVida ; break;
                case 5: vida = P1_B5_maxVida ; break;
                case 6: vida = P1_B6_maxVida ; break;
            }
        } else {
            switch (b) {
                case 1: vida = P1_B1_maxVida ; break;
                case 2: vida = P2_B2_maxVida ; break;
                case 3: vida = P2_B3_maxVida ; break;
                case 4: vida = P2_B4_maxVida ; break;
                case 5: vida = P2_B5_maxVida ; break;
                case 6: vida = P2_B6_maxVida ; break;
                case 7: vida = P2_B7_maxVida ; break;
            }    
        }
        return vida;
    }


    /*  --- DINERO --- */

    public void quitarBalas(int p, int b) {
        if (p == 1) {
            switch (b) {
                case 1: P1_B1_balas-- ; break;
                case 2: P1_B2_balas-- ; break;
                case 3: P1_B3_balas-- ; break;
                case 4: P1_B4_balas-- ; break;
                case 5: P1_B5_balas-- ; break;
                case 6: P1_B6_balas-- ; break;
            }
        } else {
            switch (b) {
                case 1: P2_B1_balas-- ; break;
                case 2: P2_B2_balas-- ; break;
            }
        }
    }

    public int getBalas(int p, int b) {
        int balas = -1;
        if (p == 1) {
            switch (b) {
                case 1: balas = P1_B1_balas ; break;
                case 2: balas = P1_B2_balas ; break;
                case 3: balas = P1_B3_balas ; break;
                case 4: balas = P1_B4_balas ; break;
                case 5: balas = P1_B5_balas ; break;
                case 6: balas = P1_B6_balas ; break;
            }
        } else {
            switch (b) {
                case 1: balas = P2_B1_balas ; break;
                case 2: balas = P2_B2_balas ; break;
            }
        }
        return balas;
    }

    public void setBalas(int p, int b, int balas) {
        if (p == 1) {
            switch (b) {
                case 1: P1_B1_balas = balas; break;
                case 2: P1_B2_balas = balas ; break;
                case 3: P1_B3_balas = balas ; break;
                case 4: P1_B4_balas = balas ; break;
                case 5: P1_B5_balas = balas ; break;
                case 6: P1_B6_balas = balas ; break;
            }
        } else {
            switch (b) {
                case 1: P2_B1_balas = balas ; break;
                case 2: P2_B2_balas = balas ; break;
            }
        }
    }

    public void setCargadores(int cargadores) {
        P2_B2_cargadores = cargadores;
    }

    public int getCargadores() {
        return P2_B2_cargadores;
    }

    public void recargarBofors() {
        if (P2_B2_cargadores>0 && P2_B2_balas==0) {
            P2_B2_cargadores--;
            P2_B2_balas += 4;
        }
    }

    public void comprarBalas() {
        if (player == 1) {
            switch (bola) {
                case 1: if (P1_dinero-costoBala>=0 && P1_B1_balas<P1_B1_maxBalas) {P1_B1_balas++; P1_dinero=P1_dinero-costoBala;} break;
                case 2: if (P1_dinero-costoBala>=0 && P1_B2_balas<P1_B2_maxBalas) {P1_B2_balas++; P1_dinero=P1_dinero-costoBala;} break;
                case 3: if (P1_dinero-costoBala>=0 && P1_B3_balas<P1_B3_maxBalas) {P1_B3_balas++; P1_dinero=P1_dinero-costoBala;} break;
                case 4: if (P1_dinero-costoBala>=0 && P1_B4_balas<P1_B4_maxBalas) {P1_B4_balas++; P1_dinero=P1_dinero-costoBala;} break;
                case 5: if (P1_dinero-costoBala>=0 && P1_B5_balas<P1_B5_maxBalas) {P1_B5_balas++; P1_dinero=P1_dinero-costoBala;} break;
                case 6: if (P1_dinero-costoBala>=0 && P1_B6_balas<P1_B6_maxBalas) {P1_B6_balas++; P1_dinero=P1_dinero-costoBala;} break;
            }
        } else {
            switch (bola) {
                case 1: if (P2_dinero-costoBala>=0 && P2_B1_balas<P2_B1_maxBalas) {P2_B1_balas++; P2_dinero=P2_dinero-costoBala;} break;
                case 2: if (P2_dinero-costoCargador>=0) {P2_B2_cargadores++; P2_dinero=P2_dinero-costoCargador;} break;
            }
        }
    }

    public int getMaxBalas(int p, int b) {
        int balas = -1;
        if (p == 1) {
            switch (b) {
                case 1: balas = P1_B1_maxBalas ; break;
                case 2: balas = P1_B2_maxBalas ; break;
                case 3: balas = P1_B3_maxBalas ; break;
                case 4: balas = P1_B4_maxBalas ; break;
                case 5: balas = P1_B5_maxBalas ; break;
                case 6: balas = P1_B6_maxBalas ; break;
            }
        } else {
            switch (b) {
                case 1: balas = P1_B1_maxBalas ; break;
                case 2: balas = P2_B2_maxBalas ; break;
            }
        }
        return balas;
    }


    /*  --- DINERO --- */

    public void darDinero(int p, int d) {
        if (p == 1)
            P1_dinero += d ;
        else
            P2_dinero += d ;
    }

    public void quitarDinero(int p, int d) {
        if (p == 1)
            P1_dinero -= d ;
        else
            P2_dinero -= d ;
    }

    public int getDinero(int p) {
        if (p == 1)
            return P1_dinero;
        else
            return P2_dinero;
    }

    public void setDinero(int p, int d) {
        if (p == 1)
            P1_dinero = d;
        else
            P2_dinero = d;
    }

}
