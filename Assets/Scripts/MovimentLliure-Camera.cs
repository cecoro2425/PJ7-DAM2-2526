using System;
using UnityEngine;

public class MovimentLliureCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float velocitat=10;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10);
    [SerializeField] private float suavizado = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 objetivo = target.position + offset;

        // cámara lateral: Z fija
        objetivo.z = offset.z;

        // Seguimiento suave
        transform.position = Vector3.Lerp(
            transform.position,
            objetivo,
            suavizado * Time.deltaTime
        );
        
    }
}