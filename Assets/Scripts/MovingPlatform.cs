using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movimiento")]
    public float alturaObjetivo = 5f;
    public float velocidad = 2f;

    [Header("Dirección")]
    public bool empezarBajando = false;     // ✅ Checkbox en el Inspector

    [Header("Espera")]
    public float tiempoEsperaArriba = 2f;
    public float tiempoEsperaAbajo = 1f;

    private Vector3 posicionInicial;
    private Vector3 posicionArriba;

    void Start()
    {
        posicionInicial = transform.position;
        posicionArriba = posicionInicial + Vector3.up * alturaObjetivo;
        StartCoroutine(CicloPlatforma());
    }

    IEnumerator CicloPlatforma()
    {
        // Si empezarBajando está marcado, se intercambian los roles
        Vector3 puntoA = empezarBajando ? posicionArriba : posicionInicial;
        Vector3 puntoB = empezarBajando ? posicionInicial : posicionArriba;

        // Colocamos la plataforma en el punto de partida correcto
        transform.position = puntoA;

        while (true)
        {
            // Primer movimiento (sube O baja según el checkbox)
            yield return Mover(puntoA, puntoB);
            yield return new WaitForSeconds(empezarBajando ? tiempoEsperaAbajo : tiempoEsperaArriba);

            // Segundo movimiento (el contrario)
            yield return Mover(puntoB, puntoA);
            yield return new WaitForSeconds(empezarBajando ? tiempoEsperaArriba : tiempoEsperaAbajo);
        }
    }

    IEnumerator Mover(Vector3 desde, Vector3 hasta)
    {
        while (Vector3.Distance(transform.position, hasta) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                hasta,
                velocidad * Time.deltaTime
            );
            yield return null;
        }
        transform.position = hasta;
    }
}