using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] uint damage = 15;
    [SerializeField] float speed = 1f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
    }

    public void TakeForce(Transform target)
    {
        rb.AddForce(transform.right * -speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<EnemySetting>().Damage(damage);
        }
    }
}
