using System.Collections;
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
        transform.position=new Vector3(transform.position.x,0,transform.position.z);
        HealthManager.Instance?.Restart();
    }
    public void TakeDamage(int amount){
        if(iFrames) return;
        hp-=amount;
        HealthManager.Instance.RemoveHeart();
        if(hp<=0){
            GameManager.Instance.Lose();
            return;
        }
         StartCoroutine(IFrames(0.5f));
    }
    IEnumerator IFrames(float time){
        iFrames=true;
        var cor = StartCoroutine(IFrameFlick());
        GetComponent<CircleCollider2D>().enabled=false;
        yield return new WaitForSeconds(time);
        iFrames=false;
        GetComponent<CircleCollider2D>().enabled=true;
        //make sure that after iframe flicking player stays visible
        StopCoroutine(cor);
        GetComponent<SpriteRenderer>().color=Color.white;
    }
    IEnumerator IFrameFlick(){
        var spriteRenderer=  GetComponent<SpriteRenderer>();
        while(true){
            var c = spriteRenderer.color;
            c.a=c.a==255? 0: 255;
            spriteRenderer.color=c;
            yield return new WaitForSeconds(0.0625f);
        }
    }
    private void Explode(){
        PlayDeathAnimation();
        transform.gameObject.SetActive(false);
    }
    public void PlayDeathAnimation(){
        Instantiate(deathAnimation,transform.position,Quaternion.identity);
    }
}
