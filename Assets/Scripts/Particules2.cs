using Unity.VisualScripting;
using UnityEngine;

public class Particules2 : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
    }

    private void OnTriggerEnter(Collider other)
{
    GameObject[] fakeWalls = GameObject.FindGameObjectsWithTag("FakeWall");
    
    if (other.CompareTag("Player"))
    {
        ps.Play();
    }
    
    foreach (GameObject wall in fakeWalls)
        {
            if (wall != null)
                wall.SetActive(false);
        }
    Destroy(this.gameObject, 2f);
}
}