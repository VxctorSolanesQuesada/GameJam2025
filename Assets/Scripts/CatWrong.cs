using UnityEngine;
using System.Collections;

public class CatWrong : MonoBehaviour
{
    private CatGenerator catGen;
    public CatCorrect verify;

    private void Start()
    {
        // Verificar si el componente CatCorrect está en el mismo GameObject
        verify = GetComponent<CatCorrect>();

        // Si no lo encontramos, buscarlo en el GameObject del prefab asociado
        if (verify == null)
        {
            // Suponiendo que el prefab de gato está en el mismo GameObject, buscarlo de esta manera
            verify = FindObjectOfType<CatCorrect>();

            // Si tampoco lo encontramos, mostrar un mensaje de error
            if (verify == null)
            {
                Debug.LogError("CatCorrect no encontrado en el objeto.");
            }
        }
    }

    void OnMouseDown()
    {
        StartCoroutine(HandleWrongCatClick());
    }

    private IEnumerator HandleWrongCatClick()
    {
        // Esperar 0.2 segundos antes de proceder
        yield return new WaitForSeconds(0.05f);

        // Verificar si el componente `CatCorrect` no es null y si no ha sido tocado
        if (verify != null && !verify.touched)
        {
            // Buscar todos los gatos existentes
            GameObject[] existingCats = GameObject.FindGameObjectsWithTag("Cat");

            if (existingCats.Length != 0)
            {
                foreach (GameObject cat in existingCats)
                {
                    // Destruir cada gato con un pequeño retraso
                    Destroy(cat);
                }
            }

            // Encontrar el generador de gatos
            catGen = FindObjectOfType<CatGenerator>();
            catGen.end = true;

            // Mostrar el mensaje de debug
            Debug.Log("Has hecho clic en el gato incorrecto: " + gameObject.name);

            // Llamar al método GameOver en el GameManager
            GameManager.Instance.GameOver();


            // Restablecer el valor de touched
            verify.touched = false;
        }
        else
        {
            // Mostrar un mensaje de error si `verify` es null
            Debug.LogError("El componente CatCorrect no está asignado correctamente.");
        }
    }
}
