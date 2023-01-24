using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>, IDamagable, IDieAnimation
{
    int hp=3;
    /// <summary>
    /// returns current health the player has
    /// </summary>
    public int Hp => hp;
    bool iFrames=false;
    [SerializeField]GameObject deathAnimation;
    void Start(){
        GameManager.Instance.AddOnLoseAction(Explode);
    }
    private void OnEnable() {
        hp=3;
        HealthManager.Instance?.Restart();
    }
    public void TakeDamage(int amount){
        if(iFrames) return;
        hp-=amount;
        Debug.Log("Current hp = " + hp);
        HealthManager.Instance.RemoveHeart();
        if(hp<=0){
            GameManager.Instance.Lose();
            return;
        }
         StartCoroutine(IFrames(0.5f));
    }
    IEnumerator IFrames(float time){
        iFrames=true;
        GetComponent<CircleCollider2D>().enabled=false;
        yield return new WaitForSeconds(time);
        iFrames=false;
        GetComponent<CircleCollider2D>().enabled=true;
    }

    private void Explode(){
        PlayDeathAnimation();
        transform.gameObject.SetActive(false);
    }
    public void PlayDeathAnimation(){
        Instantiate(deathAnimation,transform.position,Quaternion.identity);
    }
}
