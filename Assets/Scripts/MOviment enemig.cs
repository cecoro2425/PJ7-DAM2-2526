using UnityEngine;

public class MOvimentenemig : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public Transform[] puntsMoviment;
    int indexPuntMoviment;
    Vector3 destinacio;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ActualitzarDestinacio();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destinacio) < 1f)
        {
            IterarIndex();
            ActualitzarDestinacio();
        }

    }
    void ActualitzarDestinacio()
    {
        destinacio = puntsMoviment[indexPuntMoviment].position;
        agent.SetDestination(destinacio);

    }
    void IterarIndex()
    {
        indexPuntMoviment++;
        if (indexPuntMoviment == puntsMoviment.Length)
        {
            indexPuntMoviment = 0;
        }
    }


}
