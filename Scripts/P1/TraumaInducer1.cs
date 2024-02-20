 using UnityEngine;
using System.Collections;


public class TraumaInducer1 : MonoBehaviour 
{
    public float Delay = 1;
    public float MaximumStress = 0.6f;
    public float Range = 45;

    public GameObject explosion;
    public GameObject myself;
    private GameManager gm ;

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
    }
    private void PlayParticles()
    {
        var children = transform.GetComponentsInChildren<ParticleSystem>();
        for(var i  = 0; i < children.Length; ++i)
        {
            children[i].Play();
        }
        var current = GetComponent<ParticleSystem>();
        if(current != null) current.Play();
    }
    
    private void OnCollisionEnter (Collision other)
    {

        if(other.collider.tag == "missil")
        {
            explosion.SetActive(true);
            StartCoroutine(DelayedAction());
        }

    }

    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(Delay); // Espera 2 segundos
        explosion.SetActive(false);
        gm.refreshVida();
    }
}