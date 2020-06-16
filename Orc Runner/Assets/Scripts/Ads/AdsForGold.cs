using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class AdsForGold : MonoBehaviour, IUnityAdsListener
{
    private string _gameId = "3604609";  // id for Google Play
    private string _myPlacementId = "rewardedVideo";
    private bool _testMode = false;

    private int _coinsForAds = 50;
    private bool _adsIsReady = false;

    public event UnityAction<int> AdsFinished;
    public event UnityAction AdsFailed;

    public bool AdsIsReady => _adsIsReady;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }

    public void ShowAds()
    {
        Advertisement.Show(_myPlacementId);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // логика начисления награды
        if (showResult == ShowResult.Finished)
        {
            AdsFinished?.Invoke(_coinsForAds);
        }
        else if (showResult == ShowResult.Skipped)
        {
        }
        else if (showResult == ShowResult.Failed)
        {
            AdsFailed?.Invoke();
        }
    }
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _myPlacementId)
        {
            _adsIsReady = true;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Н. логика остановки игры при запуске рекламы
    }

    public void OnUnityAdsDidError(string message)
    {
        // реклама завершилась с ошибкой
        // Н. для отслеживания и аналитики
    }
}
