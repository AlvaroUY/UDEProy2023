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

public class GameManager : MonoBehaviour
{
    private int player;
    private int bola;

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
    private bool juegoTerminado = false;
    
    void Awake() {
        P1_dinero = P2_dinero = 0;
        P1_B1_maxBalas = P1_B2_maxBalas = P1_B3_maxBalas = P1_B4_maxBalas = P1_B5_maxBalas = P1_B6_maxBalas = 4;
        P1_B1_balas = P1_B2_balas = P1_B3_balas = P1_B4_balas = P1_B5_balas = P1_B6_balas = P1_B1_maxBalas ;

        P2_B1_maxBalas = 4;
        P2_B2_maxCargadores = 5;
        P2_B2_maxBalas = 4;
        P2_B3_maxBalas = 1;
        P2_B1_balas = P2_B1_maxBalas ;
        P2_B2_balas = P2_B2_maxBalas ;
        P2_B2_cargadores = P2_B2_maxCargadores ;
        P2_B3_balas = P2_B3_maxBalas;

        P1_B1_maxVida = 2;
        P1_B2_maxVida = 2;
        P1_B3_maxVida = 2;
        P1_B4_maxVida = 2;
        P1_B5_maxVida = 2;
        P1_B6_maxVida = 2;

        P2_B1_maxVida = 4; // bateria de misiles
        P2_B2_maxVida = 2; // bofors
        P2_B3_maxVida = 4; // cañon laser
        P2_B4_maxVida = 2; // radar 1
        P2_B5_maxVida = 2; // radar 2 (a bateria)
        P2_B6_maxVida = 4; // central electrica
        P2_B7_maxVida = 1; // cable

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

        P1_BarraSuperior.gameObject.SetActive(false);
        P2_BarraSuperior.gameObject.SetActive(false);
        POPUP_Mensajes.gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKey(KeyCode.Alpha1)) setBola(1);
        if (Input.GetKey(KeyCode.Alpha2)) setBola(2);
        if (Input.GetKey(KeyCode.Alpha3)) setBola(3);
        if (Input.GetKey(KeyCode.Alpha4)) setBola(4);
        if (Input.GetKey(KeyCode.Alpha5)) setBola(5);
        if (Input.GetKey(KeyCode.Alpha6)) setBola(6);
        if (Input.GetKey(KeyCode.Alpha7) && getPlayer()==2) setBola(7);
        refreshUI();
       // refreshVida();
    }

    /*  --- UI --- */

    public void mostrarMensaje (String txt) {
        TXT_Mensajes.text = txt;
        StartCoroutine(mostrarPopUp(2));
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
        if (getVida(1,1)==-1 && +getVida(1,2)==-1 && getVida(1,3)==-1 && getVida(1,4)==-1 && +getVida(1,5)==-1 && getVida(1,6)==-1) {
            mostrarMensaje("GAME OVER!\nGanador: PLAYER 2");
            juegoTerminado = true;
        } else if (getVida(2,1)==-1 && +getVida(2,2)==-1 && getVida(2,3)==-1 && getVida(2,4)==-1 && +getVida(2,5)==-1 && getVida(2,6)==-1) {
            mostrarMensaje("GAME OVER!\nGanador: PLAYER 1");
            juegoTerminado = true;
        }
    }

    public void refreshVida() {
        if (getVida(1,1)==0) {darDinero(2,100); GameObject.Find("P1_B1").SetActive(false); P1_B1_vida=-1;}
        if (getVida(1,2)==0) {darDinero(2,100); GameObject.Find("P1_B2").SetActive(false); P1_B2_vida=-1;}
        if (getVida(1,3)==0) {darDinero(2,100); GameObject.Find("P1_B3").SetActive(false); P1_B3_vida=-1;}
        if (getVida(1,4)==0) {darDinero(2,100); GameObject.Find("P1_B4").SetActive(false); P1_B4_vida=-1;}
        if (getVida(1,5)==0) {darDinero(2,100); GameObject.Find("P1_B5").SetActive(false); P1_B5_vida=-1;}
        if (getVida(1,6)==0) {darDinero(2,100); GameObject.Find("P1_B6").SetActive(false); P1_B6_vida=-1;}
        
        if (getVida(2,1)==0) {darDinero(1,100); GameObject.Find("P2_B1").SetActive(false); P2_B1_vida=-1;}
        if (getVida(2,2)==0) {darDinero(1,100); GameObject.Find("P2_B2").SetActive(false); P2_B2_vida=-1;}
        if (getVida(2,3)==0) {darDinero(1,100); GameObject.Find("P2_B3").SetActive(false); P2_B3_vida=-1;}
        if (getVida(2,4)==0) {darDinero(1,100); GameObject.Find("P2_B4").SetActive(false); P2_B4_vida=-1;}
        if (getVida(2,5)==0) {darDinero(1,100); GameObject.Find("P2_B5").SetActive(false); P2_B5_vida=-1;}
        if (getVida(2,6)==0) {darDinero(1,100); GameObject.Find("P2_B6").SetActive(false); P2_B6_vida=-1;}
        if (getVida(2,7)==0) {darDinero(1,100); GameObject.Find("P2_B7").SetActive(false); P2_B7_vida=-1;}
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
