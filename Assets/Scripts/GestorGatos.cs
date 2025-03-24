using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorGatos : MonoBehaviour
{
    public CatGenerator referencia;

    
    public void clickedFunction()
    {
        Color color2 = gameObject.GetComponent<Renderer>().material.color;

        if (referencia.color1 == color2)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Incorrect");
        }
    }
}
