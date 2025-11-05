using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent navMesh;
    Vector3 finishPoint;
    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        finishPoint = GameObject.FindGameObjectWithTag("Finish").transform.position;
        navMesh.destination = finishPoint;
        navMesh.speed = GetComponent<EnemySetting>().GetSpeed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            FindObjectOfType<GameController>().ChangeHealth((int)GetComponent<EnemySetting>().GetHealth() * -1);
            Destroy(gameObject);
        }
    }
}
