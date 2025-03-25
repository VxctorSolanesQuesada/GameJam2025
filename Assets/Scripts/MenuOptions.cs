using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public PointsControl score;

    public void StartGame()
    {
        score = FindObjectOfType<PointsControl>();
        if(score != null)
        {
            Destroy(score.gameObject);
        }
        SceneManager.LoadScene("SampleScene");

    }
    public void Menu()
    {
        SceneManager.LoadScene("Start scene");

    }
    public void EndGame()
    {

        Application.Quit();
    }

}
