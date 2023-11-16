using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Intro_UI : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI tmp;
    private float blinkSpeed = 1.0f;
    Color color;
    private float speed;

    IEnumerator Start()
    {
        Color temp = image.color;
        temp.a = 0.0f;
        image.color = temp;
        speed = 0.3f;
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            Color originalColor = tmp.color;
            Color transparentColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.0f);

            tmp.color = transparentColor;
            yield return new WaitForSeconds(blinkSpeed);

            tmp.color = originalColor;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
    IEnumerator FadeIn()
    {
        color = image.color;
        while (color.a < 1.0f)
        {
            yield return null;
            color.a += Time.deltaTime * speed;
            image.color = color;
        }
    }

    void Update()
    {
        
    }
}
