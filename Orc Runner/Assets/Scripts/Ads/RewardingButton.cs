using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardingButton : MonoBehaviour
{
    [SerializeField] private InformationalPanel _informationalPanel;
    private AdsForGold _adsForGold;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _adsForGold = FindObjectOfType<AdsForGold>();

        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _adsForGold.AdsFinished += OnAdsFinished;

        if (_adsForGold.AdsIsReady)
            _adsForGold.ShowAds();
        else
            _informationalPanel.OnAdsIsNotReagy();
    }

    private void OnAdsFinished(int coinsForAds)
    {
        GameManager.Instance.AddCoins(coinsForAds);
        SaveManager.Instance.SaveGame();

        _informationalPanel.OnAdsFinished(coinsForAds);

        _adsForGold.AdsFinished -= OnAdsFinished;
    }
}
