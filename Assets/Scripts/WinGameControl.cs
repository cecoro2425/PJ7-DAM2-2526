using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    
    public GameObject winMenu;
    
    
    public void Ganar()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void TornarMenu()
    {
        SceneManager.LoadScene(0);
    }
}
