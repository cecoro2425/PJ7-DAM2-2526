using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarJuego : MonoBehaviour
{
    
    public void Restart()
    {
        
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene("");
        
    }
    public void Salir()
    {
        Application.Quit();
        
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
