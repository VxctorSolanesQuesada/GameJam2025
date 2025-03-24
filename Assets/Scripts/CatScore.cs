using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CatScore : MonoBehaviour
{
    public int score = 0;
    public bool catCorrect = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gestorGatos()
    {
        if (catCorrect)
        {
            score++;
        } else
        {
            //acabar juego
        }
    }


}
