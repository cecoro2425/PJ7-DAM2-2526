using System;
using UnityEngine;

public class MovimentLliure : MonoBehaviour
{
    
    private bool saltando;
    private float tiempoSalto;
    private bool enSuelo;
    
    [SerializeField]private float velocidadY = 10;
    
    [SerializeField] private float velocitat=10;
    [SerializeField] private float fuerzaSalto=8;
    [SerializeField] private float tiempoSaltoMax= 5;
       
    [SerializeField] private Transform suelo ;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //moviment sobre dos eixos
        //transform.Translate (Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * velocitat);
        transform.Translate (Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * velocitat,Space.World);

        if (Input.GetKeyDown(KeyCode.UpArrow) && enSuelo)
        {
            velocidadY = fuerzaSalto;
            tiempoSalto = tiempoSaltoMax;
            saltando = true;
            enSuelo = false;
        }

        if (Input.GetKey(KeyCode.UpArrow) && saltando)
        {
            if (tiempoSalto > 0)
            {
                velocidadY = fuerzaSalto;
                tiempoSalto -= Time.deltaTime;
            }
            else
            {
                saltando = false;
            }
        }

        if (velocidadY > 0)
        {
            velocidadY -= Time.deltaTime;
        }
        
        transform.Translate (Vector3.up * velocidadY * Time.deltaTime);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            enSuelo = true;
            saltando = false;
            velocidadY = 0;
        }
        
    }
    
}
