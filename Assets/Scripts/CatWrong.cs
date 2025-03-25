using UnityEngine;

public class CatWrong : MonoBehaviour {

    private CatGenerator catGen;

    void OnMouseDown()
    {
        catGen = FindObjectOfType<CatGenerator>();
        catGen.end = true;
        Debug.Log("Has hecho clic en el gato incorrecto: " + gameObject.name);
        GameManager.Instance.GameOver();
    }
}
