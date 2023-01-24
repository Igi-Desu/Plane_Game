using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;
public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField]GameObject bullet;
    float movement;
    [SerializeField]float speed;
    bool canShot=true;

    void Start(){
        GameManager.Instance.AddOnStartAction(EnableMovement);
        this.enabled=false;
    }
    void EnableMovement(){
        this.enabled=true;
        //make sure that we can should, cooldown coroutine can make shooting 
        //impossible when interrupted
        canShot=true;
    }
    protected void Update(){
        //clamp position so that player doesn't exit playable ground
        float yPos= math.clamp(transform.position.y+movement*speed*Time.deltaTime,-2,2);
        
        transform.position= new Vector3(transform.position.x,yPos,0);
        
    }

    public void Move(InputAction.CallbackContext ctx){
        movement=ctx.ReadValue<float>();
    }

    public void Shoot(InputAction.CallbackContext ctx){
        if(!canShot)return;
        Instantiate(bullet,transform.position,quaternion.identity);
        StartCoroutine(ShootingCooldown(0.5f));
    }

    IEnumerator ShootingCooldown(float amount){
        canShot=false;
        yield return new WaitForSeconds(amount);
        canShot=true;
    }
}
