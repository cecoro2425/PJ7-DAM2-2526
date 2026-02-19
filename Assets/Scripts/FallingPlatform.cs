using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [Header("Timing")]
    public float fallDelay = 1.0f;
    public float shakeDuration = 0.6f;
    public float respawnDelay = 2.5f;
    public float respawnRiseHeight = 2f;
    public float respawnSpeed = 2f;

    [Header("Shake")]
    public float shakeAmount = 0.05f;

    [Header("Audio")]
    [SerializeField] private AudioClip fallClip;

    private Rigidbody rb;
    private AudioSource audioSource;
    private Collider col;
    private Renderer rend;

    private bool estaActivada = false;
    private Vector3 posInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        audioSource = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();

        posInicial = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!estaActivada && collision.gameObject.CompareTag("Player"))
        {
            estaActivada = true;
            StartCoroutine(PlatformRoutine());
        }
    }

    IEnumerator PlatformRoutine()
    {
        yield return new WaitForSeconds(fallDelay);

        // ----- SACUDIDA PROGRESIVA -----
        float tiempo = 0f;

        while (tiempo < shakeDuration)
        {
            float intensidad = Mathf.Lerp(0, shakeAmount, tiempo / shakeDuration);

            float offsetX = Random.Range(-intensidad, intensidad);
            transform.position = posInicial + new Vector3(offsetX, 0, 0);

            tiempo += Time.deltaTime;
            yield return null;
        }

        transform.position = posInicial;

        // ----- SONIDO + CAÍDA -----
        if (audioSource != null && fallClip != null)
        {
            audioSource.PlayOneShot(fallClip);
        }

        rb.isKinematic = false;

        // Esperar mientras cae
        yield return new WaitForSeconds(respawnDelay);

        // ----- DESAPARECER -----
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        col.enabled = false;
        rend.enabled = false;

        // Teletransportar arriba (fuera de vista)
        transform.position = posInicial + Vector3.up * respawnRiseHeight;

        yield return new WaitForSeconds(0.5f);

        // ----- REAPARICIÓN SUAVE -----
        rend.enabled = true;

        while (Vector3.Distance(transform.position, posInicial) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posInicial,
                respawnSpeed * Time.deltaTime
            );

            yield return null;
        }

        transform.position = posInicial;
        col.enabled = true;

        estaActivada = false;
    }
}