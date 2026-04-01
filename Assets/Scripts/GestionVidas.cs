using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionVidas : MonoBehaviour
{

    
    [SerializeField] int vides;
    [SerializeField] TextMeshProUGUI textVides;
    [SerializeField] private Texture2D texture1;
    [SerializeField] private Texture2D texture2;
    [SerializeField] private Texture2D texture3;
    [SerializeField] private Texture2D texture4;
    [SerializeField] RawImage imageVides;
    [SerializeField] private Transform player;

    public void augmentarVides()
    {
        vides++;
        print(vides);
        //textVides.text = $"Vidas: {vides}";        
    }
    public void disminuirVides()
    {
        vides--; 
        print(vides);
        //textVides.text = $"Vidas: {vides}";
        switch (vides)
        {
            case 3:
                imageVides.texture = texture1;
                break;
            case 2:
                imageVides.texture = texture2;
                break;
            case 1:
                imageVides.texture = texture3;
                break;
            case 0:
                imageVides.texture = texture4;
                break;
        }
        //imageVides.texture  = texture1;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Penguin")
        {
            if (vides == 1)
            {
                disminuirVides();
                SceneManager.LoadScene(1);
            }
            else disminuirVides();
            
        }
        
    }
    
}