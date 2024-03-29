using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasPool : MonoBehaviour
{
    static public BalasPool bPool { get; private set; }

    public GameObject balaPrefab;

    public int MaxBalas = 20;
    public List<GameObject> Balas;
    private int indice;

    private void Awake()
    {
        bPool = this;

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

