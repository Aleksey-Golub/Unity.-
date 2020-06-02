using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(0,1, _lerpDuration, FillHeart));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, _lerpDuration, DestroyHeart));
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsedTime = 0;
        float nextValue;

        while(elapsedTime < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            _image.fillAmount = nextValue;
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        lerpingEnd?.Invoke(endValue);
    }

    private void DestroyHeart(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void FillHeart(float value)
    {
        _image.fillAmount = value;
    }
}
