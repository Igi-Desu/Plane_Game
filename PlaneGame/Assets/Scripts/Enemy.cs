using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamager,IDamagable,IDieAnimation
{
    float speed=3;
    [SerializeField]GameObject deathAnimation;
    void Update()
    {
        transform.position+=Vector3.left*speed*Time.deltaTime;
        if(transform.position.x<-10)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount){
        PlayDeathAnimation();
        Destroy(gameObject);
    }
    public void DealDamage(IDamagable damagable){
        damagable.TakeDamage(1);
        TakeDamage(1);
    }
    public void PlayDeathAnimation(){
        if(deathAnimation==null)return;
        Instantiate(deathAnimation,transform.position,Quaternion.identity);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out IDamagable damagable)){
            DealDamage(damagable);
            return;
        }
        if(other.TryGetComponent(out IDamager damager)){
            damager.DealDamage(GetComponent<IDamagable>());
        }
    }
}
