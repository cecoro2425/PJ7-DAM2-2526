using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimentLliure2 : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocitat = 8f;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto = 8f;
    [SerializeField] private float tiempoSaltoMax = 0.25f;

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
        // Inicio salto
        if (Input.GetKeyDown(KeyCode.UpArrow) && enSuelo)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerzaSalto, 0);
            saltando = true;
            tiempoSalto = tiempoSaltoMax;
            enSuelo = false;
        }

        // Mantener salto
        if (Input.GetKey(KeyCode.UpArrow) && saltando)
        {
            if (tiempoSalto > 0)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerzaSalto, 0);
                tiempoSalto -= Time.deltaTime;
            }
            else
            {
                saltando = false;
            }
        }

        // Soltar botón corta salto
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            saltando = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            enSuelo = true;
            saltando = false;
        }
        if (other.gameObject.CompareTag("Aigua")){
            Destroy(this.gameObject);
        }
    }
}