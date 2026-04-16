using UnityEngine;

public class Instancies : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    void Start()
    {
        for (float y = 1; y < 5; y+=1.05f) {
            for (float x = -1; x < 4; x+=1.05f) {
               Instantiate(prefab, new  Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }
    }