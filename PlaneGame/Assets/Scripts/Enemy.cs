using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamager,IDamagable
{
    float speed=3;
    void Update()
    {
        transform.position+=Vector3.left*speed*Time.deltaTime;
    }

    public void TakeDamage(int amount){
        Destroy(gameObject);
    }
    public void DealDamage(int amount){

    }
}
