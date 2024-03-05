using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Photon.Pun;

public class ControladorDatos : MonoBehaviourPunCallbacks
{
    private static String url = "http://aaserver:8080/Drones";
    public DatosJuego datosJuego = new DatosJuego();
    public DatosPartidas datosPartidas = new DatosPartidas();
    private GameManager gm ;

    public GameObject P1_B1, P1_B2, P1_B3, P1_B4, P1_B5, P1_B6;
    public GameObject P2_B1, P2_B2, P2_B3, P2_B4, P2_B5, P2_B6, P2_B7;

    void Awake() {
        gm = FindAnyObjectByType<GameManager>();
    }

    public void ListExterno () {
        StartCoroutine(List());
    }

    public void LoadExterno (int player, int id) {
        StartCoroutine(Load(player,id));
    }

    public void SaveExterno () {
        if (!gm.juegoTerminado) 
            StartCoroutine(Save());
        else
            gm.mostrarMensaje("No es posible guardar una partida finalizada",2);
    }

    private void buscarGameObjects(int player) {
        if (player==1) {
            if (gm.getVida(1,1)>0) P1_B1 = GameObject.FindGameObjectWithTag("P1_B1"); else P1_B1 = new GameObject();
            if (gm.getVida(1,2)>0) P1_B2 = GameObject.FindGameObjectWithTag("P1_B2"); else P1_B2 = new GameObject();
            if (gm.getVida(1,3)>0) P1_B3 = GameObject.FindGameObjectWithTag("P1_B3"); else P1_B3 = new GameObject();
            if (gm.getVida(1,4)>0) P1_B4 = GameObject.FindGameObjectWithTag("P1_B4"); else P1_B4 = new GameObject();
            if (gm.getVida(1,5)>0) P1_B5 = GameObject.FindGameObjectWithTag("P1_B5"); else P1_B5 = new GameObject();
            if (gm.getVida(1,6)>0) P1_B6 = GameObject.FindGameObjectWithTag("P1_B6"); else P1_B6 = new GameObject();
        } else {
            if (gm.getVida(2,1)>0) P2_B1 = GameObject.FindGameObjectWithTag("P2_B1"); else P2_B1 = new GameObject();
            if (gm.getVida(2,2)>0) P2_B2 = GameObject.FindGameObjectWithTag("P2_B2"); else P2_B2 = new GameObject();
            if (gm.getVida(2,3)>0) P2_B3 = GameObject.FindGameObjectWithTag("P2_B3"); else P2_B3 = new GameObject();
            if (gm.getVida(2,4)>0) P2_B4 = GameObject.FindGameObjectWithTag("P2_B4"); else P2_B4 = new GameObject();
            if (gm.getVida(2,5)>0) P2_B5 = GameObject.FindGameObjectWithTag("P2_B5"); else P2_B5 = new GameObject();
            if (gm.getVida(2,6)>0) P2_B6 = GameObject.FindGameObjectWithTag("P2_B6"); else P2_B6 = new GameObject();
            if (gm.getVida(2,7)>0) P2_B7 = GameObject.FindGameObjectWithTag("P2_B7"); else P2_B7 = new GameObject();
        }
    }

    IEnumerator List() {

        WWWForm formData = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Post(url+"/List", formData);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
            gm.mostrarMensaje("Error al obtener partidas",2);
        else {
            if (www.downloadHandler.text != "ERROR") {
                datosPartidas = JsonUtility.FromJson<DatosPartidas>(www.downloadHandler.text);
                gm.cargarBotonesPartidas(datosPartidas);
            } else
                gm.mostrarMensaje("Error al obtener partidas",2);
        }
    }

    IEnumerator Load(int player, int id) {

        WWWForm formData = new WWWForm();
        formData.AddField("id", id);

        UnityWebRequest www = UnityWebRequest.Post(url+"/Load", formData);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
            gm.mostrarMensaje("Error al cargar partida",2);
        else {
            datosJuego = JsonUtility.FromJson<DatosJuego>(www.downloadHandler.text);
            if (player==1) {
                gm.setDinero(1,datosJuego.P1_dinero);
                gm.posicionarBola(1,1,datosJuego.P1_B1_position);
                gm.posicionarBola(1,2,datosJuego.P1_B2_position);
                gm.posicionarBola(1,3,datosJuego.P1_B3_position);
                gm.posicionarBola(1,4,datosJuego.P1_B4_position);
                gm.posicionarBola(1,5,datosJuego.P1_B5_position);
                gm.posicionarBola(1,6,datosJuego.P1_B6_position);
                gm.setVida(1,1,datosJuego.P1_B1_vida);
                gm.setVida(1,2,datosJuego.P1_B2_vida);
                gm.setVida(1,3,datosJuego.P1_B3_vida);
                gm.setVida(1,4,datosJuego.P1_B4_vida);
                gm.setVida(1,5,datosJuego.P1_B5_vida);
                gm.setVida(1,6,datosJuego.P1_B6_vida);
                gm.setBalas(1,1,datosJuego.P1_B1_balas);
                gm.setBalas(1,2,datosJuego.P1_B2_balas);
                gm.setBalas(1,3,datosJuego.P1_B3_balas);
                gm.setBalas(1,4,datosJuego.P1_B4_balas);
                gm.setBalas(1,5,datosJuego.P1_B5_balas);
                gm.setBalas(1,6,datosJuego.P1_B6_balas);
            } else {
                gm.setDinero(2,datosJuego.P2_dinero);
                gm.posicionarBola(2,1,datosJuego.P2_B1_position);
                gm.posicionarBola(2,2,datosJuego.P2_B2_position);
                gm.posicionarBola(2,3,datosJuego.P2_B3_position);
                gm.posicionarBola(2,4,datosJuego.P2_B4_position);
                gm.posicionarBola(2,5,datosJuego.P2_B5_position);
                gm.posicionarBola(2,6,datosJuego.P2_B6_position);
                gm.posicionarBola(2,7,datosJuego.P2_B7_position);
                gm.setVida(2,1,datosJuego.P2_B1_vida);
                gm.setVida(2,2,datosJuego.P2_B2_vida);
                gm.setVida(2,3,datosJuego.P2_B3_vida);
                gm.setVida(2,4,datosJuego.P2_B4_vida);
                gm.setVida(2,5,datosJuego.P2_B5_vida);
                gm.setVida(2,6,datosJuego.P2_B6_vida);
                gm.setVida(2,7,datosJuego.P2_B7_vida);
                gm.setBalas(2,1,datosJuego.P2_B1_balas);
                gm.setBalas(2,2,datosJuego.P2_B2_balas);
                gm.setCargadores(datosJuego.P2_B2_cargadores);
            }
        }
    }

    IEnumerator Save() {
        buscarGameObjects(1);
        buscarGameObjects(2);

        DatosJuego nuevosDatos = new DatosJuego() {
            P1_dinero = gm.getDinero(1),
            P1_B1_position = P1_B1.transform.position,
            P1_B1_vida = gm.getVida(1,1),
            P1_B1_balas = gm.getBalas(1,1),
            P1_B2_position = P1_B2.transform.position,
            P1_B2_vida = gm.getVida(1,2),
            P1_B2_balas = gm.getBalas(1,2),
            P1_B3_position = P1_B3.transform.position,
            P1_B3_vida = gm.getVida(1,3),
            P1_B3_balas = gm.getBalas(1,3),
            P1_B4_position = P1_B4.transform.position,
            P1_B4_vida = gm.getVida(1,4),
            P1_B4_balas = gm.getBalas(1,4),
            P1_B5_position = P1_B5.transform.position,
            P1_B5_vida = gm.getVida(1,5),
            P1_B5_balas = gm.getBalas(1,5),
            P1_B6_position = P1_B6.transform.position,
            P1_B6_vida = gm.getVida(1,6),
            P1_B6_balas = gm.getBalas(1,6),

            P2_dinero = gm.getDinero(2),
            P2_B1_position = P2_B1.transform.position,
            P2_B1_vida = gm.getVida(2,1),
            P2_B1_balas = gm.getBalas(2,1),
            P2_B2_position = P2_B2.transform.position,
            P2_B2_vida = gm.getVida(2,2),
            P2_B2_balas = gm.getBalas(2,2),
            P2_B2_cargadores = gm.getCargadores(),
            P2_B3_position = P2_B3.transform.position,
            P2_B3_vida = gm.getVida(2,3),
            P2_B4_position = P2_B4.transform.position,
            P2_B4_vida = gm.getVida(2,4),
            P2_B5_position = P2_B5.transform.position,
            P2_B5_vida = gm.getVida(2,5),
            P2_B6_position = P2_B6.transform.position,
            P2_B6_vida = gm.getVida(2,6),
            P2_B7_position = P2_B7.transform.position,
            P2_B7_vida = gm.getVida(2,7)
        };
        String cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        WWWForm formData = new WWWForm();
        formData.AddField("data", cadenaJSON);

        UnityWebRequest www = UnityWebRequest.Post(url+"/Save", formData);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
            gm.mostrarMensaje("Error al guardar partida",2);
        else {
            if (www.downloadHandler.text != "ERROR")
                gm.mostrarMensaje("Partida guardada",2);
            else
                gm.mostrarMensaje("Error al guardar partida",2);
        }
    }

}
