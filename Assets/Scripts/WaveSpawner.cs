using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float countDown = 3f;
    [SerializeField] float timeBetweenSpawn = 1f;

    Transform enemiesParent;
    public int waveNumber = 1;
    private void Start()
    {        
        StartCoroutine(Spawn());
        enemiesParent = GameObject.Find("Enemies").transform;
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSecondsRealtime(countDown);
        for (int i = 0; i < waveNumber; i++)
        {
            GameObject enemy = null;
            if(waveNumber <= 3){
                Instantiate(enemys[0], spawnPoint.position, Quaternion.identity, enemiesParent);
            }
            else if(waveNumber < 7){
                int index = Random.Range(0, 2);
                Instantiate(enemys[index], spawnPoint.position, Quaternion.identity, enemiesParent);
            }
            else{
                int index = Random.Range(1, 3);
                Instantiate(enemys[index], spawnPoint.position, Quaternion.identity, enemiesParent);
            }
            
            yield return new WaitForSecondsRealtime(timeBetweenSpawn);
        }
        waveNumber++;
        StartCoroutine(Spawn());
    }

    
}
