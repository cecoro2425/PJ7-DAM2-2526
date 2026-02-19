using System.Collections; 
using System.Collections.Generic;
using UnityEngine; 
/** 
* Classe que assigna un moviment repetitiu a un objecte 
* sergi.grau@fje.edu * 1.0 27.03.2015 */ 

public class MovimentRepeticio : MonoBehaviour 
{ 
    [SerializeField] Vector3 puntB;
    [SerializeField] float tempsAnada;  
    [SerializeField] float tempsTornada; 
    IEnumerator Start() { 
        var puntA = transform.position; 
        while (true) { 
            /* yield espera l'execució'una rutina abans de l'execució de la següent 
            * lerp, interpola entre 2 vectors*/ 
            yield return StartCoroutine(MoureObjecte(transform, puntA, puntB, tempsAnada)); 
            yield return StartCoroutine(MoureObjecte(transform, puntB, puntA, tempsTornada)); 
            } 
        } 
        IEnumerator MoureObjecte(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps) 
        { 
            var i= 0.0f; 
            var rati= 1.0f/temps; 
            while (i < 1.0f) { 
                i += Time.deltaTime * rati; 
                transformObjecte.position = Vector3.Lerp(posInicial, posFinal, i); 
                yield return null; 
                } 
                
        } 
}