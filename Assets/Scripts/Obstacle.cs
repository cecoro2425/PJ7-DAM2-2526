using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform checkPoint;
    [SerializeField] private GestionVidas2 gestionVidas2;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Penguin")
        {
            Debug.Log("Player: " + player);
            Debug.Log("CheckPoint: " + checkPoint);
            Debug.Log("GestionVidas2: " + gestionVidas2);

            gestionVidas2.PerdreVida(1);
            player.position = checkPoint.position;
        }
    }
}