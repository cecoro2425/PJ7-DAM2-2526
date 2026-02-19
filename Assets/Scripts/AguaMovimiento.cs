using UnityEngine;

public class AguaMovimiento : MonoBehaviour
{
    
    [Header("Wave Settings")]
    public float amplitude = 0.5f;     // altura de ola
    public float frequency = 1.0f;     // cantidad de olas
    public float speed = 1.0f;         // velocidad del movimiento
    public float waveScale = 1.0f;     // escala espacial

    [Header("Tide")]
    public float tideAmplitude = 0.2f;
    public float tideSpeed = 0.2f;
    
    private Mesh mesh;
    private Vector3[] baseVertices;
    private Vector3[] vertices;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        baseVertices = mesh.vertices;
        vertices = new Vector3[baseVertices.Length];
    }

    void Update()
    {
        float time = Time.time * speed;
        
        float tide = Mathf.Sin(Time.time * tideSpeed) * tideAmplitude;
        
        

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 v = baseVertices[i];

            float wave =
                Mathf.Sin((v.x * waveScale) + time * frequency) +
                Mathf.Cos((v.z * waveScale) + time * frequency);

            v.y = wave * amplitude;
            v.y = wave * amplitude + tide;
            
            vertices[i] = v;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
