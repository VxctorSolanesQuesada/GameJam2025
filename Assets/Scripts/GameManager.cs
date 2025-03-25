using UnityEngine;
using UnityEngine.SceneManagement;  

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  

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

        // Recargar la escena después de 1 segundo
        SceneManager.LoadScene("Game Over");
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
