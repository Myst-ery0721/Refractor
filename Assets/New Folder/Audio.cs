using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    //Aduio 
    public void PlayAudioCLip()
    {
        audioSource.Play();
    }
}
