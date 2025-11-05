using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonShopSettings : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int cost = 5;
    [SerializeField] int buildIndex = 0;

    private void Awake(){
        GetComponentInChildren<TextMeshProUGUI>().SetText(cost.ToString());
        BuildManager manager = FindObjectOfType<BuildManager>();
        GetComponent<Button>().onClick.AddListener(() => manager.SetBuildTurret(cost, buildIndex));
    }
}
