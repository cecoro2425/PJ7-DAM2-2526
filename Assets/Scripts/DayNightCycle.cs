using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Duracio dia")]
    [SerializeField] private float duracioDia = 60f;
    [SerializeField] private Gradient colorLlum;

    private float rotacioPerSegon;

    void Start()
    {
        rotacioPerSegon = 360f / duracioDia;
    }

    void Update()
    {
        transform.Rotate(Vector3.right * rotacioPerSegon * Time.deltaTime);

        float dot = Vector3.Dot(transform.forward, Vector3.down);

        float t = (transform.eulerAngles.x / 360f);
        GetComponent<Light>().color = colorLlum.Evaluate(t);

        if (dot > 0)
            GetComponent<Light>().intensity = 1;
        else
            GetComponent<Light>().intensity = 0;
    }
}
