using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour
{
    private string gameId = "3604609";  // id for Google Play
    private bool testMode = false;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    private IEnumerator ShowBannerWhenReady()
    {
        var waitForHalfSecond = new WaitForSeconds(0.5f);

        while (!Advertisement.IsReady("Banner"))
        {
            yield return waitForHalfSecond;
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("Banner");
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 0)
        {
            Advertisement.Initialize(gameId, testMode);
            StartCoroutine(ShowBannerWhenReady());
        }

        if (level == 1)
            Advertisement.Banner.Hide();
    }
}
