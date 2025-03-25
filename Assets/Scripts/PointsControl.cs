using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PointsControl : MonoBehaviour
{
    public static PointsControl Instance;
    public int puntos;
    private void Awake()
    {
        if(PointsControl.Instance == null)
        {
            PointsControl.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
