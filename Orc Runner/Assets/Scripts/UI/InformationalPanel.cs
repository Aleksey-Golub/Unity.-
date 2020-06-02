using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationalPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup.alpha = 0;
    }

    public void OnAdsIsNotReagy()
    {
        _text.text = $"Ads is not Ready";
        StartCoroutine(ChangeAlphaCor());
    }

    public void OnAdsFailed()
    {
        _text.text = "Play Reward is Failed";
        StartCoroutine(ChangeAlphaCor());
    }

    public void OnAdsFinished(int coins)
    {
        _text.text = $"You get {coins} coins";
        StartCoroutine(ChangeAlphaCor());
    }

    private IEnumerator ChangeAlphaCor()
    {
        _canvasGroup.alpha = 1;
        yield return new WaitForSeconds(2f);
        _canvasGroup.alpha = 0;
    }
}
