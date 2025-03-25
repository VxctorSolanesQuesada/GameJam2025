using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuOptions : MonoBehaviour
{ 
    private bool isMuted = false;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public Image muteButtonImage;

    public void StartGame()
    {
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

    public void Credits()
    {
        SceneManager.LoadScene("Credits Scene");
    }

    void Start()
    {
        // Cargar el estado del sonido al iniciar el juego
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        AudioListener.volume = isMuted ? 0f : 1f;
        UpdateButtonSprite();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted; // Cambiar el estado
        AudioListener.volume = isMuted ? 0f : 1f;

        // Guardar la configuración
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        UpdateButtonSprite();
    }

    private void UpdateButtonSprite()
    {
        // Cambiar la imagen del botón según el estado del sonido
        muteButtonImage.sprite = isMuted ? soundOffSprite : soundOnSprite;
    }



}
