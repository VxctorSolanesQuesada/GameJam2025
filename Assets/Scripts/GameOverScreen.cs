using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    public TextMeshProUGUI scoreText;
    public CatGenerator CatGenerator;
    private AudioSource audioSource;
    private AudioClip wrongSound;




    private void Start()
    {
        scoreText.text = null;
        GameOver.SetActive(false);
        audioSource = FindObjectOfType<AudioSource>();
        wrongSound = Resources.Load<AudioClip>("LoseChill");
    }
    public void GameOverMenu()
    {
        GameOver.SetActive(true);
        audioSource.Stop();
        audioSource.clip = wrongSound;
        audioSource.Play();
        scoreText.text = "Your Score: " + CatGenerator.score;
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void returnMenu()
    {
        SceneManager.LoadScene("Start scene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
