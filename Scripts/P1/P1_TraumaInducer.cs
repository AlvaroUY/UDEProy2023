 using UnityEngine;
using System.Collections;


public class P1_TraumaInducer : MonoBehaviour 
{
    public float Delay = 1;
    public float MaximumStress = 0.6f;
    public float Range = 45;

    public GameObject explosion;
    public GameObject myself;
    private GameManager gm ;

    public CameraShake camara;


    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
        GameObject cs = GameObject.Find("CamaraLateral");
        camara = cs.GetComponent<CameraShake>(); 
    }
    
    private void OnCollisionEnter (Collision other)
    {

        if(other.collider.tag == "missil")
        {
            explosion.SetActive(true);
            StartCoroutine(camara.Shake());
            StartCoroutine(DelayedAction());
        }

    }

    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(Delay);
        explosion.SetActive(false);
        gm.refreshVida();
    }
}