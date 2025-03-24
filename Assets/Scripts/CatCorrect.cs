using UnityEngine;
using UnityEngine.UI;

public class CatCorrect : MonoBehaviour
{
    private CatGenerator catGen;
    void Start()
    {
        catGen = FindObjectOfType<CatGenerator>();

        if (catGen == null)
        {
            Debug.LogError("¡No se ha encontrado el script CatGenerator en la escena!");
        }
    }
    void OnMouseDown()
    {
        catGen.UpdateScoreText();
    }

    
}
