using UnityEngine;

public class PickupVida : MonoBehaviour
{
    [SerializeField] private int cantidadVida = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GestionVidas2 vidas = other.GetComponent<GestionVidas2>();

            if (vidas != null)
            {
                vidas.SumarVida(cantidadVida);
            }

            Destroy(gameObject);
        }
    }
}