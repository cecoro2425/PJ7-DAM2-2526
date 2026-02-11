using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1.5f;
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.1f;

    private Rigidbody rb;
    private bool estaActivada = false;
    private Vector3 posInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        posInicial = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!estaActivada && collision.gameObject.CompareTag("Player"))
        {
            estaActivada = true;
            StartCoroutine(ShakeAndFall());
        }
    }

    IEnumerator ShakeAndFall()
    {
        // Espera antes de empezar a temblar
        yield return new WaitForSeconds(fallDelay);

        float tiempo = 0f;

        while (tiempo < shakeDuration)
        {
            float offsetX = Random.Range(-shakeAmount, shakeAmount);
            float offsetZ = Random.Range(-shakeAmount, shakeAmount);

            transform.position = posInicial + new Vector3(offsetX, 0, offsetZ);

            tiempo += Time.deltaTime;
            yield return null;
        }

        // Restaurar posición exacta antes de caer
        transform.position = posInicial;

        // Activar caída
        rb.isKinematic = false;
    }
}