using System.Collections;
using UnityEngine;

public class ObjectToWater : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform check;
    
    
    [SerializeField] private float duracionFlotar = 2f;
    [SerializeField] private float alturaFlotacion = 1.1f;
    [SerializeField] private float velocidadFlotacion = 2f;

    private Vector3 posicionInicial;
    private bool flotando = false;
    
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Penguin" && !flotando)
        {
            StartCoroutine(SecuenciaFlotar());
            
        }
    }

    IEnumerator SecuenciaFlotar()
    {
        flotando = true;

        posicionInicial = player.position;
        Vector3 posicionFinal = posicionInicial - Vector3.up * alturaFlotacion;
        
        /*
        // Esperar flotando
        yield return new WaitForSeconds(duracionFlotar);
        */
        
        // Subir
        yield return StartCoroutine(
            FlotarTemporal(player, posicionInicial, posicionFinal, velocidadFlotacion)
        );
        
        // Bajar
        yield return StartCoroutine(
            FlotarTemporal(player, posicionFinal, posicionInicial, velocidadFlotacion)
        );
        
        player.position = check.position;
        flotando = false;
    }

    IEnumerator FlotarTemporal(Transform player, Vector3 posInicial, Vector3 posFinal, float temps) 
    { 
        var i= 0.0f; 
        var rati= 1.0f/temps; 
        while (i < 1.0f) { 
            i += Time.deltaTime * rati; 
            player.position = Vector3.Lerp(posInicial, posFinal, i); 
            yield return null; 
        } 
    }
}