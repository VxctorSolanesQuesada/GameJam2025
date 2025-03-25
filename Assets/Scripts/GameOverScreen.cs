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


    private void Start()
    {
        scoreText.text = null;
        GameOver.SetActive(false);
    }
    public void GameOverMenu()
    {
        GameOver.SetActive(true);
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
