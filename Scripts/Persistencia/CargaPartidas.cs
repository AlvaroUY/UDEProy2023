using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System;

public class CargaPartidas : MonoBehaviour
{
    private int Partida_1_id, Partida_2_id, Partida_3_id, Partida_4_id, Partida_5_id;
    public Button BTN_Partida_1, BTN_Partida_2, BTN_Partida_3, BTN_Partida_4, BTN_Partida_5;
    public TMP_Text BTN_TXT_Partida_1, BTN_TXT_Partida_2, BTN_TXT_Partida_3, BTN_TXT_Partida_4, BTN_TXT_Partida_5;

    private ControladorDatos controladorDatos = new ControladorDatos();

    void Awake() {
        controladorDatos = FindAnyObjectByType<ControladorDatos>();
        /*
        controladorDatos.LoadExterno(Partida_1_id);
        DatosPartidas datosPartidas = controladorDatos.ListExterno();
        Partida_1_id = datosPartidas.Partida_1.id;
        Partida_2_id = datosPartidas.Partida_2.id;
        Partida_3_id = datosPartidas.Partida_3.id;
        Partida_4_id = datosPartidas.Partida_4.id;
        Partida_5_id = datosPartidas.Partida_5.id;
        if (datosPartidas.Partida_1.id != -1) setTextoPartidas(1,Partida_1_id+": "+datosPartidas.Partida_1.fecha); else setTextoPartidas(1,"");
        if (datosPartidas.Partida_2.id != -1) setTextoPartidas(2,Partida_2_id+": "+datosPartidas.Partida_2.fecha); else setTextoPartidas(2,"");
        if (datosPartidas.Partida_3.id != -1) setTextoPartidas(3,Partida_3_id+": "+datosPartidas.Partida_3.fecha); else setTextoPartidas(3,"");
        if (datosPartidas.Partida_3.id != -1) setTextoPartidas(4,Partida_4_id+": "+datosPartidas.Partida_4.fecha); else setTextoPartidas(4,"");
        if (datosPartidas.Partida_5.id != -1) setTextoPartidas(5,Partida_5_id+": "+datosPartidas.Partida_5.fecha); else setTextoPartidas(5,"");
        */
    }

    public void setTextoPartidas(int i, String txt) {
        switch (i) {
            case 1: BTN_TXT_Partida_1.text = txt; break;
            case 2: BTN_TXT_Partida_2.text = txt; break;
            case 3: BTN_TXT_Partida_3.text = txt; break;
            case 4: BTN_TXT_Partida_4.text = txt; break;
            case 5: BTN_TXT_Partida_5.text = txt; break;
        }
    }

    void Start () {
		BTN_Partida_1.onClick.AddListener(Load_Partida1);
		BTN_Partida_2.onClick.AddListener(Load_Partida2);
		BTN_Partida_3.onClick.AddListener(Load_Partida3);
		BTN_Partida_4.onClick.AddListener(Load_Partida4);
		BTN_Partida_5.onClick.AddListener(Load_Partida5);
	}

    private void Load_Partida1() {
        if (Partida_1_id != -1)
            controladorDatos.LoadExterno(Partida_1_id);
    }

    private void Load_Partida2() {
        if (Partida_2_id != -1)
            controladorDatos.LoadExterno(Partida_2_id);
    }

    private void Load_Partida3() {
        if (Partida_3_id != -1)
            controladorDatos.LoadExterno(Partida_3_id);
    }

    private void Load_Partida4() {
        if (Partida_4_id != -1)
            controladorDatos.LoadExterno(Partida_4_id);
    }

    private void Load_Partida5() {
        if (Partida_5_id != -1)
            controladorDatos.LoadExterno(Partida_5_id);
    }
}
