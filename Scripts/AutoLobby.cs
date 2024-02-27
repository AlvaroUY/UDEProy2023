using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoLobby : MonoBehaviourPunCallbacks
{
    public Button BTN_Nueva, BTN_Cargar, BTN_Partida1, BTN_Partida2, BTN_Partida3, BTN_Partida4, BTN_Partida5;
    public TMP_Text Log, PlayerCount;
    public int playersCount;

    public byte maxPlayersPerRoom = 2;
    public byte minPlayersPerRoom = 2;
    private bool IsLoading = false;

    private int partida;

    private GameManager gm ;
    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
    }

    public void Connect(int p)
    {
        partida = p;
        if (!PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.ConnectUsingSettings())
            {
                Log.text += "\nConectado al servidor";
            }
            else
            {
                Log.text += "\nError al conectar al servidor";
            }
        }
    }
    public void JoinRandom()
    {
        if (!PhotonNetwork.JoinRandomRoom())
        {
            Log.text += "\nError al unirse a la sala";
        }
    }

    public override void OnConnectedToMaster()
    {
        BTN_Nueva.interactable = BTN_Cargar.interactable = false;
        BTN_Partida1.interactable = BTN_Partida2.interactable = BTN_Partida3.interactable = BTN_Partida4.interactable = BTN_Partida5.interactable = false;
        JoinRandom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Log.text += "\nNo existe sala a unirse, creando...";

        if (PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions() { MaxPlayers = maxPlayersPerRoom }))
        {
            Log.text += "\nSala creada";
        }
        else
        {
            Log.text += "\nError al crear sala";
        }
    }

    public override void OnJoinedRoom()
    {
        Log.text += "\nUnido";
    }


    private void FixedUpdate()
    {
        if (PhotonNetwork.CurrentRoom != null)
            playersCount = PhotonNetwork.CurrentRoom.PlayerCount;

        PlayerCount.text = "Jugadores: " + playersCount + "/" + maxPlayersPerRoom;

        if (!IsLoading && playersCount >= minPlayersPerRoom)
        {
            LoadMap();
        }
    }


    private void LoadMap()
    {
        IsLoading = true;
        //PhotonNetwork.LoadLevel("Juego");
        gm.iniciarPartida(partida);
    }

}