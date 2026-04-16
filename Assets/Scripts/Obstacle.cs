using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform checkPoint;
    [SerializeField] private GestionVidas gestionVidas;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Penguin")
        {
            Debug.Log("Player: " + player);
            Debug.Log("CheckPoint: " + checkPoint);
            Debug.Log("GestionVidas: " + gestionVidas);

            gestionVidas.PerdreVida(1);
            player.position = checkPoint.position;
        }
    }
}