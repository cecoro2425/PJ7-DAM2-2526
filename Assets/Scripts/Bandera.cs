using UnityEngine;

public class Bandera : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    [SerializeField] private GameObject pole;

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
        }
    }
}