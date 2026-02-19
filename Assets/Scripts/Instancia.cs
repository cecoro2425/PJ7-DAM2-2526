using UnityEngine;

public class Instancies : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    void Start()
    {
        for (float y = 1; y < 10; y+=1.1f) {
            for (float x = -3; x < 3; x+=1.1f) {
               Instantiate(prefab, new  Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }
    }