using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetting : MonoBehaviour
{
    [SerializeField] uint health;
    [SerializeField] float speed;
    [SerializeField] float acceleration;
    [SerializeField] GameObject effectPref;

    public float GetSpeed()
    {
        return speed;
    }

    public uint GetHealth()
    {
        return health;
    }
    
    public void Damage(uint value)
    {
        Debug.Log(value);
        if ( value > health)
        {
            Destroy(gameObject);
            CoinController.AddCoin(5);
        }
        health -= value;
        if( health <= 0 )
        {
            CoinController.AddCoin(5);
            Destroy(gameObject);
            
        }
    }

    private void OnDestroy()
    {
        Instantiate(effectPref, transform.position, Quaternion.identity);
    }
}
