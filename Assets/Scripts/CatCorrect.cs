using UnityEngine;

public class CatCorrect : MonoBehaviour
{
    private CatGenerator catGen;
    private AudioSource audioSource;
    private AudioClip[] correctSounds; // Array de sonidos
    public bool touched=false;

    void Start()
    {
        catGen = FindObjectOfType<CatGenerator>();
        audioSource = FindObjectOfType<AudioSource>();

        // Cargar los archivos de audio desde Resources
        correctSounds = new AudioClip[]
        {
            Resources.Load<AudioClip>("MiauCorrect"),
            Resources.Load<AudioClip>("MiauCorrect2")
        };
    }

    void OnMouseDown()
    {
        touched = true;
        if (audioSource != null && correctSounds.Length > 0)
        {
            // Elegir un sonido aleatorio
            AudioClip randomSound = correctSounds[Random.Range(0, correctSounds.Length)];
            audioSource.PlayOneShot(randomSound);
        }

        // Actualizar la puntuación
        catGen.UpdateScoreText();
    }
}

