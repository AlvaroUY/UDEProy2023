using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraAerea : MonoBehaviour
{
    public Transform player;

    private GameManager gm ;

    private int alturaInicial=175, altura, alturaFinal=75;
    private bool iniciado = false;

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
        altura = alturaInicial;
    }
    
    void Update () {
        try {
            GameObject unidad = GameObject.FindGameObjectWithTag("P"+gm.getPlayer()+"_B"+gm.getBola());
            player = unidad.transform;
            iniciado = true;
            if (iniciado) {
                transform.position = player.transform.position + new Vector3(0,altura,-10);
                if (altura>alturaFinal) altura--;
            }
        } catch {
            bool encontre = false;
            int i = 1;
            while (!encontre && i<=6) if (gm.getVida(gm.getPlayer(),i)>0) encontre=true; else i++;
            if (encontre) {
                gm.setBola(i);
                GameObject unidad = GameObject.FindGameObjectWithTag("P"+gm.getPlayer()+"_B"+i);
                player = unidad.transform;
                transform.position = player.transform.position + new Vector3(0,altura,-10);
            } 
        }
    }

}
