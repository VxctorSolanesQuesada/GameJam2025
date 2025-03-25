using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ges : MonoBehaviour
{
    private float angle=35;
    private float z;
    private bool Izquierda = true;
    // Start is called before the first frame update
    void Update()
    {
        Dancing();
    }
    private void Dancing()
    {
        if (Izquierda) 
        {
            z += Time.deltaTime * angle;
            transform.localRotation = Quaternion.Euler(0, 0, z);
            if (z > 30.0f)
            {
                Izquierda = false;
            }
        }
        else
        {
            z -= Time.deltaTime * angle;
            transform.localRotation = Quaternion.Euler(0, 0, z);
            if (z < -30.0f)
            {
                Izquierda = true;
            }
        }
    }
}
