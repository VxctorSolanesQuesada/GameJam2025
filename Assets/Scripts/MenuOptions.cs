using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void EndGame()
    {

        Application.Quit();
    }
}
