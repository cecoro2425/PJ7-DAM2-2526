using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MovimentDobleSalto : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocitat = 8f;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto = 8f;
    [SerializeField] private float tiempoSaltoMax = 0.25f;

    [Header("Doble Salto")]
    [SerializeField] private float gravedadNormal = -20f;
    [SerializeField] private float gravedadPlaneo = -5f;
    [SerializeField] private float impulsoFinal = 10f;
    [SerializeField] private float duracionPlaneo = 0.6f;

    private int saltosRestantes = 2;
    private bool haciendoDobleSalto;

    [Header("Modelo (opcional)")]
    [SerializeField] private Transform modelo;

    private Rigidbody rb;

    private bool enSuelo;
    private bool saltando;
    private float tiempoSalto;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Configuración recomendada 2.5D
        rb.constraints = RigidbodyConstraints.FreezeRotation |
                         RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        Movimiento();
        Salto();
    }

    void Movimiento()
    {
        float input = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector3(input * velocitat, rb.linearVelocity.y, 0);

        // Girar modelo si existe
        if (modelo != null)
        {
            if (input > 0)
                modelo.rotation = Quaternion.Euler(0, 270, 0);
            else if (input < 0)
                modelo.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    void Salto()
    {
    if (Input.GetKeyDown(KeyCode.UpArrow) && saltosRestantes > 0)
        {
        if (saltosRestantes == 2)
            {
            // Primer salto normal
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerzaSalto, 0);
            }
        else
            {
            // Segundo salto estilo Yoshi
            StartCoroutine(DobleSaltoYoshi());
            }

        saltosRestantes--;
        enSuelo = false;
        }
    }

    IEnumerator DobleSaltoYoshi()
{
    haciendoDobleSalto = true;

    float tiempo = 0f;

    // Fase 1: caída lenta (parábola invertida)
    while (tiempo < duracionPlaneo)
    {
        rb.linearVelocity += Vector3.up * gravedadPlaneo * Time.deltaTime;
        tiempo += Time.deltaTime;
        yield return null;
    }

    // Fase 2: impulso final hacia arriba
    rb.linearVelocity = new Vector3(rb.linearVelocity.x, impulsoFinal, 0);

    haciendoDobleSalto = false;
}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            enSuelo = true;
            saltando = false;
            saltosRestantes = 2;
        }
        if (other.gameObject.CompareTag("Aigua")){
            Destroy(this.gameObject);
        }
    }
}