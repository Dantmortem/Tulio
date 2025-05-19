using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIFade : MonoBehaviour
{
    public static UIFade Instance { get; private set; }
    [SerializeField] private Image fadeScreen;
    [SerializeField] private float fadeSpeed = 1f;
    private IEnumerator fadeRoutine;
    public Canvas canvas;
    public bool estaActivo = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void FadeToBlack()
    {
        estaActivo = true;
        canvas.enabled = true;
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(1);
        StartCoroutine(fadeRoutine);
    }

    public void FadeToClear()
    {
        estaActivo = false;
        canvas.enabled = false;
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(0);
        StartCoroutine(fadeRoutine);
    }
    void Update()
    {
        if (!estaActivo)
        {
            canvas.enabled = false;
        }
        else
        {
            canvas.enabled = true;
        }
    }
    private IEnumerator FadeRoutine(float targetAlpha) {
        while (!Mathf.Approximately(fadeScreen.color.a, targetAlpha))
        {
            float alpha = Mathf.MoveTowards(fadeScreen.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, alpha);
            yield return null;
        }
    }
}
