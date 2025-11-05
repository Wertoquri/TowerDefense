using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class AdsInitalizer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iosGameId;
    [SerializeField] bool _testMode = true;

    [SerializeField] string _gameId;

    public void OnInitializationComplete(){
        Debug.Log("Unity Ads Initialization Complete.");
        OnInitComplete.Invoke();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message){
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void InitializeAds()
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _gameId = _iosGameId;
        }
        else
        {
            _gameId = _androidGameId;
        }   
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

    private void  Awake() {
        InitializeAds();
    }

    public static UnityEvent OnInitComplete = new UnityEvent();
}
