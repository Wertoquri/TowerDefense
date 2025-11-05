using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinController : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] int startCoins;
    static int coin;
    void Awake()
    {
        coin = startCoins;
    }

    public static int GetCoinsValue() => coin;
    public static void AddCoin(int value) => coin += value;
    public static bool SubtructCoin(int value)
    {
        if(value > coin)return false;
        coin -= value;
        return true;
    }

    private void LateUpdate()
    {
        coinText.SetText($"Coins: {coin}");
    }
}
