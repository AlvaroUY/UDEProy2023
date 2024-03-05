using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour 
{
    public float duracion = 1.0f;
    public float magnitud = 0.15f;

    public IEnumerator Shake()
    {
        Vector3 posicionOriginal = transform.localPosition;
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracion)
        {
            float x = Random.Range(-1f,1f) * magnitud;

            transform.localPosition = new Vector3(x,posicionOriginal.y,posicionOriginal.z);
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = posicionOriginal;
    }
}