using UnityEngine;
using UnityEngine.UI;

public class MusicPause : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] AudioSource audio;
    [SerializeField] Sprite texture1;
    [SerializeField] Sprite texture2;

    public void CambiarMusica()
    {
        if (audio.isPlaying) StopMusic();
        else  PlayMusic();
    }
    public void StopMusic()
    {
        audio.Pause();
        playButton.image.sprite = texture2;
    }
    
    public void PlayMusic()
    {
        audio.Play();
        playButton.image.sprite = texture1;
    }
}
