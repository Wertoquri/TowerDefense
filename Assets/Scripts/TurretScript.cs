using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [Header("Turret Settings")]
    [SerializeField] float range;
    [SerializeField] float turnSpeed = 1f;

    [Header("Bullet")]
    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform[] burrels;
    [SerializeField] float cooldown = 1f;
    private int burrelNumber = 0;

    private bool canShoot = true;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        Look();
    }

    void Look()
    {
        if (target != null)
        {
            Quaternion look = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime * turnSpeed);
            if (canShoot)
            {
                StartCoroutine(Shoot(burrelNumber));
                burrelNumber++;
                if(burrelNumber >= burrels.Length)
                {
                    burrelNumber = 0;
                }
                canShoot = !canShoot;
            }
        }
    }

    void FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject currentTarget = null;
        float distance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToEnemy < distance)
            {
                distance = distanceToEnemy;
                currentTarget = target;
            }
        }
        if (distance <= range && currentTarget != null)
        {
            this.target = currentTarget.transform;
        }
        else
        {
            this.target = null;
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(FindTarget), 0f, 0.3f);
    }


    IEnumerator Shoot(int burrelNumber)
    {
        GameObject bullet = Instantiate(bulletPref, burrels[burrelNumber]);
        bullet.transform.SetParent(null);
        bullet.GetComponent<BulletScript>().TakeForce(target);
        yield return new WaitForSeconds(cooldown);
        canShoot = !canShoot;
    }
}
