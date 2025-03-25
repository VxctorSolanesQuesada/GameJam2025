using UnityEngine;
using UnityEngine.UI;

public class CatWrong : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Has hecho clic en el gato incorrecto: " + gameObject.name);
        GameManager.Instance.GameOver();
    }
}
