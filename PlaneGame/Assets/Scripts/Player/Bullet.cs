using UnityEngine;
/// <summary>
/// Simple bullet that travels to the right
/// </summary>
public class Bullet : MonoBehaviour,IDamager
{
    float speed=5;

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
