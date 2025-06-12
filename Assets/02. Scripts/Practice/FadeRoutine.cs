using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeRoutine : MonoBehaviour
{
    public Image fadePanel;
    
    public void OnFade(float fadeTime, Color color, bool isFadeStart)
    {
        StartCoroutine(Fade(fadeTime, color, isFadeStart));
    }

    internal void OnFade(float v1, object newColor, bool v2)
    {
        throw new NotImplementedException();
    }

    IEnumerator Fade(float fadeTime, Color color, bool isFadeStart)
    {
        float timer = 0f;
        float percent = 0f;

        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;

            float value = isFadeStart ? percent : 1 - percent;

            fadePanel.color = new Color(color.r, color.g, color.b, value);
            yield return null;
        }
    }
}