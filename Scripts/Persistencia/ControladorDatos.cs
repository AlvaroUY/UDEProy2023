using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControladorDatos : MonoBehaviour
{
    private static String url = "http://localhost:8080/Drones";
    public DatosJuego datosJuego = new DatosJuego();
    public DatosPartidas datosPartidas = new DatosPartidas();
    private GameManager gm ;

    public GameObject P1_B1, P1_B2, P1_B3, P1_B4, P1_B5, P1_B6, P2_B1, P2_B2, P2_B3, P2_B4, P2_B5, P2_B6, P2_B7;

    void Awake() {
        gm = FindAnyObjectByType<GameManager>();
    }

    
    void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            StartCoroutine(List());
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            StartCoroutine(Load(357));
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            StartCoroutine(Save());
        }
    }
    

    public void ListExterno () {
        StartCoroutine(List());
        //return datosPartidas;
    }

    public void LoadExterno (int id) {
        StartCoroutine(Load(id));
    }

    public void SaveExterno () {
        gm.mostrarMensaje("Partida guardada",2);
        StartCoroutine(Save());
    }

    IEnumerator List() {

        WWWForm formData = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Post(url+"/List", formData);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
            Debug.Log(www.error);
        else {
            Debug.Log("Envio OK!");
            Debug.Log("Recibido: " + www.downloadHandler.text);
            datosPartidas = JsonUtility.FromJson<DatosPartidas>(www.downloadHandler.text);
            Debug.Log("Partida_1: " + datosPartidas.Partida_1.id + " - " + datosPartidas.Partida_1.fecha);
            Debug.Log("Partida_2: " + datosPartidas.Partida_2.id + " - " + datosPartidas.Partida_2.fecha);
            Debug.Log("Partida_3: " + datosPartidas.Partida_3.id + " - " + datosPartidas.Partida_3.fecha);
            Debug.Log("Partida_4: " + datosPartidas.Partida_4.id + " - " + datosPartidas.Partida_4.fecha);
            Debug.Log("Partida_5: " + datosPartidas.Partida_5.id + " - " + datosPartidas.Partida_5.fecha);
            //gm.cargarBotonesPartidas(datosPartidas);
        }
    }

    IEnumerator Load(int id) {

        WWWForm formData = new WWWForm();
        formData.AddField("id", id);

        UnityWebRequest www = UnityWebRequest.Post(url+"/Load", formData);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
            Debug.Log(www.error);
        else {
            Debug.Log("Envio OK!");
            datosJuego = JsonUtility.FromJson<DatosJuego>(www.downloadHandler.text);
            Debug.Log("P1 - Dinero: " + datosJuego.P1_dinero);
            Debug.Log("P1_B1 - Posicion: " + datosJuego.P1_B1_position + " - vida: " + datosJuego.P1_B1_vida + " - balas: " + datosJuego.P1_B1_balas);
            Debug.Log("P1_B2 - Posicion: " + datosJuego.P1_B2_position + " - vida: " + datosJuego.P1_B2_vida + " - balas: " + datosJuego.P1_B2_balas);
            Debug.Log("P1_B3 - Posicion: " + datosJuego.P1_B3_position + " - vida: " + datosJuego.P1_B3_vida + " - balas: " + datosJuego.P1_B3_balas);
            Debug.Log("P1_B4 - Posicion: " + datosJuego.P1_B4_position + " - vida: " + datosJuego.P1_B4_vida + " - balas: " + datosJuego.P1_B4_balas);
            Debug.Log("P1_B5 - Posicion: " + datosJuego.P1_B5_position + " - vida: " + datosJuego.P1_B5_vida + " - balas: " + datosJuego.P1_B5_balas);
            Debug.Log("P1_B6 - Posicion: " + datosJuego.P1_B6_position + " - vida: " + datosJuego.P1_B6_vida + " - balas: " + datosJuego.P1_B6_balas);
            Debug.Log("P2 - Dinero: " + datosJuego.P2_dinero);
            Debug.Log("P2_B1 - Posicion: " + datosJuego.P2_B1_position + " - vida: " + datosJuego.P2_B1_vida + " - balas: " + datosJuego.P2_B1_balas);
            Debug.Log("P2_B2 - Posicion: " + datosJuego.P2_B2_position + " - vida: " + datosJuego.P2_B2_vida + " - balas: " + datosJuego.P2_B2_balas + " - cargadores: " + datosJuego.P2_B2_cargadores);
            Debug.Log("P2_B3 - Posicion: " + datosJuego.P2_B3_position + " - vida: " + datosJuego.P2_B3_vida);
            Debug.Log("P2_B4 - Posicion: " + datosJuego.P2_B4_position + " - vida: " + datosJuego.P2_B4_vida);
            Debug.Log("P2_B5 - Posicion: " + datosJuego.P2_B5_position + " - vida: " + datosJuego.P2_B5_vida);
            Debug.Log("P2_B6 - Posicion: " + datosJuego.P2_B6_position + " - vida: " + datosJuego.P2_B6_vida);
            Debug.Log("P2_B7 - Posicion: " + datosJuego.P2_B7_position + " - vida: " + datosJuego.P2_B7_vida);

            P1_B1 = GameObject.FindGameObjectWithTag("P1_B1");
            P1_B2 = GameObject.FindGameObjectWithTag("P1_B2");
            P1_B3 = GameObject.FindGameObjectWithTag("P1_B3");
            P1_B4 = GameObject.FindGameObjectWithTag("P1_B4");
            P1_B5 = GameObject.FindGameObjectWithTag("P1_B5");
            P1_B6 = GameObject.FindGameObjectWithTag("P1_B6");
            
            P2_B1 = GameObject.FindGameObjectWithTag("P2_B1");
            P2_B2 = GameObject.FindGameObjectWithTag("P2_B2");
            P2_B3 = GameObject.FindGameObjectWithTag("P2_B3");
            P2_B4 = GameObject.FindGameObjectWithTag("P2_B4");
            P2_B5 = GameObject.FindGameObjectWithTag("P2_B5");
            P2_B6 = GameObject.FindGameObjectWithTag("P2_B6");
            P2_B6 = GameObject.FindGameObjectWithTag("P2_B7");
            
            gm.setDinero(1,datosJuego.P1_dinero);
            P1_B1.transform.position = datosJuego.P1_B1_position;
            P1_B2.transform.position = datosJuego.P1_B2_position;
            P1_B3.transform.position = datosJuego.P1_B3_position;
            P1_B4.transform.position = datosJuego.P1_B4_position;
            P1_B5.transform.position = datosJuego.P1_B5_position;
            P1_B6.transform.position = datosJuego.P1_B6_position;
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

            gm.setDinero(2,datosJuego.P2_dinero);
            P2_B1.transform.position = datosJuego.P2_B1_position;
            P2_B2.transform.position = datosJuego.P2_B2_position;
            P2_B3.transform.position = datosJuego.P2_B3_position;
            P2_B4.transform.position = datosJuego.P2_B4_position;
            P2_B5.transform.position = datosJuego.P2_B5_position;
            P2_B6.transform.position = datosJuego.P2_B6_position;
            P2_B7.transform.position = datosJuego.P2_B7_position;
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

    IEnumerator Save() {
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

            P2_dinero = gm.getDinero(1),
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
            Debug.Log(www.error);
        else {
            Debug.Log("Envio OK!");
            Debug.Log("Recibido: " + www.downloadHandler.text);
        }
    }

}
