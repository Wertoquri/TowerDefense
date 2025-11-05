using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemyCountText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] GameObject Panel;

    int hp = 5;
    Transform enemiesParent;
    WaveSpawner waveSpawner;
    
    public void ChangeHealth(int value)
    {
        hp += value;

    }
    void Start()
    {
        enemiesParent = GameObject.Find("Enemies").transform;
        waveSpawner = FindObjectOfType<WaveSpawner>();
        Time.timeScale = 1;
    }

    void Update()
    {
        int wn = waveSpawner.waveNumber;
        waveText.SetText($"Wave: {wn}");
        enemyCountText.SetText($"Enemies: {enemiesParent.childCount}");
        healthText.SetText($"Health: {hp}");
        if (hp <= 0)
        {
            Panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
