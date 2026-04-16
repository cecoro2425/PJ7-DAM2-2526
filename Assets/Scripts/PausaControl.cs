using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaControl : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool pausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }
    
    public void Pause()
    {
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        pausado = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("PruebaCC");
        
    }
    
    public void Salir()
    {
        Application.Quit();
    }
}
