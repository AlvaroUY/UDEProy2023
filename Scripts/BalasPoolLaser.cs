using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasPoolLaser : MonoBehaviour
{
    static public BalasPoolLaser lPool { get; private set; }

    public GameObject balaPrefab;

    public int MaxBalas = 10;
    public List<GameObject> Balas;
    private int indice;

    private void Awake()
    {
        lPool = this;

        indice = 0;
        for (int i = 0; i < MaxBalas; i++)
        {
            GameObject bala = Instantiate(balaPrefab);
            Balas.Add(bala);
            bala.SetActive(false);
        }
    }


    public GameObject GetBala()
    {
        GameObject bala = Balas[indice];
        indice++;
        if (indice >= Balas.Count)
            indice = 0;
        return bala;
    }






}

