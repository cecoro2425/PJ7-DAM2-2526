using UnityEngine;
using UnityEngine.SceneManagement;

public class ProbaRestart : MonoBehaviour
{
    public void Restart()
    {
        print("Procesando petición");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(0);
        print("Reiniciando el juego");
    }
}
