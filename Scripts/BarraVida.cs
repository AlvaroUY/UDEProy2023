using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image P1_B1_barraVida, P1_B2_barraVida, P1_B3_barraVida;
    public float vidaMaxima, vidaActual;

    public void setVidaMaxima(float v) {
        vidaMaxima = v;
    }

    public void setVidaActual(float v) {
        vidaActual = v;
    }

    void Update()
    {
        P1_B1_barraVida.fillAmount = vidaActual / vidaMaxima;
    }

}
