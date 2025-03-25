using UnityEngine;
using UnityEngine.SceneManagement;  

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  
    public GameOverScreen GameOverScreen;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Debug.Log("¡Juego terminado! Has fallado.");
        GameOverScreen.GameOverMenu();

    }

}
