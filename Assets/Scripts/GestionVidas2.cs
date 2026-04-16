using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GestionVidas2 : MonoBehaviour
{

    [SerializeField] int vides;
    [SerializeField] TextMeshProUGUI textVides;
    [SerializeField] private Texture2D texture1;
    [SerializeField] private Texture2D texture2;
    [SerializeField] private Texture2D texture3;
    [SerializeField] private Texture2D texture4;
    [SerializeField] RawImage imageVides;
    [SerializeField] private Transform player;
    private bool invulnerable = false;
    [SerializeField] private float tempsInvulnerable = 1f;

    IEnumerator Invulnerabilitat()
{
    invulnerable = true;
    yield return new WaitForSeconds(tempsInvulnerable);
    invulnerable = false;
}

    public void PerdreVida(int quantitat)
{
    vides -= quantitat;

    if (vides <= 0)
    {
        vides = 0;
        SceneManager.LoadScene(1);
    }

    ActualitzarUI();
}

public void SumarVida(int quantitat)
{
    vides += quantitat;

    if (vides > 3)
        vides = 3;

    ActualitzarUI();
}
    void ActualitzarUI()
{
    switch (vides)
    {
        //textVides.text = $"Vidas: {vides}";
        case 3: imageVides.texture = texture1; break;
        case 2: imageVides.texture = texture2; break;
        case 1: imageVides.texture = texture3; break;
        case 0: imageVides.texture = texture4; break;
        //imageVides.texture  = texture1;
    }
}
    
    private void OnCollisionEnter(Collision other)
{
    if (other.gameObject.CompareTag("Obstacle") && !invulnerable)
    {
        PerdreVida(1);
        StartCoroutine(Invulnerabilitat());
    }
}
    
}