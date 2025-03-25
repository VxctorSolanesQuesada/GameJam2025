using UnityEngine;
using UnityEngine.UI;

public class CatCorrect : MonoBehaviour
{
    private CatGenerator catGen;
    private AudioSource audioSource; 
    private AudioClip correctSound;

    void Start()
    {
        catGen = FindObjectOfType<CatGenerator>();
        audioSource = GetComponent<AudioSource>(); 

        // Cargar el archivo de audio desde la carpeta Resources
        correctSound = Resources.Load<AudioClip>("MiauCorrec");
    }

    void OnMouseDown()
    {
        if (audioSource != null && correctSound != null)
        {
            audioSource.clip = correctSound;
            audioSource.Play();

            // Detener el sonido despu�s de 1 segundo
            Invoke("StopSound", 1f); 
        }

        // Actualizar la puntuaci�n
        catGen.UpdateScoreText();
    }

    // M�todo para detener el sonido
    void StopSound()
    {
        audioSource.Stop(); 
    }
}
