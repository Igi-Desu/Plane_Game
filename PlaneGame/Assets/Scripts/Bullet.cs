using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IDamager
{
    float speed=5;

    // Update is called once per frame
    void Update()
    {
        transform.position+=Vector3.right*speed*Time.deltaTime;
        if(transform.position.x>10){
            Destroy(gameObject);
        }
    }
    public void DealDamage(IDamagable damagable){
        damagable.TakeDamage(1);
        Destroy(gameObject);
    }
}
