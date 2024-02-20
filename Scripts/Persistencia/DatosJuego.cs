using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DatosJuego
{
    public int P1_dinero, P2_dinero;

    public Vector3 P1_B1_position, P1_B2_position, P1_B3_position, P1_B4_position, P1_B5_position, P1_B6_position;
    public Vector3 P2_B1_position, P2_B2_position, P2_B3_position, P2_B4_position, P2_B5_position, P2_B6_position, P2_B7_position;
    
    public int P1_B1_vida, P1_B2_vida, P1_B3_vida, P1_B4_vida, P1_B5_vida, P1_B6_vida;
    public int P2_B1_vida, P2_B2_vida, P2_B3_vida, P2_B4_vida, P2_B5_vida, P2_B6_vida, P2_B7_vida;

    public int P1_B1_balas, P1_B2_balas, P1_B3_balas, P1_B4_balas, P1_B5_balas, P1_B6_balas;
    public int P2_B1_balas, P2_B2_balas, P2_B2_cargadores;
}
