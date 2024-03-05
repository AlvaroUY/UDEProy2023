using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Properties;
using UnityEngine;

public class Vision : MonoBehaviour
{
    private GameManager gm ;
    Camera camaraAerea, camaraLateral;

    private float distanciaBase=60, distanciaDron=60, distanciaRadar=120;

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
        camaraAerea = GameObject.Find("CamaraAerea").GetComponent<Camera>();
        camaraLateral = GameObject.Find("CamaraLateral").GetComponent<Camera>();
    }

    void Update()
    {
        refreshVision();
    }

    public void refreshVision() {
        if (gm.player == 1) {
            for (int i=1; i<=7; i++) {
                if (gm.getVida(2,i)>0) {
                    GameObject P2_B = GameObject.FindGameObjectWithTag("P2_B"+i);
                    bool loVeo = false;
                    int j = 1;
                    while (!loVeo && j<=6) {
                        if (gm.getVida(1,j)>0) {
                            GameObject P1_B = GameObject.FindGameObjectWithTag("P1_B"+j);
                            if (P1_B != null && P2_B != null && Vector3.Distance(P1_B.transform.position, P2_B.transform.position) < distanciaDron) {
                                loVeo = true;
                            } else
                                j++;
                        } else
                            j++;
                    }
                    if (P2_B != null) {if (loVeo) Mostrar(P2_B.tag); else Ocultar(P2_B.tag);}
                }
            }
        } else {
            for (int i=1; i<=6; i++) {
                if (gm.getVida(1,i)>0) {
                    GameObject P1_B = GameObject.FindGameObjectWithTag("P1_B"+i);
                    bool loVeo = false;
                    int j = 1;
                    while (!loVeo && j<=7) {
                        if (gm.getVida(2,j)>0) {
                            GameObject P2_B = GameObject.FindGameObjectWithTag("P2_B"+j);
                            float distancia = distanciaBase;
                            if (j==4 || j==5) distancia = distanciaRadar;
                            if (P1_B != null && P2_B != null && Vector3.Distance(P1_B.transform.position, P2_B.transform.position) < distancia) {
                                loVeo = true;
                            } else
                                j++;
                        } else
                            j++;
                    }
                    if (P1_B != null) {if (loVeo) Mostrar(P1_B.tag); else Ocultar(P1_B.tag);}
                }
            }
        }
    }

    void Ocultar(string bola) {
        camaraAerea.cullingMask &= ~(1 << LayerMask.NameToLayer(bola));
        camaraLateral.cullingMask &= ~(1 << LayerMask.NameToLayer(bola));
    }

    void Mostrar(string bola) {
        camaraAerea.cullingMask |= 1 << LayerMask.NameToLayer(bola);
        camaraLateral.cullingMask |= 1 << LayerMask.NameToLayer(bola);
    }

}
