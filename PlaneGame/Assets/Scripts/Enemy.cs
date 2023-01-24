using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamager,IDamagable,IDieAnimation
{
    float speed=3;
    UnityAction explodeOnLose;
    [SerializeField]GameObject deathAnimation;
    /// <summary>
    /// whether enemy should give us score or not
    /// </summary>
    void Start(){
        speed=MovingBackground.Instance.Speed;
        explodeOnLose = GameManager.Instance.AddOnLoseAction(Explode);
        ColorPlaneRandom();
    }
    void Update()
    {
        transform.position+=Vector3.left*speed*Time.deltaTime;
        if(transform.position.x<-10)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// colors plane with randomly chosen color
    /// </summary>
    void ColorPlaneRandom(){
        int a = Random.Range(0,5);
        Color c = Color.white;
        switch(a){
            case 0:
                c=Color.red/1.5f;
                break;
            case 1:
                c=Color.yellow/1.5f;
                break;
            case 2:
                c=Color.blue/1.5f;
                break;
            case 3:
                c=Color.gray/1.5f;
                break;
            case 4:
                c=Color.white;
                break;
        }
        GetComponent<SpriteRenderer>().color=c;
    }
    public void TakeDamage(int amount){
        PlayDeathAnimation();
        ScoreManager.Instance?.IncreaseScore();
        GameManager.Instance?.RemoveOnLoseAction(explodeOnLose);
        Destroy(gameObject);
    }
    public void DealDamage(IDamagable damagable){
        damagable.TakeDamage(1);
        Explode();
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
    /// <summary>
    /// called when enemy should immediatly be destroyed and not give player points
    /// </summary>
    void Explode(){
        PlayDeathAnimation();
        Destroy(gameObject);
    }
}
