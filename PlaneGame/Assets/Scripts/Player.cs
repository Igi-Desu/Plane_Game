using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>, IDamagable
{
    int hp=3;
    bool iFrames=false;
    void Start(){
        GameManager.Instance.AddOnLoseAction(Explode);
    }
    public void TakeDamage(int amount){
        if(iFrames) return;
        StartCoroutine(IFrames(0.5f));
        hp-=amount;
        Debug.Log("Current hp = " + hp);
        if(hp<=0){
            GameManager.Instance.Lose();
        }
    }
    IEnumerator IFrames(float time){
        iFrames=true;
        yield return new WaitForSeconds(time);
        iFrames=false;
    }

    private void Explode(){
        Debug.Log("Exploding");
    }
}
