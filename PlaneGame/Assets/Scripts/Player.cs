using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>, IDamagable
{
    int hp;

    void Start(){
    }



    private void OnCollisionEnter2D(Collision2D other) {
        
    }

    public void TakeDamage(int amount){
        hp-=amount;
        //UpdateHpBar()
        if(hp<=0){
            GameManager.Instance.Lose();
        }
    }
}
