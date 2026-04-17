using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandera : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    [SerializeField] private GameObject pole;
    [SerializeField] private GameObject panelFinal;
    

    void Start()
    {
        flag.SetActive(false);
        pole.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo ha entrado");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Es el jugador");
            flag.SetActive(true);
            pole.SetActive(true);
            
            StartCoroutine(SecuenciaFlotar(other.transform));
        }
    }
    
    IEnumerator SecuenciaFlotar(Transform player)
    {
        float tiempo = 2f; // duración de la animación
        float velocidadRotacion = 360f; // grados por segundo

        float t = 0;

        while (t < tiempo)
        {
            // Rotar el player sobre el eje Y
            player.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);

            t += Time.deltaTime;
            yield return null;
        }
        panelFinal.SetActive(true);
        Time.timeScale = 0f;
    }
}