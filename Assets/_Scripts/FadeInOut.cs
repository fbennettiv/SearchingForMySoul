using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasgroup;

    private bool fadein = false;
    private bool fadeout = false;


    void Update()
    {
        if (fadein)
        {
            if(canvasgroup.alpha < 1)
            {
                canvasgroup.alpha += Time.deltaTime;
                if(canvasgroup.alpha >= 1)
                {
                    fadein = false;
                }
            }
        }

        if (fadeout)
        {
            if (canvasgroup.alpha >= 0)
            {
                canvasgroup.alpha -= Time.deltaTime;
                if (canvasgroup.alpha == 0)
                {
                    fadeout = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadein = true;
    }

    public void FadeOut()
    {
        fadeout = true;
    }
      
}
