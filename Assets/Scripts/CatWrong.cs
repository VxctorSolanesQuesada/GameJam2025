using UnityEngine;
using System.Collections;

public class CatWrong : MonoBehaviour
{
    private CatGenerator catGen;
    public CatCorrect verify;

    private void Start()
    {
        verify = GetComponent<CatCorrect>();

        if (verify == null)
        {
            verify = FindObjectOfType<CatCorrect>();

        }
    }

    void OnMouseDown()
    {
        StartCoroutine(HandleWrongCatClick());
    }

    private IEnumerator HandleWrongCatClick()
    {
        yield return new WaitForSeconds(0.05f);

        if (verify != null && !verify.touched)
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


            GameManager.Instance.GameOver();


            verify.touched = false;
        }
        else
        {
            Debug.LogError("El componente CatCorrect no está asignado correctamente.");
        }
    }
}
