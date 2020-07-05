using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image rend;
    Color color;
    void Start()
    {
        color = rend.material.color;
        color.a = 0f;
    }
    
    // Update is called once per frame
    IEnumerator FadeIn()
    {
        for (float i = 0.05f; i <= 1; i+= 0.05f)
        {
            Color c = rend.material.color;
            c.a = i;
            rend.material.color = c;
            c.a = 0f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeOut()
    {
        for (float i = 1; i >= -0.05; i -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = i;
            rend.material.color = c;
            c.a = 0f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }
}
