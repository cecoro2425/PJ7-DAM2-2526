using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform checkPoint;



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Penguin")
        {
            Debug.Log("CheckPoint: " + checkPoint);

            player.position = checkPoint.position;
        }
    }
}