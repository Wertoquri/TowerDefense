using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsShowListener, IUnityAdsLoadListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOSAdUnitId = "Interstitial_iOS";
    string _adUnitId;

    bool isAdLoaded = false;
    int buildTowers = 0;

    private void LoadAd()
    {
        Debug.Log("Реклама почала завантажуватись");
        Advertisement.Load(_adUnitId, this);
    }

    private void ShowAd()
    {
        Time.timeScale = 0f;
        if (isAdLoaded)
        {
            Debug.Log("Реклама почала показуватись");
            Advertisement.Show(_adUnitId, this);
        }
        else
        {
            Debug.Log("Реклама ще не завантажилась");
        }
    }

    public void TowerBuild()
    {
        buildTowers++;
        if (buildTowers >= 5)
        {
            buildTowers = 0;
            if (Random.Range(0f, 1f) < 0.4f) ShowAd();
        }
    }
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _adUnitId = _iOSAdUnitId;
        }
        else
        {
            _adUnitId = _androidAdUnitId;
        }
        AdsInitalizer.OnInitComplete.AddListener(LoadAd);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        isAdLoaded = true;
        Debug.Log("Реклама завантажилась");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Помилка завантаження {message}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Time.timeScale = 1f;
        isAdLoaded = false;
        LoadAd();
        Debug.Log("Реклама показана");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Time.timeScale = 1f;
        Debug.Log($"Помилка показу {message}");

    }
    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Реклама показується");
    }

    private void OnDestroy()
    {
        AdsInitalizer.OnInitComplete.RemoveListener(LoadAd);
    }
}