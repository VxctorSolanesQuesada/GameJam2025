using UnityEngine;

public class CatWrong : MonoBehaviour {

    private CatGenerator catGen;

    void OnMouseDown()
    {

        GameObject[] existingCats = GameObject.FindGameObjectsWithTag("Cat");
        if (existingCats.Length != 0)
        {
            foreach (GameObject cat in existingCats)
            {
                Destroy(cat);
            }
        }

        catGen = FindObjectOfType<CatGenerator>();
        catGen.end = true;
        Debug.Log("Has hecho clic en el gato incorrecto: " + gameObject.name);
        GameManager.Instance.GameOver();
    }
}
