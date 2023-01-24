using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamager,IDamagable,IDieAnimation
{
    float speed=3;
    [SerializeField]GameObject deathAnimation;
    /// <summary>
    /// whether enemy should give us score or not
    /// </summary>
    bool shouldGiveScore = true;//if enemy dies because it collided with our plane it should not give score
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
        shouldGiveScore=false;
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
            return;
        }
    }
    void OnDestroy()
    {
        if(!shouldGiveScore)return;
        ScoreManager.Instance.IncreaseScore();
    }
}
